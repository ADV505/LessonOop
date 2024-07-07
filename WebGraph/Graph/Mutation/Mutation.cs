using HotChocolate;
using WebGraph.Abstraction;
using WebGraph.Dto;

namespace WebGraph.Graph.Mutation
{

    public class Mutation
    {
        public int AddProduct([Service] IProductRepository productRepository, ProductDto productDto) =>
            productRepository.AddProduct(productDto);

        public int AddProductGroup([Service] IProductGroupRepository groupRepository, ProductGroupDto productGroupDto) =>
            groupRepository.AddProductGroup(productGroupDto);

        public int AddStorage([Service] IStorageRepository storageRepository, StorageDto storageDto) =>
            storageRepository.AddStorage(storageDto);

        public void UpdateStorageCount([Service] IStorageRepository storageRepository, int storageId, int count) =>
            storageRepository.UpdateStorageCount(storageId, count);

        public void DeleteStorage([Service] IStorageRepository storageRepository, int id) =>
            storageRepository.DeleteStorage(id);
    }
}

