using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonsEye;

namespace DragonsEyeTests
{
    [TestClass]
    public class DragonsEyeTests
    {
        /*[TestMethod]
        public void LinkShouldWork()
        {
            // arrange
            Crypto crypto = new Crypto();

            // act
            string result = crypto.Encryption("Hello World", "A");

            // assert
            Assert.AreEqual("Hello World", result);
        }

        [TestMethod]
        [DataRow("A","E")]
        [DataRow("Z", "J")]
        [DataRow("L", "T")]
        public void EncryptionShouldAccessEncodingString(string input, string expected)
        {
            // arrange
            Crypto crypto = new Crypto();

            // act
            string result = crypto.Encryption(input, "A"); 

            // assert
            Assert.AreEqual(expected, result);
        }

        // ABCDEFGHIJKLMNOPQRSTUVWXYZ
        // EKMFLGDQVZNTOWYHXUSPAIBRCJ

        [TestMethod]
        [DataRow("ACE", "EML")]
        [DataRow("ZRM", "JUO")]
        [DataRow("LKW", "TNB")]
        public void EncryptionShouldBuildAString(string input, string expected)
        {
            // arrange
            Crypto crypto = new Crypto();

            // act
            string result = crypto.Encryption(input, "A");

            // assert
            Assert.AreEqual(expected, result);
        }

        // ABCDEFGHIJKLMNOPQRSTUVWXYZ  --  Alphabet
        // EKMFLGDQVZNTOWYHXUSPAIBRCJ  --  Wiring
        // YRUHQSLDPXNGOKMIEBFZCWVJAT  --  Reflector

        [TestMethod]
        [DataRow("ACE", "QOG")]
        [DataRow("ZRM", "XCM")]
        [DataRow("LKW", "ZKR")]
        public void EncryptionShouldBuildAStringWithReflector(string input, string expected)
        {
            // arrange
            Crypto crypto = new Crypto();

            // act
            string result = crypto.Encryption(input, "A");

            // assert
            Assert.AreEqual(expected, result);
        }

        // ABCDEFGHIJKLMNOPQRSTUVWXYZ  --  Alphabet
        // EKMFLGDQVZNTOWYHXUSPAIBRCJ  --  Wiring
        // YRUHQSLDPXNGOKMIEBFZCWVJAT  --  Reflector

        [TestMethod]
        [DataRow("ACE", "HMF")]
        [DataRow("ZRM", "QYC")]
        [DataRow("LKW", "JBX")]
        public void EncryptionShouldGoBackwardThroughReflector(string input, string expected)
        {
            // arrange
            Crypto crypto = new Crypto();

            // act
            string result = crypto.Encryption(input, "A");

            // assert
            Assert.AreEqual(expected, result);
        }

        // ABCDEFGHIJKLMNOPQRSTUVWXYZ  --  Alphabet
        // EKMFLGDQVZNTOWYHXUSPAIBRCJ  --  Wiring
        // YRUHQSLDPXNGOKMIEBFZCWVJAT  --  Reflector

        [TestMethod]
        [DataRow("ACE", "HMF")]
        [DataRow("HMF","ACE")]
        [DataRow("ZRM", "QYC")]
        [DataRow("QYC","ZRM")]
        [DataRow("LKW", "JBX")]
        [DataRow("JBX","LKW")]
        public void EncryptionShouldEncipherAndDecipher(string input, string expected)
        {
            // arrange
            Crypto crypto = new Crypto();

            // act
            string result = crypto.Encryption(input, "A");

            // assert
            Assert.AreEqual(expected, result);
        }

        // ABCDEFGHIJKLMNOPQRSTUVWXYZ  --  Alphabet
        // EKMFLGDQVZNTOWYHXUSPAIBRCJ  --  Wiring
        // YRUHQSLDPXNGOKMIEBFZCWVJAT  --  Reflector

        [TestMethod]
        [DataRow("EKMFLGDQVZNTOWYHXUSPAIBRCJ", "KMFLGDQVZNTOWYHXUSPAIBRCJE")]
        public void ShiftShouldShiftWiringOneToLeftAndAppendToEnd(string input, string expected)
        {
            // arrange
            Crypto crypto = new Crypto();

            // act
            //string result = crypto.Shift(input); -- Had to comment out due to proceeding test causing errors.

            // assert
            //Assert.AreEqual(expected, result);
        }

        // ABCDEFGHIJKLMNOPQRSTUVWXYZ  --  Alphabet
        // EKMFLGDQVZNTOWYHXUSPAIBRCJ  --  Wiring
        // YRUHQSLDPXNGOKMIEBFZCWVJAT  --  Reflector

        [TestMethod]
        [DataRow("EKMFLGDQVZNTOWYHXUSPAIBRCJ", "B", "KMFLGDQVZNTOWYHXUSPAIBRCJE")]
        [DataRow("EKMFLGDQVZNTOWYHXUSPAIBRCJ", "J", "ZNTOWYHXUSPAIBRCJEKMFLGDQV")]
        [DataRow("EKMFLGDQVZNTOWYHXUSPAIBRCJ", "T", "PAIBRCJEKMFLGDQVZNTOWYHXUS")]
        [DataRow("EKMFLGDQVZNTOWYHXUSPAIBRCJ", "Z", "JEKMFLGDQVZNTOWYHXUSPAIBRC")]
        public void ShiftShouldShiftWiringOneOrManyLeftAndAppendToEnd(string input, string ringPos, string expected)
        {
            // arrange
            Crypto crypto = new Crypto();

            // act
            string result = crypto.Shift(input, ringPos);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("EKMFLGDQVZNTOWYHXUSPAIBRCJ", "A", "EKMFLGDQVZNTOWYHXUSPAIBRCJ")]
        [DataRow("EKMFLGDQVZNTOWYHXUSPAIBRCJ", "B", "KMFLGDQVZNTOWYHXUSPAIBRCJE")]
        [DataRow("EKMFLGDQVZNTOWYHXUSPAIBRCJ", "J", "ZNTOWYHXUSPAIBRCJEKMFLGDQV")]
        [DataRow("EKMFLGDQVZNTOWYHXUSPAIBRCJ", "T", "PAIBRCJEKMFLGDQVZNTOWYHXUS")]
        [DataRow("EKMFLGDQVZNTOWYHXUSPAIBRCJ", "Z", "JEKMFLGDQVZNTOWYHXUSPAIBRC")]
        public void ShiftShouldShiftWiringNoneOrManyLeftAndAppendToEnd(string input, string ringPos, string expected)
        {
            // arrange
            Crypto crypto = new Crypto();

            // act
            string result = crypto.Shift(input, ringPos);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("ACE", "A", "HMF")]
        [DataRow("ZRM", "B", "GCH")]
        [DataRow("LKW", "J", "FMV")]
        public void EncryptionShouldEncipherShiftedEncodingString(string input, string ringPos, string expected)
        {
            // arrange
            Crypto crypto = new Crypto();

            // act
            string result = crypto.Encryption(input, ringPos);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("ACE", "A", "HRN")]
        [DataRow("ZRM", "A", "QCS")]
        [DataRow("LKW", "A", "JIP")]
        public void EncryptionShouldShiftUpWithEachLetterEnciphered(string input, string ringPos, string expected)
        {
            // arrange
            Crypto crypto = new Crypto();

            // act
            string result = crypto.Encryption(input, ringPos);

            // assert
            Assert.AreEqual(expected, result);
        }*/

        //{" ", "!", "?", "'", ":", ";", "(", ")", "-", ",", "."};
        //{"YX", "XD", "YD", "ZD", "XX", "XY", "KKA", "KKB", "YY", "ZZ", "XZ"};

        [TestMethod]
        [DataRow(" ", "YX")]
        [DataRow("(", "KKA")]
        [DataRow(".", "XZ")]
        public void FormatShouldReplaceSymbolsWithLetters(string input, string expected)
        {
            // arrange
            Formatting formatting = new Formatting();

            // act
            string result = formatting.Format(input);

            // assert
            Assert.AreEqual(expected, result);
        }
    }
}
