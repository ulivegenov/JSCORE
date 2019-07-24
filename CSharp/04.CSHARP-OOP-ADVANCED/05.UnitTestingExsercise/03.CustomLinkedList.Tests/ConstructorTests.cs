using NUnit.Framework;
using System;

namespace CustomLinkedList.Tests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void ConstructorShouldInitializeListWithZeroCount()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            Assert.AreEqual(0, dynamicList.Count);
        }
    }
}
