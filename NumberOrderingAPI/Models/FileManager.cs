using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NumberOrderingAPI.Models
{
    public static class FileManager
    {
        private static readonly string fileName = "sortedNumbers.txt";
        private static readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        public static string Load()
        {
            try 
            {
                return File.ReadAllText(path);
            }
            catch (Exception e)
            {
                return String.Format("An error occurred while trying to load the last saved file: {0}", e);
            };
        }

        public static void Save(int[] numbers)
        {
            File.WriteAllText(path, string.Join(' ', numbers));
        }

        public static string GetPath()
        {
            return path;
        }

    }
}
