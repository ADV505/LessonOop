using Microsoft.AspNetCore.Mvc;
using WebGraph.Dto;

namespace WebGraph.Abstraction
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
