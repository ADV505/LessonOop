using HotChocolate;
using WebGraph.Abstraction;
using WebGraph.Dto;

namespace WebGraph.Graph.Query
{
    public class Query
    {
        public IEnumerable<ProductDto> GetProducts([Service] IProductRepository productRepository) =>
            productRepository.GetAllProducts();

        public IEnumerable<ProductGroupDto> GetProductGroups([Service] IProductGroupRepository groupRepository) =>
            groupRepository.GetAllProductGroups();

        public IEnumerable<StorageDto> GetStorages([Service] IStorageRepository storageRepository) =>
            storageRepository.GetAllStorages();
    }
}
