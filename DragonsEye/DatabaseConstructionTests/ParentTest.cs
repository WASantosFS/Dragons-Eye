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
        }

        [TestCleanup]
        public void Reset()
        {
            trans.Dispose();
        }
    }
}
