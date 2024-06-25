using Microsoft.AspNetCore.Mvc;
using System;
using Web.Data;
using Web.Models;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public ActionResult<int> AddProduct(string name, string description, decimal price)
        {
            using (AppContex appContex = new AppContex())
            {
                if (appContex.Products.Any(p => p.Name == name))
                    return StatusCode(409);

                var product = new Product() { Name = name, Description = description, Price = price };
                appContex.Products.Add(product);
                appContex.SaveChanges();
                return Ok(product.Id);
            }
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            using (AppContex appContex = new AppContex())
            {
                var list = appContex.Products.Select(p => new Product { Id = p.Id, Name = p.Name, Description = p.Description, Price = p.Price }).ToList();
                return Ok(list);
                
            }
        }

        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            using (AppContex appContex = new AppContex())
            {
                Product? product = appContex.Products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                    return StatusCode(409);
                appContex.Products.Remove(product);
                appContex.SaveChanges();
                return Ok();
            }
            
        }
    }
}
