namespace PhonePadTranslation.Tests
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

        [Test]
        public void Parse_InputWithStar_OmitsTupleBeforeStar()
        {
            var input = "8 88777444666*664#";
            var expected = new List<Tuple<char, int>> { 
                new Tuple<char, int>('8', 1),
                new Tuple<char, int>('8', 2),
                new Tuple<char, int>('7', 3),
                new Tuple<char, int>('4', 3),
                new Tuple<char, int>('6', 2),
                new Tuple<char, int>('4', 1)
            };

            Assert.That(subject.Parse(input), Is.EqualTo(expected));
        }

        [Test]
        public void Parse_InputWithFirstStar_DoesNotThrow()
        {
            var input = "*88#";
            var expected = new List<Tuple<char, int>> { 
                new Tuple<char, int>('8', 2)
            };

            Assert.That(subject.Parse(input), Is.EqualTo(expected));
        }
    }
}
