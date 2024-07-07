using Microsoft.AspNetCore.Mvc;
using WebGraph.Abstraction;
using WebGraph.Dto;
using WebGraph.Repository;

namespace WebGraph.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController: ControllerBase
    {
        private readonly IStorageRepository _storageRepository;

        public StorageController(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }

        [HttpPost]
        public ActionResult<int> AddStorage(StorageDto strorageDto)
        {
            try
            {
                var id = _storageRepository.AddStorage(strorageDto);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(409);
            }
        }

    }
}
