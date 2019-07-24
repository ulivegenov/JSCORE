using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IteratorTestTests
{
    [TestFixture]
    public class AtherMethodsTests
    {
        [Test]
        public void MoveMethodSuccessIfThereIsNextElement()
        {
            string input = "Gosho Stamat Petsata";
            IListyIterator listyIterator = new ListyIterator<string>("create", input);

            Assert.That(() => listyIterator.Move(), Is.True);
        }

        [Test]
        public void MoveMethodReturnFalseIfThereIsntNextElement()
        {
            string input = "Petsata";
            IListyIterator listyIterator = new ListyIterator<string>("create", input);

            Assert.That(() => listyIterator.Move(), Is.False);
        }

        [Test]
        public void HasNexMethodSuccessIfThereIsNextElement()
        {
            string input = "Gosho Stamat Petsata";
            IListyIterator listyIterator = new ListyIterator<string>("create", input);

            Assert.That(() => listyIterator.HasNext(), Is.True);
        }

        [Test]
        public void HasNextMethodReturnFalseIfThereIsntNextElement()
        {
            string input = "Petsata";
            IListyIterator listyIterator = new ListyIterator<string>("create", input);

            Assert.That(() => listyIterator.HasNext(), Is.False);
        }

        [Test]
        public void PrintMethodThrowsExeptionIfListyIteratorIsEmpty()
        {
            string input = "Petsata";
            ListyIterator<string> listyIterator = new ListyIterator<string>("create", input);

            IList<string> iteratorsElements = GetIteratorElements(listyIterator);
            iteratorsElements.Clear();

            Assert.Throws<InvalidOperationException>
                                (() => listyIterator.Print(), "Invalid Operation!");
        }

        [Test]
        public void PrintMethodPrintsTheElementOfTheCurrentIndex()
        {
            string input = "Gosho Stamat Petsata";
            IListyIterator listyIterator = new ListyIterator<string>("create", input);

            this.SetCurrentIndex(listyIterator);

            Assert.That(() => listyIterator.Print(), Is.EqualTo("Petsata"));
            
        }

        private void SetCurrentIndex(IListyIterator listyIterator)
        {
            FieldInfo field = typeof(ListyIterator<string>)
                                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                .FirstOrDefault(f => f.FieldType == typeof(int));
            field.SetValue(listyIterator, 2);
        }

        private IList<string> GetIteratorElements(IListyIterator listyIterator)
        {
            FieldInfo field = typeof(ListyIterator<string>)
                                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                .FirstOrDefault(f => f.FieldType == typeof(IList<string>));
            IList<string> instanseField = (IList<string>)field.GetValue(listyIterator);

            return instanseField;
        }
    }
}
