using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IteratorTestTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void ConstructorThrowsExeptionIfInputIsNull()
        {
            string input = default(string);

            Assert.Throws<ArgumentNullException>(() => new ListyIterator<string>("create", input),
                                                    "Invalid Operation!");
        }

        [Test]
        public void ConstructorCreateList()
        {
            string inputParams = "Gosho Stamat Petsata";
            int inputParamsCount = (inputParams.Split()).Length;
            Type type = typeof(ListyIterator<string>);
            ListyIterator<string> instance = (ListyIterator<string>)Activator
                                         .CreateInstance(type, new object[] { "create", inputParams });

            FieldInfo field = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                   .FirstOrDefault(f => f.FieldType == (typeof(IList<string>)));
            IList<string> instanceField = (IList<string>)field.GetValue(instance);

            Assert.That(instanceField.Count == inputParamsCount);
        }
    }
}
