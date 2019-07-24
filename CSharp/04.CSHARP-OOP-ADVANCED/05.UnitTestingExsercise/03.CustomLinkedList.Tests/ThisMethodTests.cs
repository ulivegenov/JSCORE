using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList.Tests
{
    [TestFixture]
    public class ThisMethodTests
    {
        private DynamicList<string> names;

        [SetUp]
        public void SetUp()
        {
            names = new DynamicList<string>();

            names.Add("Pepi");
            names.Add("Micheto");
            names.Add("Evlogi");
        }

        [Test]
        public void ThisMethodReturnElementOnDesireIndex()
        {

            Assert.That(names[1] == "Micheto");
        }

        [Test]
        public void ThisMethodSetsNewValueOnGivenIndex()
        {
            names[1] = "Pesho";

            Assert.That(names[1] == "Pesho");
        }

        [Test]
        public void ThisMethodThrowsAnExeptionIfInvalidIndexIsCalling()
        {
            int callingIndex = 5;
            Assert.Throws<ArgumentOutOfRangeException>(() => names[callingIndex] = "Dima" ,
                                                            $"Invalid index: {callingIndex}");
        }
    }
}
