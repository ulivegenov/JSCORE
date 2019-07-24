using _01Database;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseTests
{
    [TestFixture]
    public class FetchMethodTests
    {
        private int[] input = { 1, 2, 3, 4, 5 };
        private Database<int> database;
        [SetUp]
        public void InitializeDatabase()
        {     
            this.database = new Database<int>(input);
        }

        [Test]
        public void FetchMethodAfterCreate()
        {
            int[] fechResult = this.database.Fetch();

            Assert.That(fechResult.SequenceEqual(input));
        }

        [TestCase(0)]
        [TestCase(200)]
        [TestCase(-5)]
        [TestCase(1)]
        public void FetchMethodAfterAddElement(int elementToAdd)
        {
            this.database.Add(elementToAdd);
            int[] fetchResult = this.database.Fetch();
            bool IsFetchWorking = (fetchResult[fetchResult.Length - 1] == elementToAdd)
                                  && ((fetchResult.Length - input.Length) == 1);

            Assert.That(IsFetchWorking);
        }

        [Test]
        public void FetchMethoAfterRemovMethod()
        {
            this.database.Remove();
            int[] fetchResult = this.database.Fetch();
            bool isFetchWorking = (input.Length - fetchResult.Length == 1)
                                   && ((input.Sum() - fetchResult.Sum()) == input[input.Length - 1]);

            Assert.That(isFetchWorking);
        }
    }
}
