using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList.Tests
{
    [TestFixture]
    public class RemoveMethodTests
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
        public void RemoveMethodShouldReturnIndexOfElementToRemove()
        {
            var actualResult = dynamicList.Remove("Pesho");
            var expectedResult = 0;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveMethodShouldReturnMinusOneIfNotContainsElementToRemove()
        {
            var actualResult = dynamicList.Remove("Getsata");
            var expectedResult = -1;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveMethodShouldRemoveElementToRemove()
        {
            dynamicList.Remove("Pesho");

            Assert.That(dynamicList[0] != "Pesho");
        }
    }
}
