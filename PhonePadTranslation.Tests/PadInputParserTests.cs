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
            string input = "5#";
            List<(char, int)> expected = [('5', 1)];

            Assert.That(subject.Parse(input), Is.EqualTo(expected));
        }

        [Test]
        public void Parse_TwoDigits_ReturnsListWithTwoTuples()
        {
            string input = "56#";
            List<(char, int)> expected = [('5', 1), ('6', 1)];

            Assert.That(subject.Parse(input), Is.EqualTo(expected));
        }

        [Test]
        public void Parse_ThreeSameDigits_ReturnsListWithOneTuple()
        {
            string input = "555#";
            List<(char, int)> expected = [('5', 3)];

            Assert.That(subject.Parse(input), Is.EqualTo(expected));
        }

        [Test]
        public void Parse_ThreeSameDigitsDividedBySpaces_ReturnsListWithThreeTuples()
        {
            string input = "5 5 5 #";
            List<(char, int)> expected = [('5', 1), ('5', 1), ('5', 1)];

            Assert.That(subject.Parse(input), Is.EqualTo(expected));
        }

        [Test]
        public void Parse_InputWithStar_OmitsTupleBeforeStar()
        {
            string input = "8 88777444666*664#";
            List<(char, int)> expected =
            [
                ('8', 1),
                ('8', 2),
                ('7', 3),
                ('4', 3),
                ('6', 2),
                ('4', 1)
            ];

            Assert.That(subject.Parse(input), Is.EqualTo(expected));
        }

        [Test]
        public void Parse_InputWithFirstStar_DoesNotThrow()
        {
            string input = "*88#";
            List<(char, int)> expected = [('8', 2)];

            Assert.That(subject.Parse(input), Is.EqualTo(expected));
        }
    }
}
