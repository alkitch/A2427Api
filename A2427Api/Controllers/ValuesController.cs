using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A2427Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace A2427Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private readonly RFIDContext _context;

        public ValuesController(RFIDContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<RFID> Get()
        {

            //_context.Valuex.Add(new Value { value = "hello" });
            //_context.Valuex.Add(new Value { value = "alan" });
            //_context.SaveChanges();

            //return new string[] { "value1", "value2" };

            return _context.Rfids.ToList();
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody]RFID value)
        {

            _context.Rfids.Add(value);
            _context.SaveChanges();
            return new CreatedResult("100","{\"result\":\"" + value.RFDidTag + "\"}" );
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
