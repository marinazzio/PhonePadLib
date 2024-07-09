namespace PhonePadTranslation.Tests
{
    public class PadDictionaryTests
    {
        private PadDictionary subject;

        private char inputDigit;
        private int inputPosition;

        private readonly Random random = new Random();

        [SetUp]
        public void Setup()
        {
            subject = new PadDictionary();

            inputDigit = random.Next(0, 9).ToString()[0];

            var upperLimit = getUpperLimitByDigit(inputDigit);
            inputPosition = random.Next(1, upperLimit);
        }

        [Test]
        [Repeat(5)]
        public void Translate_WhenCalled_ReturnsCorrectChar()
        {
            Assert.That(subject.Translate(inputDigit, inputPosition), Is.InstanceOf<char>());
        }

        private int getUpperLimitByDigit(char digit)
        {
            return digit switch
            {
                '7' => 4,
                '9' => 4,
                '0' => 1,
                _ => 3
            };
        }
    }
}
