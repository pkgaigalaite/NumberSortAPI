using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NumberOrderingAPI.Models;

namespace NumberOrderingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {
        private readonly ISorter _sorter;
        private struct SortedListResult {
            public string sortedList;
        }

    public NumbersController(ISorter sorter)
        {
            _sorter = sorter;
        }

        // GET: api/Numbers
        [HttpGet]
        public string Get()
        {
            var sortedList = FileManager.Load();
            var sortedListResult = new SortedListResult();
            sortedListResult.sortedList = sortedList;
            
            return JsonConvert.SerializeObject(sortedListResult);
        }


        // POST: api/Numbers
        [HttpPost]
        public string Post([FromBody] string listOfnumbers)
        {
            int[] receivedNumbers;
            try 
            {
                receivedNumbers = listOfnumbers.ToString().Split(' ').Select(Int32.Parse).ToArray();
            }
            catch (Exception)
            {
                return "Passed list is of wrong fromat";
            }
            try
            {
                var sortedList = _sorter.Sort(receivedNumbers);
                FileManager.Save(sortedList);
            }
            catch (Exception ex) 
            {
                return (String.Format("Something went wrong while trying to sort the list: {0}", ex));
            }
            return String.Format("String accepted and sorted, file saved at {0}", FileManager.GetPath());
        }
    }
}
