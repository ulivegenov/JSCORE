using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList.Tests
{
    [TestFixture]
    public class AddMethodTests
    {
        [Test]
        public void AddMethodShouldAddElementToList()
        {
            DynamicList<int> dnl = new DynamicList<int>();

            dnl.Add(1);
            dnl.Add(3);

            Assert.That(dnl.Count == 2);
        }
    }
}
