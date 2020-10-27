using DragonsEye.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragonsEyeTests
{
    [TestClass]
    public class CryptoUtilitiesTests
    {
        [TestMethod]
        [DataRow("ABCD", "ABCD", "A", "I")]
        [DataRow("ABCD", "BCDA", "Q", "I")]
        [DataRow("ABCD", "ABCD", "A", "IV")]
        [DataRow("ABCD", "BCDA", "J", "IV")]
        public void HasReachedNotchShouldShiftWiringOverOne(string input, string expected, string letter, string rotorType)
        {
            // arrange


            // act
            string result = input.HasReachedNotch(letter, rotorType);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("ABCD", "ABCD", "A", "I")]
        [DataRow("ABCD", "BCDA", "Q", "I")]
        [DataRow("ABCD", "ABCD", "A", "VII")]
        [DataRow("ABCD", "BCDA", "Z", "VII")]
        [DataRow("ABCD", "BCDA", "M", "VII")]
        public void HasReachedNotchShouldHandleEitherOneOrTwoNotches(string input, string expected, string letter, string rotorType)
        {
            // arrange


            // act
            string result = input.HasReachedNotch(letter, rotorType);

            // assert
            Assert.AreEqual(expected, result);
        }
    }
}
