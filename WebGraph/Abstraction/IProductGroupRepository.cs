using WebGraph.Dto;

namespace WebGraph.Abstraction
{
    public interface IProductGroupRepository
    {
        IEnumerable<ProductGroupDto> GetAllProductGroups();
        int AddProductGroup(ProductGroupDto productGroupDto);
        int DeleteProductGroup(int id);
        byte[] GetProductCsv();
    }
}
