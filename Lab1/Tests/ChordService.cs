using System;
using System.Collections.Generic;
using App;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class ChordServiceTests
    {
        private readonly ITestOutputHelper _output;

        public ChordServiceTests(ITestOutputHelper output) => _output = output;

        [Fact]
        public void GetChordNotes_ThrowsArgumentException_WhenChordIsUnknown()
        {
            var chord = "X"; // Unknown chord
            Action act = () => ChordService.GetChordNotes(chord);
            
            var exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal($"Ноти {chord} не існує", exception.Message);
            _output.WriteLine($"{nameof(GetChordNotes_ThrowsArgumentException_WhenChordIsUnknown)}: {chord} - passed");
        }

        [Theory]
        [InlineData("C", new[] { 3, 7, 10 })] // C major
        [InlineData("D", new[] { 5, 9, 0 })] // D major
        [InlineData("F#m", new[] { 9, 0, 4 })] // F# minor
        public void GetChordNotes_ReturnsExpectedChordNotes(string chord, int[] expectedNotes)
        {
            var actual = ChordService.GetChordNotes(chord);
            
            Assert.Equal(expectedNotes, actual);
            _output.WriteLine($"{nameof(GetChordNotes_ReturnsExpectedChordNotes)}: {chord}, {string.Join(", ", expectedNotes)} - passed");
        }

        [Theory]
        [InlineData("Bb", "A#")] // Bb to A#
        [InlineData("Db", "C#")] // Db to C#
        public void ChangeEnharmonicNotes_ShouldConvertEnharmonicNotes(string inputNote, string expectedNote)
        {
            var inputNotes = new[] { inputNote };
            
            var result = ChordService.ChangeEnharmonicNotes(inputNotes);
            
            Assert.Equal(new[] { expectedNote }, result);
            _output.WriteLine($"{nameof(ChangeEnharmonicNotes_ShouldConvertEnharmonicNotes)}: {inputNote} - passed");
        }

        [Fact]
        public void CountWaysToPlayChord_ShouldThrowArgumentException_WhenOpenNoteIsInvalid()
        {
            var tuning = new[] { "E", "A", "INVALID", "G", "B", "E" };
            var frets = 5;
            var chordNotes = new List<int> { 0, 4, 7 }; // E major chord
            
            Action act = () => ChordService.CountWaysToPlayChord(tuning, frets, chordNotes);
            
            var exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Ноти INVALID не існує", exception.Message);
            _output.WriteLine($"{nameof(CountWaysToPlayChord_ShouldThrowArgumentException_WhenOpenNoteIsInvalid)} - passed");
        }

        [Fact]
        public void CountWaysToPlayChord_ReturnsCorrectWays()
        {
            var tuning = new[] { "E", "A", "D", "G", "B", "E" };
            var frets = 5;
            var chordNotes = new List<int> { 0, 4, 7 }; // E major chord
            
            var result = ChordService.CountWaysToPlayChord(tuning, frets, chordNotes);
            
            Assert.True(result > 0); // Expecting some ways to play the chord
            _output.WriteLine($"{nameof(CountWaysToPlayChord_ReturnsCorrectWays)}: {result} - passed");
        }
    }
}
