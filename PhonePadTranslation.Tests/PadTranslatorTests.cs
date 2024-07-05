namespace PhonePadTranslation.Tests
{
    public class PadTranslatorTests
    {
        private PadTranslator subject;

        [SetUp]
        public void Setup()
        {
            subject = new PadTranslator();
        }

        #region Correct input
        [Test]
        public void OldPhonePad_TranslatesOneChar()
        {
            Assert.That(subject.OldPhonePad("222#"), Is.EqualTo("C"));
        }
        #endregion

        #region Incorrect input
        [Test]
        public void OldPhonePad_NoEnding_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => subject.OldPhonePad("222"));
        }

        [Test]
        public void OldPhonePad_EmptyInput_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => subject.OldPhonePad(""));
        }

        [Test]
        public void OldPhonePad_InvalidChar_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => subject.OldPhonePad("2A2#"));
        }
        #endregion
    }
}
