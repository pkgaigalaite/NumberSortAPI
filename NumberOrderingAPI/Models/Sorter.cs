using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberOrderingAPI.Models
{
    public class Sorter : ISorter
    {
        public int[] Sort(int[] numbers)
        {
            Bubble_Sort(numbers);
            return numbers;
        }

        private void Bubble_Sort(int[] numbers)
        {
            int temporary;
            for (var p = 0; p <= numbers.Length - 2; p++)
            {
                for (var i = 0; i <= numbers.Length - 2; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        temporary = numbers[i + 1];
                        numbers[i + 1] = numbers[i];
                        numbers[i] = temporary;
                    }
                }
            }
        }
    }
}
