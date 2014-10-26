using NUnit.Framework;
using System.Collections.Generic;
using DroneStudio.Library;

namespace Test.DroneStudio.Library
{
    [TestFixture]
    public class TestEnumerableExtensions
    {
        [SetUp]
        public void Initialise()
        {
            this.listOfInts = new List<int>() { 1, 2, 3 };
        }

        [Test]
        public void ForEach_performs_action_on_each_element_of_list()
        {
            var newList = new List<int>();

            this.listOfInts.ForEach(p => newList.Add(p));

            CollectionAssert.AreEqual(this.listOfInts, newList);
        }

        private IList<int> listOfInts;
    }
}
