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
        [Ignore("This test is not implemented yet")]
        public void ValidatePadInput_InvalidChar_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => subject.ValidatePadInput("2A2#"));
        }
        #endregion
    }
}
