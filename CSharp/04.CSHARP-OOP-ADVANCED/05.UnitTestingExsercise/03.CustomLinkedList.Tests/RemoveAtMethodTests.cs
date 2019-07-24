using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList.Tests
{
    [TestFixture]
    public class RemoveAtMethodTests
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
        public void RemoveAtMethodShouldRemoveElementAtCallingIndex()
        {
            dynamicList.RemoveAt(0);

            Assert.That(dynamicList[0] != "Pesho");
        }

        [Test]
        public void RemoveAtMethodShouldReturnRemovedElement()
        {
            var actualResult = dynamicList.RemoveAt(1);
            var expectedResult = "Gosho";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveMethodShouldThrowsExeptionIfInvalidIndexIsCalling()
        {
            int callingIndex = 5;

            Assert.Throws<ArgumentOutOfRangeException>(() => dynamicList.RemoveAt(callingIndex),
                                                                $"Invalid index: {callingIndex}");
        }
    }
}
