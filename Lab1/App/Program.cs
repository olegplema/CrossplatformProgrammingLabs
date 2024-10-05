using App;


int frets;
string[] tuning;
string chord;
try
{
    (frets, tuning, chord) = FileProcessor.ParseInputFile();
}
catch (Exception e)
{
    Console.WriteLine("Виникла помилка: " + e.Message);
    return;
}

tuning = ChordService.ChangeEnharmonicNotes(tuning);

var chordNotes = ChordService.GetChordNotes(chord);

var posibleWays = 0;

try
{
    posibleWays = ChordService.CountWaysToPlayChord(tuning, frets, chordNotes);
}
catch (Exception e)
{
    Console.WriteLine("Виникла помилка: " + e.Message);
    return;
}

try
{
    FileProcessor.WriteOutputFile(posibleWays);
}
catch (Exception e)
{
    Console.WriteLine("Виникла помилка: " + e.Message);
}