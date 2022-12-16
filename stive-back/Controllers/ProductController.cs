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
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            this._context = context;
        }

        // GET: api/values
        [HttpGet]
        public List<Product>? Get()
        {
            var products = _context.Product?.Include(I => I.Category).Include(I => I.ProductImages).ToList();
            return products;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Product? Get(int id)
        {
            var product = _context.Product?.Include(I => I.Category).Include(I => I.ProductImages).First(x => x.Id == id);
            return product;
        }

        // POST api/values
        [HttpPost]
        public Product? Post([FromBody] ProductRequest value)
        {
            var data = new Product
            {
                Name = value.Name, Description = value.Description, Price = value.Price, Reference = value.Reference,
                CategoryId = value.Category
            };
            _context.Product?.Add(data);
            _context.SaveChanges();

            foreach (var img in value.Images)
            {
                _context.ProductImages?.Add(new ProductImage() { Url = img, ProductId = data.Id });
            }

            _context.SaveChanges();

            return this.Get(data.Id);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Product? Put(int id, [FromBody] ProductRequest value)
        {
            var data = new Product
            {
                Name = value.Name, Description = value.Description, Price = value.Price, Reference = value.Reference,
                CategoryId = value.Category, Id = id
            };
            _context.Product?.Update(data);
            _context.SaveChanges();
            return this.Get(data.Id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            _context.Product?.Remove(new Product { Id = id });
            _context.SaveChanges();
            return true;
        }
    }
}