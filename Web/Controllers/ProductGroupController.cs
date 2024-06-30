using Microsoft.AspNetCore.Mvc;
using System;
using Web.Abstraction;
using Web.Data;
using Web.Dto;
using Web.Models;
using Web.Repository;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductGroupController : ControllerBase
    {
        private readonly IProductGroupRepository _productGroupRepository;

        public ProductGroupController(IProductGroupRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;
        }

        [HttpPost]
        public ActionResult<int> AddProductGroup(ProductGroupDto productGroupDto)
        {
            try
            {
                var id = _productGroupRepository.AddProductGroup(productGroupDto);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(409);
            }
        }

        [HttpGet("get_all_products")]
        public ActionResult<IEnumerable<Product>> GetAllProductGroups()
        {
            return Ok(_productGroupRepository.GetAllProductGroups());
        }

        [HttpDelete]
        public ActionResult DeleteProductGroup(int id)
        {
            return Ok(_productGroupRepository.DeleteProductGroup(id));
        }

        [HttpGet(template: "GetProductCsv")]
        public FileContentResult GetProductCsv()
        {
            return File(_productGroupRepository.GetProductCsv(), "txt/csv", "report.csv");

        }
    }
}
