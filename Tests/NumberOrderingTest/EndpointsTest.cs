using Moq;
using NumberOrderingAPI.Controllers;
using NumberOrderingAPI.Models;
using System;
using System.IO;
using Xunit;

namespace NumberOrderingTest
{
    public class EndpointsTest
    {
        readonly string rootPath = AppDomain.CurrentDomain.BaseDirectory;
        readonly string fileName = "sortedNumbers.txt";
        [Fact]
        public void CorrectGet()
        {
            string sortedList = "1 2 4 5 5 9 100";
            string path = Path.Combine(rootPath, fileName);
            File.WriteAllText(path, sortedList);

            var mockSorter = new Mock<ISorter>();
            var controller = new NumbersController(mockSorter.Object);
  

            var result = controller.Get();
            var expected = "{\"sortedList\":\"1 2 4 5 5 9 100\"}";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CorrectPostWithGoodArray()
        {
            string path = Path.Combine(rootPath, fileName);
            var mockSorter = new Mock<ISorter>();
            var controller = new NumbersController(mockSorter.Object);

            var result = controller.Post("1 8 1 20 1 5 100");
            Assert.Equal(String.Format("String accepted and sorted, file saved at {0}", path), result);
        }

        [Fact]
        public void IncorrectPostWithNullArray()
        {
            var mockSorter = new Mock<ISorter>();
            var controller = new NumbersController(mockSorter.Object);

            var result = controller.Post(null);
            Assert.Equal("Passed list is of wrong fromat", result);
        }

        [Fact]
        public void IncorrectPostWithBadArrayFormat()
        {
            string list = "5 5 4 1 9   100 2";
            var mockSorter = new Mock<ISorter>();
            var controller = new NumbersController(mockSorter.Object);
            var result = controller.Post(list);
            Assert.Equal("Passed list is of wrong fromat", result);
        }
    }
}
