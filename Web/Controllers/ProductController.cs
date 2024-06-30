using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.IO;
using Web.Abstraction;
using Web.Data;
using Web.Dto;
using Web.Models;
using Web.OutTypeFile;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public ActionResult<int> AddProduct(ProductDto productDto)
        {
            try
            {
                var id = _productRepository.AddProduct(productDto);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(409);
            }


        }
        [HttpGet("get_all_products")]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return Ok(_productRepository.GetAllProducts());
        }

        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            return Ok(_productRepository.DeleteProduct(id));
        }

        [HttpGet(template: "GetProductCsv")]
        public FileContentResult GetProductCsv()
        {
            return File(_productRepository.GetProductCsv(), "txt/csv", "report.csv");
        }

        [HttpGet(template: "GetCacheUrl")]
        public ActionResult<string> GetCacheCsv()
        {
            var filename = _productRepository.GetCacheUrl();
            return "https://" + Request.Host.ToString()+ "/cache/" + filename;
        }

    }
}
  

