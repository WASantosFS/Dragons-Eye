using DragonsEye;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragonsEyeTests
{
    [TestClass]
    public class FormattingTests
    {
        //{" ", "!", "?", "'", ":", ";", "(", ")", "-", ",", "."};
        //{"YX", "XD", "YD", "ZD", "XX", "XY", "KKA", "KKB", "YY", "ZZ", "XZ"};

        [TestMethod]
        [DataRow("HELLO WORLD", "HELLOYXWORLD")]
        [DataRow("(HOW'RE YOU?)", "KKAHOWZDREYXYOUYDKKB")]
        [DataRow("YES.", "YESXZ")]
        public void FormatShouldReplaceSymbolsWithLetters(string input, string expected)
        {
            // arrange
            Formatting formatting = new Formatting();

            // act
            string result = formatting.Format(input, false);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("HELLOYXWORLD", "HELLO WORLD")]
        [DataRow("KKAHOWZDREYXYOUYDKKB", "(HOW'RE YOU?)")]
        [DataRow("YESXZ", "YES.")]
        public void FormatShouldReplaceLettersWithSymbols(string input, string expected)
        {
            // arrange
            Formatting formatting = new Formatting();

            // act
            string result = formatting.Format(input, true);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("ABCDEFGH", "ABCD EFGH")]
        public void GroupingShouldGroupLettersIntoFours(string input, string expected)
        {
            // arrange
            Formatting formatting = new Formatting();

            // act
            string result = formatting.Grouping(input);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("ABCDEFGH", "ABCD EFGH")]
        [DataRow("ABCDEFGHI", "ABCD EFGH I")]
        [DataRow("ABCDEFGHIJ", "ABCD EFGH IJ")]
        [DataRow("ABCDEFGHIJK", "ABCD EFGH IJK")]
        public void GroupingShouldGroupLettersIntoFoursAndHandleSplitGroups(string input, string expected)
        {
            // arrange
            Formatting formatting = new Formatting();

            // act
            string result = formatting.Grouping(input);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("ABCD EFGH", "ABCDEFGH")]
        [DataRow("ABCD EFGH I", "ABCDEFGHI")]
        [DataRow("ABCD EFGH IJ", "ABCDEFGHIJ")]
        [DataRow("ABCD EFGH IJK", "ABCDEFGHIJK")]
        public void DegroupingShouldRemoveSpaces(string input, string expected)
        {
            // arrange
            Formatting formatting = new Formatting();

            // act
            string result = formatting.Degrouping(input);

            // assert
            Assert.AreEqual(expected, result);
        }
    }
}
