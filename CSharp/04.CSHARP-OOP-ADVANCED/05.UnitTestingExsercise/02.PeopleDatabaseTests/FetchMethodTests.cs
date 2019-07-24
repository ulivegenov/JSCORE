using _02PeopleDatabase;
using NUnit.Framework;
using System.Linq;

namespace DatabaseTests
{
    [TestFixture]
    public class FetchMethodTests
    {
        private Person pesho = new Person("Pesho", 928540956);
        private Person gosho = new Person("Gosho", 7065043560356);
        private Person dimitrichka = new Person("Dimitricka", 437503495);
        private Person palavataClasna = new Person("Palavata_Clasna", 493865);
        private Person chichoGosho = new Person("Chicho_Gosho", 37260);
        private Person selskiyaErgen = new Person("selskiyaErgen", 948375025);
        private Database<Person> database;
        Person[] input = new Person[5];

        [SetUp]
        public void InitializeDatabase()
        {
            Person[] setUp = { this.pesho, this.gosho, this.dimitrichka, this.palavataClasna, this.chichoGosho };
            this.input = setUp;
            this.database = new Database<Person>(input);
        }

        [Test]
        public void FetchMethodAfterCreate()
        {
            Person[] fechResult = this.database.Fetch();

            Assert.That(fechResult.SequenceEqual(input));
        }

        [Test]
        public void FetchMethodAfterAddElement()
        {
            Person elementToAdd = selskiyaErgen;
            this.database.Add(elementToAdd);
            Person[] fetchResult = this.database.Fetch();
            bool IsFetchWorking = (fetchResult[fetchResult.Length - 1] == elementToAdd)
                                  && ((fetchResult.Length - input.Length) == 1);

            Assert.That(IsFetchWorking);
        }

        [Test]
        public void FetchMethoAfterRemovMethod()
        {
            this.database.Remove();
            Person[] fetchResult = this.database.Fetch();
            bool isFetchWorking = (input.Length - fetchResult.Length == 1)
                                   && ((input.Last()) != fetchResult.Last());

            Assert.That(isFetchWorking);
        }
    }
}
