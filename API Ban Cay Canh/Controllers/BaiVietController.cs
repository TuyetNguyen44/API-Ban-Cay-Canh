using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Ban_Cay_Canh.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Ban_Cay_Canh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiVietController : ControllerBase
    {
        BanCayCanhContext db = new BanCayCanhContext();
        // GET: api/<BaiVietController>
        [HttpGet]
        [Route("Get")]
        public List<BaiViet> Get()
        {
            return db.BaiViets.ToList();
        }

        // GET api/<BaiVietController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value"; 
        }

        // POST api/<BaiVietController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BaiVietController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BaiVietController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
