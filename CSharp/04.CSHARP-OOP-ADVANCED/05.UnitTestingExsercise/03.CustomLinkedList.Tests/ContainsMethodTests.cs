using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList.Tests
{
    [TestFixture]
    public class ContainsMethodTests
    {
        private DynamicList<int> numbers;
        [SetUp]
        public void SetUp()
        {
            numbers = new DynamicList<int>();

            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
        }

        [Test]
        public void ContainsMethodReturnTrueIfFoundItem()
        {
            var expectedResult = numbers.Contains(3);

            Assert.AreEqual(expectedResult, true);
        }

        [Test]
        public void ContainsMethodReturnFalseIfNotFoundItem()
        {
            var expectedResult = numbers.Contains(7);

            Assert.AreEqual(expectedResult, false);
        }
    }
}
