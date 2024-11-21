namespace ClassLib;

public class Lab1
{
    public static string Execute(string inputPath)
    {
        try
        {
            var (frets, tuning, chord) = ParseInputFile(inputPath);

            tuning = ChangeEnharmonicNotes(tuning);

            var chordNotes = GetChordNotes(chord);

            var possibleWays = CountWaysToPlayChord(tuning, frets, chordNotes);

            return possibleWays.ToString();
        }
        catch (Exception e)
        {
            return "Something went wrong: " + e.Message;
        }
    }
    
    private static readonly List<string> Notes = new () {
        "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#"
    };

    private static readonly Dictionary<string, string> EnharmonicNotes = new ()
    {
        { "Bb", "A#" }, { "Db", "C#" }, { "Eb", "D#" }, { "Gb", "F#" }, { "Ab", "G#" }
    };
    
    private static (int frets, string[] tuning, string chord) ParseInputFile(string inputFileName)
    {
        if (!File.Exists(inputFileName))
        {
            throw new FileException($"File {inputFileName} not found");
        }
        
        var lines = File.ReadAllLines(inputFileName)
            .Select(static line => line.Trim())
            .Where(static line => !string.IsNullOrWhiteSpace(line))
            .ToArray();

        if (lines.Length != 3)
        {
            throw new FileException("The file must contain exactly 3 lines");
        }
        
        var fretsArray = lines[0]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (fretsArray.Length > 1)
        {
            throw new FileException("The first line must contain only one number");
        }

        if (!int.TryParse(fretsArray[0], out var frets))
        {
            throw new FileException("The first line must contain an integer");
        }

        if (frets < 0 || frets > 9)
        {
            throw new FileException("The first line must contain a number between 0 and 9");
        }
        
        var tuning = lines[1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (tuning.Length != 6)
        {
            throw new FileException("The second line must contain 6 notes");
        }
        
        var chordsArray = lines[2].
            Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (chordsArray.Length > 1)
        {
            throw new FileException("The third line must contain 1 chord");
        }

        return (frets, tuning, chordsArray[0]);
    }

    private static string[] ChangeEnharmonicNotes(string[] notes)
    {
        for (var i = 0; i < notes.Length; i++)
        {
            if (EnharmonicNotes.ContainsKey(notes[i]))
            {
                notes[i] = EnharmonicNotes[notes[i]];
            }
        }

        return notes;
    }
    
    private static int CountWaysToPlayChord(string[] tuning, int frets, List<int> chordNotes)
    {
        var possibleWays = 1;
        foreach (var openNote in tuning)
        {
            var waysForString = 0;
            var openNoteIndex = Notes.IndexOf(openNote);

            if (openNoteIndex == -1)
            { 
                throw new ArgumentException($"The note {openNote} does not exist");
            }

            for (var fret = 0; fret <= frets; fret++)
            {
                var noteAtFret = (openNoteIndex + fret) % 12;
                if (chordNotes.Contains(noteAtFret))
                {
                    waysForString++;
                }
            }
            
            if (waysForString == 0)
            {
                return 0;
            }

            possibleWays *= waysForString;
        }

        return possibleWays;
    }

    private static List<int> GetChordNotes(string chord)
    {
        var rootNote = chord[..1];
        var chordType = chord.Length > 1 ? chord[1..] : "";
        
        if (chord.Length > 1 && (chord[1] == '#' || chord[1] == 'b'))
        {
            rootNote = chord[..2];
            chordType = chord.Length > 2 ? chord[2..] : "";
        }
        
        if (EnharmonicNotes.ContainsKey(rootNote))
        {
            rootNote = EnharmonicNotes[rootNote];
        }
        
        var rootIndex = Notes.IndexOf(rootNote);
        
        if (rootIndex == -1)     
        {
            throw new ArgumentException($"The note {rootNote} does not exist");
        }

        var notes = new List<int> { rootIndex };
        
        if (chordType == "") 
        {
            notes.Add((rootIndex + 4) % 12);
            notes.Add((rootIndex + 7) % 12);
        }
        
        else if (chordType == "m")
        {
            notes.Add((rootIndex + 3) % 12);
            notes.Add((rootIndex + 7) % 12);
        }
        
        else if (chordType == "7")
        {
            notes.Add((rootIndex + 4) % 12);
            notes.Add((rootIndex + 7) % 12);
            notes.Add((rootIndex + 10) % 12);
        }
        
        else if (chordType == "m7")
        {
            notes.Add((rootIndex + 3) % 12);
            notes.Add((rootIndex + 7) % 12);
            notes.Add((rootIndex + 10) % 12);
        }
        else
        {
            throw new ArgumentException("Unknown chord type");
        }

        return notes;
    }

}