using _02PeopleDatabase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DatabaseTests
{
    [TestFixture]
    public class AddMethodTests
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

        [Test]
        public void AddMethodAddElementAtNextFreeCell()
        {
            Person[] input = { iPakChichoGosho, michka };
            Person elementToAdd = radka;

            Type type = typeof(Database<Person>);
            Database<Person> database = (Database<Person>)Activator.CreateInstance(type, new object[] { input });
            database.Add(elementToAdd);
            FieldInfo field = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                    .FirstOrDefault(f => f.FieldType == typeof(Person[]));
            Person[] databaseElements = (Person[])field.GetValue(database);                        

            Assert.That(databaseElements[2], Is.EqualTo(elementToAdd));
        }

        [Test]
        public void AddMethodThrowsExeptionIfThereIsNoFreeCell()
        {
            Person[] input = { pesho,gosho,dimitrichka,palavataClasna,chichoGosho,selskiyaErgen,
                              spiro, spiridon,stamat,pasha,siyka,gichka,selskiBek,selskiBekTwo,
                              radka, micheto};
            Database<Person> database = new Database<Person>(input);
            Person elementToAdd = michka;

            Assert.That(() => database.Add(elementToAdd), Throws.InvalidOperationException
                                                                .With
                                                                .Message
                                                                .EqualTo("Database is full!"));
        }
    }
}
