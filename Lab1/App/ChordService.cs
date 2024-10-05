namespace App;

public static class ChordService
{
    private static readonly List<string> Notes = new () {
        "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#"
    };

    private static readonly Dictionary<string, string> EnharmonicNotes = new ()
    {
        { "Bb", "A#" }, { "Db", "C#" }, { "Eb", "D#" }, { "Gb", "F#" }, { "Ab", "G#" }
    };

    public static string[] ChangeEnharmonicNotes(string[] notes)
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
    
    public static int CountWaysToPlayChord(string[] tuning, int frets, List<int> chordNotes)
    {
        var possibleWays = 1;
        foreach (var openNote in tuning)
        {
            var waysForString = 0;
            var openNoteIndex = Notes.IndexOf(openNote);

            if (openNoteIndex == -1)
            {
                throw new ArgumentException($"Ноти {openNote} не існує");
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

    public static List<int> GetChordNotes(string chord)
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
            throw new ArgumentException($"Ноти {rootNote} не існує");
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
            throw new ArgumentException("Невідомий тип акорду");
        }

        return notes;
    }

}