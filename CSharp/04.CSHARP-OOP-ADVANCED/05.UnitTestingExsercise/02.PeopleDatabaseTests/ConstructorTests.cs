
using _02PeopleDatabase;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;


namespace DatabaseTests
{
    [TestFixture]
    public class ConstructorTests
    {
        private Person pesho = new Person("Pesho", 928540956);
        private Person gosho = new Person("Gosho", 7065043560356);
        private Person dimitrichka = new Person("Dimitricka", 437503495);
        private Person palavataClasna = new Person("Palavata_Clasna", 493865);
        private Person chichoGosho = new Person("Chicho_Gosho", 37260);

        private Person selskiyaErgen = new Person("selskiyaErgen", 948375025);
        private Person spiro = new Person("Spiro", 942385);
        private Person spiridon = new Person("Spiridon", 43853029);
        private Person stamat = new Person("Stamat", 3928744356);
        private Person pasha = new Person("Pasha", 094385035);

        private Person siyka = new Person("Siyka", 09437560395);
        private Person gichka = new Person("Gichka", 0439875033728);
        private Person selskiBek = new Person("SelskiBek", 934087532);
        private Person selskiBekTwo = new Person("selskiBek", 05467029);
        private Person radka = new Person("Radka", 093465032560);

        private Person micheto = new Person("Micheto", 043756035602);
        private Person michka = new Person("Michka", 7432560516105);
        private Person pakChichoGosho = new Person("Chicho_Gosho", 94875);
        private Person iPakChichoGosho = new Person("Chichkata", 37260);

        private Database<Person> database;

        [SetUp]
        public void SetUp()
        {
            Person[] input = {pesho,gosho,dimitrichka,palavataClasna,chichoGosho,selskiyaErgen,
                              spiro, spiridon,stamat,pasha,siyka,gichka,selskiBek,selskiBekTwo,};
            this.database = new Database<Person>(input);
        }
        [Test]
        public void ConstructorCreatesArrayWithValidSize()
        {
            Assert.That(this.database.Capacity == 16);
        }

        [Test]
        public void ConstructorWorksWithValidInputLenght()
        {
            Person[] input = { pesho, gichka, spiro };
            Type type = typeof(Database<Person>);
            Database<Person> database = (Database<Person>)Activator.CreateInstance(type, new object[] { input });
            FieldInfo fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                    .FirstOrDefault(f => f.FieldType == typeof(Person[]));
            Person[] databaseElements = (Person[])fields.GetValue(database);
            Person[] notDefaultElements = new Person[input.Length];
            Array.Copy(databaseElements, notDefaultElements, input.Length);

            Assert.That(input.SequenceEqual(notDefaultElements));
        }

        [Test]
        public void ConstructorThrowsExeptionWhitInvalidInputLenght()
        {
            Person[] input = { pesho,gosho,dimitrichka,palavataClasna,chichoGosho,selskiyaErgen,
                              spiro, spiridon,stamat,pasha,siyka,gichka,selskiBek,selskiBekTwo,
                              radka,micheto,michka};

            Assert.That(() => new Database<Person>(input), Throws
                                                        .InvalidOperationException
                                                        .With
                                                        .Message
                                                        .EqualTo("Database Capacity Max Size is 16!"));
        }

        [Test]
        public void ConstructorThrowExeptionIfThereTwoPersonWithSameUsername()
        {
            Person[] input = {pesho,gosho,dimitrichka,palavataClasna,chichoGosho,selskiyaErgen,
                              spiro, spiridon,stamat,pasha,siyka,gichka,selskiBek,selskiBekTwo,
                              pakChichoGosho};

            Assert.That(() => new Database<Person>(input), Throws
                                                          .InvalidOperationException
                                                          .With
                                                          .Message
                                                          .EqualTo("Invalid Input. All Usernames and Id's must be unique!"));

        }

        [Test]
        public void ConstructorThrowExeptionIfThereTwoPersonWithSameId()
        {
            Person[] input = {pesho,gosho,dimitrichka,palavataClasna,chichoGosho,selskiyaErgen,
                              spiro, spiridon,stamat,pasha,siyka,gichka,selskiBek,selskiBekTwo,
                              iPakChichoGosho};

            Assert.That(() => new Database<Person>(input), Throws
                                                          .InvalidOperationException
                                                          .With
                                                          .Message
                                                          .EqualTo("Invalid Input. All Usernames and Id's must be unique!"));

        }
    }
}
