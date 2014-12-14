using NUnit.Framework;
using System.Collections.Generic;
using DroneStudio.Library;
using System;

namespace Test.DroneStudio.Library
{
    [TestFixture]
    public class TestEnumerableExtensions
    {
        [Test]
        public void ForEach_performs_action_on_each_element_of_list()
        {
            var list = new List<int>();
            var listOfInts = new List<int>() { 1, 2, 3 };

            listOfInts.ForEach(p => list.Add(p));

            CollectionAssert.AreEqual(listOfInts, list);
        }

        [Test]
        public void WhereNotNull_returns_not_null_elements()
        {
            var list = new List<string>() { "a", null, "b", null, "c" };

            CollectionAssert.AreEqual(new List<string>() { "a", "b", "c" }, list.WhereNotNull());
        }
    }
}
