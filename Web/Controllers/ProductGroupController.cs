using Microsoft.AspNetCore.Mvc;
using Web.Data;
using Web.Models;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductGroupController : ControllerBase
    {
        [HttpPost]
        public ActionResult<int> AddProductGroup(string name, string description)
        {
            using (AppContex appContex = new AppContex())
            {
                if (appContex.ProductGroups.Any(p => p.Name == name))
                    return StatusCode(409);

                var product = new Product() { Name = name, Description = description };
                appContex.Products.Add(product);
                appContex.SaveChanges();
                return Ok(product.Id);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductGroup>> GetProductGroups()
        {
            using (AppContex appContex = new AppContex())
            {
                var list = appContex.ProductGroups.Select(p => new Product { Id = p.Id, Name = p.Name, Description = p.Description}).ToList();
                return Ok(list);

            }
        }

        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            using (AppContex appContex = new AppContex())
            {
                ProductGroup? productGroup = appContex.ProductGroups.FirstOrDefault(p => p.Id == id);
                if (productGroup == null)
                    return StatusCode(409);
                appContex.ProductGroups.Remove(productGroup);
                appContex.SaveChanges();
                return Ok();
            }

        }

    }
}
