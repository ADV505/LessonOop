using Microsoft.AspNetCore.Mvc;
using Web.Dto;

namespace Web.Abstraction
{
    public interface IProductRepository
    {
        IEnumerable<ProductDto> GetAllProducts();
        int AddProduct(ProductDto productDto);
        int DeleteProduct(int id);
        byte[] GetProductCsv();
        string GetCacheUrl();

    }
}
