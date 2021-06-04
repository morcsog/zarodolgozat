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
    public class RepositoryTests
    {
        [TestMethod()]
        public void getDiakIDTest()
        {
            Repository repo = new Repository();
            int actual = repo.getDiakID("Kovács János");
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }
    }
}