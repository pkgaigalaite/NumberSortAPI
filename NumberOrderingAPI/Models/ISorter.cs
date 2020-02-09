using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberOrderingAPI.Models
{
    public interface ISorter
    {
        public int[] Sort(int[] numbers); 
    }
}
