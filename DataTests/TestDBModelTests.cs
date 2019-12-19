using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tests
{
    [TestClass()]
    public class TestDBModelTests
    {
        [TestMethod()]
        public void TestDBModelTest()
        {
            
        }

        [TestMethod()]
        public void CreateTableTest()
        {
            var test = new TestDBModel();
            var res = test.CreateTable("Test");
            Console.WriteLine(res);
        }
    }
}