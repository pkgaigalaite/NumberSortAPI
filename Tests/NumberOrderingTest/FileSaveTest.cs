using Moq;
using NumberOrderingAPI.Models;
using System;
using System.IO;
using Xunit;

namespace NumberOrderingTest
{
    public class FileSaveTest
    {
        string rootPath = AppDomain.CurrentDomain.BaseDirectory;
        string fileName = "sortedNumbers.txt";
        [Fact]
        public void CorrectSaving()
        {
            int[] sortedList = { 1, 2, 4, 5, 5, 9, 100 };
            string path = Path.Combine(rootPath, fileName);
            FileManager.Save(sortedList);
            Assert.True(File.Exists(path));
            var listFromFile = File.ReadAllText(path);
            Assert.Equal(string.Join(' ', sortedList), listFromFile);
        }

        [Fact]
        public void CorrectLoading()
        {
            string list = "5 5 4 1 9 100 2";
            string path = Path.Combine(rootPath, fileName);
            File.WriteAllText(path, list);
            string listFromFile = FileManager.Load();
            Assert.Equal(list, listFromFile);
        }
    }
}
