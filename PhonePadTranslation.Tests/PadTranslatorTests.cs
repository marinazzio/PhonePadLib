using Moq;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PhonePadTranslation.Tests
{
    public class PadTranslatorTests
    {
        private PadTranslator subject;
        private Mock<IPadValidator> inputValidator;
        private Mock<IPreprocessor> preprocessor;
        private Mock<IParser> parser;
        private Mock<IDictionary> dictionary;

        [SetUp]
        public void Setup()
        {
            preprocessor = new Mock<IPreprocessor>();
            inputValidator = new Mock<IPadValidator>();
            parser = new Mock<IParser>();
            dictionary = new Mock<IDictionary>();

            setupStubs();

            subject = new PadTranslator(
                preprocessor.Object,
                inputValidator.Object,
                parser.Object,
                dictionary.Object
            );
        }

        private void setupStubs()
        {
            preprocessor
                .Setup(p => p.Preprocess(It.IsAny<string>()))
                .Returns((string s) => s);

            inputValidator
                .Setup(p => p.ValidatePadInput(It.IsAny<string>()));

            parser
                .Setup(p => p.Parse(It.IsAny<string>()))
                .Returns((string s) => stubParserResponse(s));
        }

        private void setupSequence()
        {
            var sequence = new MockSequence();

            preprocessor
                .InSequence(sequence)
                .Setup(p => p.Preprocess(It.IsAny<string>()))
                .Returns((string s) => s);

            inputValidator
                .InSequence(sequence)
                .Setup(v => v.ValidatePadInput(It.IsAny<string>()));

            parser
                .InSequence(sequence)
                .Setup(p => p.Parse(It.IsAny<string>()))
                .Returns((string s) => stubParserResponse(s));

            dictionary
                .InSequence(sequence)
                .Setup(d => d.Translate(It.IsAny<char>(), It.IsAny<int>()))
                .Returns('C');
        }

        private List<Tuple<char, int>> stubParserResponse(string s)
        {
            return
                Regex
                    .Matches(s, @"([\w*])\1*|\s+")
                    .ToList()
                    .Aggregate(
                        new List<Tuple<char, int>>(),
                        (acc, match) =>
                        {
                            var value = match.Value;
                            var count = value.Length;

                            if (value == "*")
                            {
                                try
                                {
                                    acc.RemoveAt(acc.Count - 1);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    // Ignore
                                }
                            }
                            else if (value != " ")
                            {
                                acc.Add(new Tuple<char, int>(value[0], count));
                            }

                            return acc;
                        }
                    );
        }

        #region Workflow
        [Test]
        public void OldPhonePad_ShouldCallMethodsInCorrectOrder()
        {
            setupSequence();

            dictionary.Setup(d => d.Translate('2', 3)).Returns('C');

            subject.OldPhonePad("222#");

            preprocessor.Verify(p => p.Preprocess(It.IsAny<string>()), Times.Once);
            inputValidator.Verify(validator => validator.ValidatePadInput(It.IsAny<string>()), Times.Once);
            parser.Verify(p => p.Parse(It.IsAny<string>()), Times.Once);
            dictionary.Verify(d => d.Translate(It.IsAny<char>(), It.IsAny<int>()), Times.AtLeastOnce);
        }
        #endregion

        #region Translation
        [Test]
        public void OldPhonePad_TranslatesOneChar()
        {
            dictionary.Setup(d => d.Translate('2', 3)).Returns('C');

            Assert.That(subject.OldPhonePad("222#"), Is.EqualTo("C"));
        }

        [Test]
        public void OldPhonePad_TranslatesMultipleChars()
        {
            dictionary.Setup(d => d.Translate('2', 1)).Returns('A');
            dictionary.Setup(d => d.Translate('3', 1)).Returns('D');
            dictionary.Setup(d => d.Translate('4', 1)).Returns('G');
            dictionary.Setup(d => d.Translate('5', 1)).Returns('J');

            Assert.That(subject.OldPhonePad("2345#"), Is.EqualTo("ADGJ"));
        }

        [Test]
        public void OldPhonePad_GivenTest1()
        {
            dictionary.Setup(d => d.Translate('3', 2)).Returns('E');

            Assert.That(subject.OldPhonePad("33#"), Is.EqualTo("E"));
        }

        [Test]
        public void OldPhonePad_GivenTest2()
        {
            dictionary.Setup(d => d.Translate('2', 2)).Returns('B');

            Assert.That(subject.OldPhonePad("227*#"), Is.EqualTo("B"));
        }

        [Test]
        public void OldPhonePad_GivenTest3()
        {
            dictionary.Setup(d => d.Translate('3', 2)).Returns('E');
            dictionary.Setup(d => d.Translate('4', 2)).Returns('H');
            dictionary.Setup(d => d.Translate('5', 3)).Returns('L');
            dictionary.Setup(d => d.Translate('6', 3)).Returns('O');

            Assert.That(subject.OldPhonePad("4433555 555666#"), Is.EqualTo("HELLO"));
        }

        [Test]
        public void OldPhonePad_GivenTest4()
        {
            dictionary.Setup(d => d.Translate('4', 1)).Returns('G');
            dictionary.Setup(d => d.Translate('4', 3)).Returns('I');
            dictionary.Setup(d => d.Translate('6', 2)).Returns('N');
            dictionary.Setup(d => d.Translate('7', 3)).Returns('R');
            dictionary.Setup(d => d.Translate('8', 1)).Returns('T');
            dictionary.Setup(d => d.Translate('8', 2)).Returns('U');

            Assert.That(subject.OldPhonePad("8 88777444666*664#"), Is.EqualTo("TURING"));
        }
        #endregion
    }
}
