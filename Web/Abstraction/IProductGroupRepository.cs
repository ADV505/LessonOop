using Web.Dto;

namespace Web.Abstraction
{
    public interface IProductGroupRepository
    {
        IEnumerable<ProductGroupDto> GetAllProductGroups();
        int AddProductGroup(ProductGroupDto productGroupDto);
        int DeleteProductGroup(int id);
        byte[] GetProductCsv();
    }
}
