namespace PhonePadTranslation.Tests
{
    public class InputValidatorTests
    {
        private InputValidator subject;

        [SetUp]
        public void Setup()
        {
            subject = new InputValidator();
        }

        #region Correct input
        [Test]
        public void ValidatePadInput_ValidInput_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => subject.ValidatePadInput("222#"));
        }

        [Test]
        public void ValidatePadInput_ValidInputWithSpaces_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => subject.ValidatePadInput("22 2 33 3#"));
        }

        [Test]
        public void ValidatePadInput_ValidInputWithSpecialChars_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => subject.ValidatePadInput("2*3303#"));
        }
        #endregion

        #region Incorrect input
        [Test]
        public void ValidatePadInput_NoEnding_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => subject.ValidatePadInput("222"));
        }

        [Test]
        public void ValidatePadInput_EmptyInput_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => subject.ValidatePadInput(""));
        }

        [Test]
        public void ValidatePadInput_InvalidChar_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => subject.ValidatePadInput("2A2#"));
        }

        [Test]
        public void ValidatePadInput_InvalidChars_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => subject.ValidatePadInput("%@$6271 * ((43#"));
        }

        [Test]
        public void ValidatePadInput_Ending_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => subject.ValidatePadInput("%#@$6271 * ((43"));
        }
        #endregion
    }
}
