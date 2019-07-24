using NUnit.Framework;
using NUnit.Framework.Internal;
using StorageMaster;
using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class VehicleTests
    {
        private Type vehicle;

        [SetUp]
        public void SetUp()
        {
            this.vehicle = this.GetType("Vehicle");
        }

        [Test]
        public void ValidateAllVehicle()
        {
            var types = new[]
            {
                "Semi",
                "Truck",
                "Van",
                "Vehicle"

            };
            foreach (var type in types)
            {
                var currentType = GetType(type);
                Assert.That(currentType.Name, Is.EqualTo(type), "doesn't exists");
            }
        }

        [Test]
        public void ValidateVehicleConstructor()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;
            var constructor = this.vehicle.GetConstructors(flags).FirstOrDefault();
            Assert.That(constructor, Is.Not.Null);
            var constructorsParameters = constructor.GetParameters();
            Assert.That(constructorsParameters[0].ParameterType, Is.EqualTo(typeof(int)));
        }

        [Test]
        public void ValidateVehicleChildClasses()
        {
            var derivateTypes = new[]
            {
                GetType("Semi"),
                GetType("Truck"),
                GetType("Van")
            };
            foreach (var derivateType in derivateTypes)
            {
                Assert.That(derivateType.BaseType, Is.EqualTo(vehicle), "doesn't inheritage");
            }
        }

        [Test]
        public void ValidateVehicleProperties()
        {
            var actualProperties = vehicle.GetProperties();

            var expectedProperties = new Dictionary<string, Type>();
            expectedProperties.Add("Capacity", typeof(int));
            expectedProperties.Add("Trunk", typeof(IReadOnlyCollection<Product>));
            expectedProperties.Add("IsFull", typeof(bool));
            expectedProperties.Add("IsEmpty", typeof(bool));

            foreach (var actualProperty in actualProperties)
            {
                var propertyExist = expectedProperties.Any(x => x.Key == actualProperty.Name && x.Value == actualProperty.PropertyType);
                Assert.That(propertyExist, $"{actualProperty.Name} doesn't exists!");
            }
        }

        [Test]
        public void ValidateVehicleMethods()
        {
            var expectedMethods = new List<Method>
            {
                new Method(typeof(void), "LoadProduct", typeof(Product)),
                new Method(typeof(Product), "Unload")
            };
            var actualMethods = vehicle.GetMethods();

            foreach (var expectedMethod in expectedMethods)
            {
                var currentMethod = vehicle.GetMethod(expectedMethod.Name);
                Assert.That(currentMethod, Is.Not.Null);
                var currentMethodReturnType = expectedMethod.ReturnaType == currentMethod.ReturnType;
                Assert.That(currentMethodReturnType);

                var expectedMethodParams = expectedMethod.InputParameters;
                var actualParams = currentMethod.GetParameters();

                for (int i = 0; i < expectedMethodParams.Length; i++)
                {
                    var actParam = actualParams[i].ParameterType;
                    var expectParams = expectedMethodParams[i];
                    Assert.AreEqual(expectParams, actParam);
                }
            }
        }

        [Test]
        public void ValidateVehicleIsAbstract()
        {
            Assert.That(vehicle.IsAbstract, "Vehicle must be abstract");
        }

        [Test]
        public void ValidateVehicleFields()
        {
            var trunkField = vehicle.GetField("trunk", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(trunkField, Is.Not.Null, "Invalid field");
        }
        private Type GetType(string type)
        {
            var targetsType = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);
            return targetsType;
        }

        private class Method
        {
            public Method(Type returnaType, string name, params Type[] inputParameters)
            {
                this.ReturnaType = returnaType;
                this.Name = name;
                this.InputParameters = inputParameters;
            }

            public Type ReturnaType { get; set; }

            public string Name { get; set; }

            public Type[] InputParameters { get; set; }
        }
    }
}
