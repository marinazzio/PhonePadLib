using Moq;

namespace PhonePadTranslation.Tests
{
    public class PadTranslatorTests
    {
        private PadTranslator subject;
        private Mock<IPadValidator> inputValidator;
        private Mock<IPreprocessor> preprocessor;

        [SetUp]
        public void Setup()
        {
            preprocessor = new Mock<IPreprocessor>();
            inputValidator = new Mock<IPadValidator>();
            subject = new PadTranslator(preprocessor.Object, inputValidator.Object);
        }

        #region Workflow
        [Test]
        public void OldPhonePad_ShouldCallMethodsInCorrectOrder()
        {
            string input = "222#";

            subject.OldPhonePad(input);

            var sequence = new MockSequence();
            preprocessor.InSequence(sequence).Setup(p => p.Preprocess(input)).Returns(input);
            inputValidator.InSequence(sequence).Setup(v => v.ValidatePadInput(input));

            preprocessor.Verify(p => p.Preprocess(input), Times.Once);
            inputValidator.Verify(validator => validator.ValidatePadInput(input), Times.Once);
        }
        #endregion

        #region Translation
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
    }
}
