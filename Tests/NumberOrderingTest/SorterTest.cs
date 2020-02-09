using Moq;
using NumberOrderingAPI.Models;
using System;
using Xunit;

namespace NumberOrderingTest
{
    public class SorterTest
    {
        [Fact]
        public void CorrectSorting()
        {
            int[] list = { 5, 5, 4, 1, 9, 100, 2 };
            int[] sortedList = { 1, 2, 4, 5, 5, 9, 100};
            var sorter = new Sorter();
            var sorterResult = sorter.Sort(list);

            Assert.Equal(sortedList, sorterResult);
        }
    }
}
