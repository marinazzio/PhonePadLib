using Moq;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PhonePadTranslation.Tests
{
    public class PadTranslatorTests
    {
        private PadTranslator subject;
        private Mock<IPadInputValidator> inputValidator;
        private Mock<IPadInputPreprocessor> preprocessor;
        private Mock<IPadInputParser> parser;
        private Mock<IPadDictionary> dictionary;

        private static readonly Dictionary<(char, int), char> mockedDictionary = new Dictionary<(char, int), char>
        {
            { ('2', 1), 'A' },
            { ('2', 2), 'B' },
            { ('2', 3), 'C' },

            { ('3', 1), 'D' },
            { ('3', 2), 'E' },

            { ('4', 1), 'G' },
            { ('4', 2), 'H' },
            { ('4', 3), 'I' },

            { ('5', 1), 'J' },
            { ('5', 3), 'L' },

            { ('6', 2), 'N' },
            { ('6', 3), 'O' },

            { ('7', 3), 'R' },

            { ('8', 1), 'T' },
            { ('8', 2), 'U' }
        };

        [SetUp]
        public void Setup()
        {
            preprocessor = new Mock<IPadInputPreprocessor>();
            inputValidator = new Mock<IPadInputValidator>();
            parser = new Mock<IPadInputParser>();
            dictionary = new Mock<IPadDictionary>();

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

        private List<(char, int)> stubParserResponse(string s)
        {
            return
                Regex
                    .Matches(s, @"([\w*])\1*|\s+")
                    .ToList()
                    .Aggregate(
                        new List<(char, int)>(),
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
                                acc.Add((value[0], count));
                            }

                            return acc;
                        }
                    );
        }

        private void stubDictionaryByList(List<(char, int)> list)
        {
            list.ForEach(tuple =>
            {
                dictionary
                    .Setup(d => d.Translate(tuple.Item1, tuple.Item2))
                    .Returns(mockedDictionary[(tuple.Item1, tuple.Item2)]);
            });
        }

        #region Workflow
        [Test]
        public void OldPhonePad_ShouldCallMethodsInCorrectOrder()
        {
            setupSequence();

            stubDictionaryByList(new List<(char, int)> { ('2', 3) });

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
            stubDictionaryByList(new List<(char, int)> { ('2', 3) });

            Assert.That(subject.OldPhonePad("222#"), Is.EqualTo("C"));
        }

        [Test]
        public void OldPhonePad_TranslatesMultipleChars()
        {
            stubDictionaryByList(new List<(char, int)> { ('2', 1), ('3', 1), ('4', 1), ('5', 1) });

            Assert.That(subject.OldPhonePad("2345#"), Is.EqualTo("ADGJ"));
        }

        [Test]
        public void OldPhonePad_GivenTest1()
        {
            stubDictionaryByList(new List<(char, int)> { ('3', 2) });

            Assert.That(subject.OldPhonePad("33#"), Is.EqualTo("E"));
        }

        [Test]
        public void OldPhonePad_GivenTest2()
        {
            stubDictionaryByList(new List<(char, int)> { ('2', 2) });

            Assert.That(subject.OldPhonePad("227*#"), Is.EqualTo("B"));
        }

        [Test]
        public void OldPhonePad_GivenTest3()
        {
            stubDictionaryByList(new List<(char, int)> { ('3', 2), ('4', 2), ('5', 3), ('6', 3) });

            Assert.That(subject.OldPhonePad("4433555 555666#"), Is.EqualTo("HELLO"));
        }

        [Test]
        public void OldPhonePad_GivenTest4()
        {
            stubDictionaryByList(new List<(char, int)> { ('4', 1), ('4', 3), ('6', 2), ('7', 3), ('8', 1), ('8', 2) });

            Assert.That(subject.OldPhonePad("8 88777444666*664#"), Is.EqualTo("TURING"));
        }
        #endregion
    }
}
