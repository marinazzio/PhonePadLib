using Moq;

namespace PhonePadTranslation.Tests
{
    public class PadTranslatorTests
    {
        private PadTranslator subject;
        private Mock<InputValidator> inputValidator;

        [SetUp]
        public void Setup()
        {
            inputValidator = new Mock<InputValidator>();
            subject = new PadTranslator(inputValidator.Object);
        }

        #region Correct input
        [Test]
        public void OldPhonePad_TranslatesOneChar()
        {
            Assert.That(subject.OldPhonePad("222#"), Is.EqualTo("C"));
        }

        [Test]
        [Ignore("This test is not implemented yet")]
        public void OldPhonePad_TranslatesMultipleChars()
        {
            Assert.That(subject.OldPhonePad("2345#"), Is.EqualTo("ADGJ"));
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
