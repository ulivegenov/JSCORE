using NUnit.Framework;
using System;
using _04BubbleProject;

namespace BubbleProjectTests
{
    [TestFixture]
    public class BubbleSortMethodTests
    {
        private Bubble bubble;
        [SetUp]
        public void Setup()
        {
            string input = "4 8 2 4 5 3 1 7 6";
            this.bubble = new Bubble(input);
        }
        [Test]
        public void BubbleSortMethodSetsMaxElementLast()
        {
            this.bubble.BubbleSort();
            int bubbleLaststElement = bubble.elements[bubble.elements.Count - 1];

            Assert.That(bubbleLaststElement, Is.EqualTo(bubble.MaxElement));
        }

        [Test]
        public void BubbleSortMethodSetsMinElementFirst()
        {
            this.bubble.BubbleSort();
            int bubbleFirstElement = bubble.elements[0];

            Assert.That(bubbleFirstElement, Is.EqualTo(bubble.MinElement));
        }
    }
}
