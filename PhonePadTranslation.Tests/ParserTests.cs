﻿namespace PhonePadTranslation.Tests
{
    /// <summary>
    /// Here we're expecting only correct input due to the workflow, so we're not testing for invalid input.
    /// </summary>
    public class ParserTests
    {
        private Parser subject;

        [SetUp]
        public void Setup()
        {
            subject = new Parser();
        }

        [Test]
        public void Parse_OneDigit_ReturnsListWithOneTuple()
        {
            var input = "5#";
            var expected = new List<Tuple<char, int>> { new Tuple<char, int>('5', 1) };

            Assert.That(subject.Parse(input), Is.EqualTo(expected));
        }

        [Test]
        public void Parse_TwoDigits_ReturnsListWithTwoTuples()
        {
            var input = "56#";
            var expected = new List<Tuple<char, int>> { new Tuple<char, int>('5', 1), new Tuple<char, int>('6', 1) };

            Assert.That(subject.Parse(input), Is.EqualTo(expected));
        }

        [Test]
        public void Parse_ThreeSameDigits_ReturnsListWithOneTuple()
        {
            var input = "555#";
            var expected = new List<Tuple<char, int>> { new Tuple<char, int>('5', 3) };

            Assert.That(subject.Parse(input), Is.EqualTo(expected));
        }

        [Test]
        public void Parse_ThreeSameDigitsDividedBySpaces_ReturnsListWithThreeTuples()
        {
            var input = "5 5 5 #";
            var expected = new List<Tuple<char, int>> { new Tuple<char, int>('5', 1), new Tuple<char, int>('5', 1), new Tuple<char, int>('5', 1) };

            Assert.That(subject.Parse(input), Is.EqualTo(expected));
        }
    }
}
