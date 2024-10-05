namespace App;

public static class ChordService
{
    private static readonly List<string> Notes = new List<string> {
        "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#"
    };

    private static Dictionary<string, string> _enharmonicNotes = new Dictionary<string, string>
    {
        { "Bb", "A#" }, { "Db", "C#" }, { "Eb", "D#" }, { "Gb", "F#" }, { "Ab", "G#" }
    };

    public static List<int> GetChordNotes(string chord)
    {
        var rootNote = chord[..1];
        var chordType = chord.Length > 1 ? chord[1..] : "";
        
        if (chord.Length > 1 && (chord[1] == '#' || chord[1] == 'b'))
        {
            rootNote = chord[..2];
            chordType = chord.Length > 2 ? chord[2..] : "";
        }
        
        var rootIndex = Notes.IndexOf(rootNote);
        if (rootIndex == -1) throw new ArgumentException("Невідома нота");

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