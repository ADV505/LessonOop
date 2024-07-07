using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System.Text;
using WebGraph.Abstraction;
using WebGraph.Data;
using WebGraph.Dto;
using WebGraph.Models;
using WebGraph.OutTypeFile;

namespace WebGraph.Repository
{
    public class ProductRepository(AppContex appContext, IMapper _mapper, IMemoryCache _memoryCache) : IProductRepository
    {
       
        public int AddProduct(ProductDto productDto)
        {
            if (appContext.Products.Any(p => p.Name == productDto.Name))
                throw new Exception("Уже есть продукт с таким именем");

            var entity = _mapper.Map<Product>(productDto);
            appContext.Products.Add(entity);
            appContext.SaveChanges();
            _memoryCache.Remove("products");
            return entity.Id;
        }

        public int DeleteProduct(int id)
        {
            var product = appContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                appContext.Products.Remove(product);
                appContext.SaveChanges();
                return product.Id;
            }
            return -1;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            if (_memoryCache.TryGetValue("products", out List<ProductDto> listDto)) return listDto;
            listDto = appContext.Products.Select(_mapper.Map<ProductDto>).ToList();
            var historyCache = _memoryCache.Set("products", listDto, TimeSpan.FromMinutes(30));           
            return listDto;
        }



        public string GetCacheUrl()
        {
            string fileNameCache = "cache" + DateTime.Now.ToBinary().ToString() + ".csv";
            System.IO.File.WriteAllText(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles", fileNameCache), _memoryCache.GetCurrentStatistics().ToString());
            return fileNameCache;
        }

        public byte[] GetProductCsv()
        {
            var product = appContext.Products.Select(p => new ProductDto { Name = p.Name, Description = p.Description }).ToList();
            var content = Csv.GetCsv(product);           
            return new UTF8Encoding().GetBytes(content);
        }
    }
}
