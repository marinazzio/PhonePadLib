using Moq;

namespace PhonePadTranslation.Tests
{
    public class PadTranslatorTests
    {
        private PadTranslator subject;
        private Mock<IPadValidator> inputValidator;
        private Mock<IPreprocessor> preprocessor;
        private Mock<IParser> parser;
        private Mock<IDictionary> dictionary;

        private string input;

        [SetUp]
        public void Setup()
        {
            preprocessor = new Mock<IPreprocessor>();
            inputValidator = new Mock<IPadValidator>();
            parser = new Mock<IParser>();
            dictionary = new Mock<IDictionary>();

            input = "222#";

            var sequence = new MockSequence();
            preprocessor.InSequence(sequence).Setup(p => p.Preprocess(input)).Returns(input);
            inputValidator.InSequence(sequence).Setup(v => v.ValidatePadInput(input));
            parser.InSequence(sequence).Setup(p => p.Parse(input)).Returns(new List<Tuple<char, int>>() { new('2', 3) });
            dictionary.InSequence(sequence).Setup(d => d.Translate(It.IsAny<char>(), It.IsAny<int>())).Returns('C');

            subject = new PadTranslator(preprocessor.Object, inputValidator.Object, parser.Object, dictionary.Object);
        }

        #region Workflow
        [Test]
        public void OldPhonePad_ShouldCallMethodsInCorrectOrder()
        {
            subject.OldPhonePad(input);

            preprocessor.Verify(p => p.Preprocess(input), Times.Once);
            inputValidator.Verify(validator => validator.ValidatePadInput(It.IsAny<string>()), Times.Once);
            parser.Verify(p => p.Parse(It.IsAny<string>()), Times.Once);
            dictionary.Verify(d => d.Translate(It.IsAny<char>(), It.IsAny<int>()), Times.AtLeastOnce);
        }
        #endregion

        #region Translation
        [Test]
        public void OldPhonePad_TranslatesOneChar()
        {
            Assert.That(subject.OldPhonePad("222#"), Is.EqualTo("C"));
        }

        [Test]
        public void OldPhonePad_TranslatesMultipleChars()
        {
            input = "2345#";
            preprocessor.Setup(p => p.Preprocess(input)).Returns(input);
            parser.Setup(p => p.Parse(input)).Returns(new List<Tuple<char, int>>() { new('2', 1), new('3', 1), new('4', 1), new('5', 1) });
            dictionary.Setup(d => d.Translate('2', 1)).Returns('A');
            dictionary.Setup(d => d.Translate('3', 1)).Returns('D');
            dictionary.Setup(d => d.Translate('4', 1)).Returns('G');
            dictionary.Setup(d => d.Translate('5', 1)).Returns('J');

            Assert.That(subject.OldPhonePad(input), Is.EqualTo("ADGJ"));
        }

        [Test]
        [Ignore("Skip due to stabbed functionality")]
        public void OldPhonePad_GivenTest1()
        {
            Assert.That(subject.OldPhonePad("33#"), Is.EqualTo("E"));
        }

        [Test]
        [Ignore("Skip due to stabbed functionality")]
        public void OldPhonePad_GivenTest2() {
            Assert.That(subject.OldPhonePad("227*#"), Is.EqualTo("B"));
        }

        [Test]
        [Ignore("Skip due to stabbed functionality")]
        public void OldPhonePad_GivenTest3() {
            Assert.That(subject.OldPhonePad("4433555 555666#"), Is.EqualTo("HELLO"));
        }

        [Test]
        [Ignore("Skip due to stabbed functionality")]
        public void OldPhonePad_GivenTest4()
        {
            Assert.That(subject.OldPhonePad("8 88777444666*664#"), Is.EqualTo("TURING"));
        }
        #endregion
    }
}
