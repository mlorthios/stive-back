using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stive_back.DTOs.Product;
using stive_back.Helpers;
using stive_back.Models;

namespace stive_back.Controllers
{
    [Route("api/[controller]")]
    public class StockController : Controller
    {
        private readonly AppDbContext _context;

        public StockController(AppDbContext context)
        {
            this._context = context;
        }

        // GET: api/values
        [HttpGet]
        public void Get()
        {
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public void Get(int id)
        {
            
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] ProductRequest value)
        {
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductRequest value)
        {
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}