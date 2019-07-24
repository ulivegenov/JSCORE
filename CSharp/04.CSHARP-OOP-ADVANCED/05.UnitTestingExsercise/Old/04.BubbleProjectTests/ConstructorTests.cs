using _04BubbleProject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleProjectTests
{
    [TestFixture]
    class ConstructorTests
    {
        private Bubble bubble;

        [SetUp]
        public void SetUp()
        {
            string input = "5 3 6 1";
            this.bubble = new Bubble(input);
        }

        [Test]
        public void ConstructorCreateSequence()
        {
            Assert.That(this.bubble.elements.Count > 0);
        }

        [Test]
        public void ConstructorSetMaxElement()
        {
            Assert.That(this.bubble.MaxElement, Is.EqualTo(6));
        }

        [Test]
        public void ConstructorSetMinElement()
        {
            Assert.That(this.bubble.MinElement, Is.EqualTo(1));
        }
    }
}
