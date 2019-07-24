using _07Hack;
using Moq;
using NUnit.Framework;
using System;

namespace _07HackTests
{
    [TestFixture]
    public class HackTests
    {
        private const double Negative = -20.4;
        private IHack fakeHack = new Hack(Negative);

        [Test]
        public void MathAbsMethodTest()
        {
            Assert.That(() => this.fakeHack.AfterMathAbsValue(), Is.EqualTo(20.4));
        }

        [Test]
        public void AfterMathFloorValueTest()
        {
            Assert.That(() => this.fakeHack.AfterMathFloorValue(), Is.EqualTo(-21));
        }

    }
}
