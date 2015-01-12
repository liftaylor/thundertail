using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestStuff;

namespace testsForTestStuff
{
    [TestFixture]
    public class Test_class
    {
        [Test] //开始测试
        public void AddTest()
        {
            var org_add_class = new Original_class();
            var result = org_add_class.add(2, 5); //加法class里的function，这里设为2+5
            Assert.AreEqual(7, result);  // 对比运算结果
        }

        [Test] //第二个测试，测试如果结果和正确值不符的情况
        public void False_AddTest()
        {
            var org_add_class = new Original_class();
            var result = org_add_class.add(-5, 5);  //result=0 
            Assert.AreEqual(7, result);  //对比7和result的值
        }
    } 
}
