namespace StorageMester.BusinessLogic.Tests
{
    using NUnit.Framework;
    using StorageMaster;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Storage;
    using StorageMaster.Entities.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using StorageMaster.Core;
   

    [TestFixture]
    public class StorageMasterTests
    {
        private Type storageMaster;

        [SetUp]
        public void SetUp()
        {
            this.storageMaster = this.GetType("StorageMaster");
        }
        //CheckIfClassExist()
        [Test]
        public void CheckIfClassExist()
        {
            Assert.That("StorageMaster", Is.EqualTo(storageMaster.Name));
        }
        //TestFields 
        [Test]
        public void TestFields()
        {
            var storageRegistry = storageMaster.GetField("storageRegistry", BindingFlags.NonPublic | BindingFlags.Instance);
            var productsPool = storageMaster.GetField("productsPool", BindingFlags.NonPublic | BindingFlags.Instance);
            var productFactory = storageMaster.GetField("productFactory", BindingFlags.NonPublic | BindingFlags.Instance);
            var storageFactory = storageMaster.GetField("storageFactory", BindingFlags.NonPublic | BindingFlags.Instance);
            var currentVehicle = storageMaster.GetField("currentVehicle", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(storageRegistry.IsInitOnly, Is.True);
            Assert.That(productsPool.IsInitOnly, Is.True);
            Assert.That(productFactory.IsInitOnly, Is.True);
            Assert.That(storageFactory.IsInitOnly, Is.True);
            Assert.That(currentVehicle, Is.Not.Null);
        }
        //TestConstruct
        [Test]
        public void TestConstruct() => Assert.DoesNotThrow(() => new StorageMaster());
        //TestRegister
        [Test]
        public void TestRegister()
        {
            StorageMaster storageMaster = new StorageMaster();
            var temp = storageMaster.RegisterStorage("Warehouse", "Pesho");
            Assert.That($"Registered Pesho", Is.EqualTo(temp));
        }
        [Test]
        public void ValidateGetSummary()
        {
            StorageMaster storage = new StorageMaster();
            storage.RegisterStorage("Warehouse", "Nikolai");
            var printSummary = storage.GetSummary();
            var expectedSummary = "Nikolai:\r\nStorage worth: $0.00";
            Assert.AreEqual(printSummary, expectedSummary);

        }
        [Test]
        public void ValidateSelectVehicle()
        {
            StorageMaster storageMaster = new StorageMaster();
            storageMaster.RegisterStorage("DistributionCenter", "Pepi");
            Assert.AreEqual("Selected Van", (storageMaster.SelectVehicle("Pepi", 0)));
        }
        [Test]
        public void ValidateSendVehicleToMethod()
        {

            var registerStorageMethod = storageMaster.GetMethod("RegisterStorage");
            var instance = Activator.CreateInstance(storageMaster);

            var firstStorageType = "DistributionCenter";
            var firstName = "Gosho";

            var secondStorageType = "AutomatedWarehouse";
            var secondName = "Pesho";

            registerStorageMethod.Invoke(instance, new object[] { firstStorageType, firstName });
            registerStorageMethod.Invoke(instance, new object[] { secondStorageType, secondName });

            var actualResult = storageMaster.GetMethod("SendVehicleTo")
                .Invoke(instance, new object[] { "Gosho", 1, "Pesho" });

            var expectedResult = "Sent Van to Pesho (slot 1)";
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ValidateRegisterStorageMethod()
        {
            var registerStorageMethod = storageMaster.GetMethod("RegisterStorage");
            var instance = Activator.CreateInstance(storageMaster);
            var storageType = "DistributionCenter";
            var name = "Gosho";
            var result = registerStorageMethod.Invoke(instance, new object[] { storageType, name });
            var expectedResult = $"Registered {name}";
            Assert.AreEqual(result, expectedResult);

            var storageRegistry = (IDictionary<string, Storage>)storageMaster.GetField("storageRegistry", (BindingFlags)62).GetValue(instance);

            Assert.That(storageRegistry[name].Name, Is.EqualTo(name));
        }
        [Test]
        public void ValidateAddProductFirst()
        {
            var addProductMethod = storageMaster.GetMethod("AddProduct");
            var instance = Activator.CreateInstance(storageMaster);
            string productType = "SolidStateDrive";
            double price = 230.4;
            var actualResult = addProductMethod.Invoke(instance, new object[] { productType, price });
            var expectedResult = $"Added SolidStateDrive to pool";
            Assert.AreEqual(actualResult, expectedResult);
            var productsPoolField = (IDictionary<string, Stack<Product>>)storageMaster.GetField("productsPool", (BindingFlags)62).GetValue(instance);
            Assert.That(productsPoolField[productType].Count, Is.EqualTo(1));
        }
        [Test]
        public void ValidateAddProductSecond()
        {
            StorageMaster storageMaster = new StorageMaster();
            var tempAddProduct = storageMaster.AddProduct("Ram", 1159);
            var expctedAddProduct = "Added Ram to pool";
            Assert.AreEqual(tempAddProduct, expctedAddProduct);
        }

        [Test]
        public void ValidateLoadVehicle()
        {
            StorageMaster storageMaster = new StorageMaster();
            storageMaster.RegisterStorage("Warehouse", "Pepi");
            storageMaster.SelectVehicle("Pepi", 0);
            storageMaster.AddProduct("Ram", 0.2);
            var temp = storageMaster.LoadVehicle(new string[] { "Ram" });
            Assert.That(temp, Is.EqualTo("Loaded 1/1 products into Semi"));

        }
        [Test]
        public void ValidateLoadVehicleIE()
        {
            StorageMaster storageMaster = new StorageMaster();
            storageMaster.RegisterStorage("Warehouse", "Pepi");
            storageMaster.SelectVehicle("Pepi", 0);
            var temp = (new string[] { "Ram" });
            Assert.Throws<InvalidOperationException>(() => storageMaster.LoadVehicle(temp));
        }

        [Test]
        public void ValidateGetStorageStatus()
        {
            StorageMaster storage = new StorageMaster();
            var name = "Pepi";
            storage.RegisterStorage("Warehouse", name);
            var temp = storage.GetStorageStatus(name);
            var expectedValue =
                "Stock (0/10): []\r\nGarage: [Semi|Semi|Semi|empty|empty|empty|empty|empty|empty|empty]";
            Assert.That(temp, Is.EqualTo(expectedValue));
        }
        private Type GetType(string type)
        {
            var targetsType = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);
            return targetsType;
        }
    }
}
