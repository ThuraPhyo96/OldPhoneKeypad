using OldPhoneKeypad.Modules;

namespace OldPhoneKeyPadTests.Modules
{
    public class OldPhoneKeyPadTests
    {
        [Fact]
        public void ShouldIgnoreDelaysAndResetKeyPress()
        {
            var keyPad = new OldPhoneKeyPad();
            string input = "222 2 22#";
            string result = keyPad.ConvertToText(input);
            Assert.Equal("CAB", result);
        }

        [Fact]
        public void ShouldConvertNumbersToLetters()
        {
            var keyPad = new OldPhoneKeyPad();
            string input = "33#";
            string result = keyPad.ConvertToText(input);
            Assert.Equal("E", result);
        }

        [Fact]
        public void ShouldHandleBackspace()
        {
            var keyPad = new OldPhoneKeyPad();
            string input = "227*#";
            string result = keyPad.ConvertToText(input);
            Assert.Equal("B", result);
        }

        [Fact]
        public void ShouldHandleMultiKeySequences()
        {
            var keyPad = new OldPhoneKeyPad();
            string input = "4433555 555666096667775553#";
            string result = keyPad.ConvertToText(input);
            Assert.Equal("HELLO WORLD", result);
        }

        [Fact]
        public void ShouldHandleMultiKeySequencesWithBackspace()
        {
            var keyPad = new OldPhoneKeyPad();
            string input = "8 88777444666*664#";
            string result = keyPad.ConvertToText(input);
            Assert.Equal("TURING", result);
        }

        [Fact]
        public void ShouldHandleInvalidInput()
        {
            var keyPad = new OldPhoneKeyPad();
            string input = string.Empty;
            string result = keyPad.ConvertToText(input);
            Assert.Equal(string.Empty, result);
        }
    }
}