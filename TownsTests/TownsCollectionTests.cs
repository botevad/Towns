using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownsTests
{
    public class TownsCollectionTests
    {
        [Test]
        public void Test_Constructor_EmptyConstructor() 
        {
            var townsCollection = new TownsCollection();

            Assert.That(townsCollection.Towns.Count, Is.EqualTo(0));
            Assert.That(townsCollection.ToString(), Is.Empty);
        }

        [Test]
        public void Test_Constructor_SingleTown()
        {
            var townsCollection = new TownsCollection("Paris");

            Assert.That(townsCollection.Towns.Count, Is.EqualTo(1));
            Assert.That(townsCollection.ToString(), Is.EqualTo("Paris"));
        }

        [Test]
        public void Test_Add_SingleTown()
        {
            var townsCollection = new TownsCollection("Paris");
            townsCollection.Add("London");

            Assert.That(townsCollection.Towns.Count, Is.EqualTo(2));
            Assert.That(townsCollection.ToString(), Is.EqualTo("Paris, London"));
        }

        [Test]
        public void Test_Add_SingleTownAlternative()
        {
            var townsCollection = new TownsCollection("Paris");
            var isAdded = townsCollection.Add("London");

            Assert.True(isAdded);
        }

        [Test]
        public void Test_Add_DuplicateTownAlternative()
        {
            var townsCollection = new TownsCollection("Paris, London");
            var isAdded = townsCollection.Add("London");

            Assert.False(isAdded);
        }

        [Test]
        public void Test_RemoveAt_Index()
        {
            var townsCollection = new TownsCollection("Paris, Bucharest");
            townsCollection.RemoveAt(1);

            Assert.That(townsCollection.Towns.Count, Is.EqualTo(1));
            Assert.That(townsCollection.ToString(), Is.EqualTo("Paris"));
        }

        [Test]
        public void Test_RemoveAt_InvalidIndex()
        {
            var townsCollection = new TownsCollection("Paris, Bucharest");
      
            Assert.That(townsCollection.Towns.Count, Is.EqualTo(2));
            Assert.That(() => townsCollection.RemoveAt(2), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void Test_Reverse_TwoTowns()
        {
            var townsCollection = new TownsCollection("Paris, Bucharest");
            townsCollection.Reverse();

            Assert.That(townsCollection.Towns.Count, Is.EqualTo(2));
            Assert.That(townsCollection.ToString(), Is.EqualTo("Bucharest, Paris"));
        }

        [Test]
        public void Test_Reverse_SingleTown()
        {
            var townsCollection = new TownsCollection("Paris");
            Assert.That(() => townsCollection.Reverse(), Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void Test_Reverse_ZeroTown()
        {
            var townsCollection = new TownsCollection();
            townsCollection.Towns = null;
            Assert.That(() => townsCollection.Reverse(), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Test_Add_EmptyTown()
        {
            var townsCollection = new TownsCollection("Paris, Bucharest");
            townsCollection.Add("");

            Assert.That(townsCollection.Towns.Count, Is.EqualTo(2));
            Assert.That(townsCollection.ToString(), Is.EqualTo("Paris, Bucharest"));
        }



    }
}
