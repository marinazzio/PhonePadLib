namespace PhonePadTranslation.Tests
{
    public class PreprocessorTest
    {
        private Preprocessor subject;

        [SetUp]
        public void Setup()
        {
            subject = new Preprocessor();
        }

        [Test]
        public void Preprocess_ThePrimitiveInput_ReturnsInput()
        {
            string input = "222#";
            Assert.That(subject.Preprocess(input), Is.EqualTo(input));
        }

        [Test]
        public void Preprocess_AnyInputEndsWithSharp_ReturnsInput()
        {
            string input = "asidiaw82hj21yh#";
            Assert.That(subject.Preprocess(input), Is.EqualTo(input));
        }

        [Test]
        public void Preprocess_ValidInputWithoutSharp_ReturnsInput()
        {
            string input = "22 2sjd S4$!! 33 3";
            Assert.That(subject.Preprocess(input), Is.EqualTo(input));
        }

        [Test]
        public void Preprocess_InputWithSharpInTheMiddle_CutsOffEverythingAfterSharp()
        {
            string input = "skd fh93s # sdf hk8";
            string expected = "skd fh93s #";

            Assert.That(subject.Preprocess(input), Is.EqualTo(expected));
        }

        [Test]
        public void Preprocess_InputWithSharpAtTheBeginning_ReturnsOnlySharp()
        {
            string input = "#skd fh93s sdf hk8";
            string expected = "#";

            Assert.That(subject.Preprocess(input), Is.EqualTo(expected));
        }

        [Test]
        public void Preprocess_InputWithManySharps_ReturnsInputUpToFirstSharp()
        {
            string input = "skd fh93s # sdf hk8 # 2 3 4 5 6 7 8 9 0";
            string expected = "skd fh93s #";

            Assert.That(subject.Preprocess(input), Is.EqualTo(expected));
        }
    }
}
