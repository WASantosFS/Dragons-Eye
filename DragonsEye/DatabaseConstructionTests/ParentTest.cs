using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace DatabaseConstructionTests
{
    [TestClass]
    public class ParentTest
    {
        private TransactionScope trans;

        protected string connectionString = "";

        [TestInitialize]
        public void Setup()
        {
            trans = new TransactionScope();

            // Should probably do 6 "inserts" of each to test different Selects, etc.

            // TODO: Insert DayOfYear (int)
            // TODO: Insert Time (int)
            // TODO: Insert Rotors
            // TODO: Insert BetaOrGamma
            // TODO: Insert Reflector
            // TODO: Insert StartingPositions
            // TODO: Insert Offsets
            // TODO: Insert Plugs

        }

        [TestCleanup]
        public void Reset()
        {
            trans.Dispose();
        }
    }
}
