using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace testsForTestStuff
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, 1.5);
        }
    }
}
