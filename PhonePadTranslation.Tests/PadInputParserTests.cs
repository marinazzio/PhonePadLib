namespace PhonePadTranslation.Tests
{
    /// <summary>
    /// Here we're expecting only correct input due to the workflow, so we're not testing for invalid input.
    /// </summary>
    public class PadInputParserTests
    {
        private PadInputParser subject;

        [SetUp]
        public void Setup()
        {
            subject = new PadInputParser();
        }

        [Test]
        public void Parse_OneDigit_ReturnsListWithOneTuple()
        {
            var input = "5#";
            var expected = new List<(char, int)> { ('5', 1) };

            Assert.That(subject.Parse(input), Is.EqualTo(expected));
        }

        [Test]
        public void Parse_TwoDigits_ReturnsListWithTwoTuples()
        {
            var input = "56#";
            var expected = new List<(char, int)> { ('5', 1), ('6', 1) };

            Assert.That(subject.Parse(input), Is.EqualTo(expected));
        }

        [Test]
        public void Parse_ThreeSameDigits_ReturnsListWithOneTuple()
        {
            var input = "555#";
            var expected = new List<(char, int)> { ('5', 3) };

            Assert.That(subject.Parse(input), Is.EqualTo(expected));
        }

        [Test]
        public void Parse_ThreeSameDigitsDividedBySpaces_ReturnsListWithThreeTuples()
        {
            var input = "5 5 5 #";
            var expected = new List<(char, int)> { ('5', 1), ('5', 1), ('5', 1) };

            Assert.That(subject.Parse(input), Is.EqualTo(expected));
        }

        [Test]
        public void Parse_InputWithStar_OmitsTupleBeforeStar()
        {
            var input = "8 88777444666*664#";
            var expected = new List<(char, int)> { 
                ('8', 1),
                ('8', 2),
                ('7', 3),
                ('4', 3),
                ('6', 2),
                ('4', 1)
            };

            Assert.That(subject.Parse(input), Is.EqualTo(expected));
        }

        [Test]
        public void Parse_InputWithFirstStar_DoesNotThrow()
        {
            var input = "*88#";
            var expected = new List<(char, int)> { ('8', 2) };

            Assert.That(subject.Parse(input), Is.EqualTo(expected));
        }
    }
}
