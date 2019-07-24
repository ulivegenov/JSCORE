using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList.Tests
{
    [TestFixture]
    public class IndexOfMethodTests
    {
        private DynamicList<string> dynamicList;

        [SetUp]
        public void SetUp()
        {
            dynamicList = new DynamicList<string>();
            dynamicList.Add("Pesho");
            dynamicList.Add("Gosho");
        }

        [Test]
        public void IndexOfMethodShouldReturnIndexOfContainingElement()
        {
            var actualResult = dynamicList.IndexOf("Gosho");
            var expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void IndexOfMethodShouldReturnMinusOneIfNotContainingElement()
        {
            var actualResult = dynamicList.IndexOf("Mimeto");
            var expectedResult = -1;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
