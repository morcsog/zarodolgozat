using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tabla.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabla.Repo.Tests
{
    [TestClass()]
    public class ClassForTestingTests
    {
        [TestMethod()]
        public void getNextTeacherIDTest()
        {
            ClassForTesting cft = new ClassForTesting();
            int actual = cft.getNextTeacherID();
            int expected = 7;
            Assert.AreEqual(actual, expected);
        }
    }
}