using AutoMapper;
using System;
using System.Text;
using Web.Abstraction;
using Web.Data;
using Web.Dto;
using Web.Models;
using Web.OutTypeFile;

namespace Web.Repository
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        AppContex appContext;
        private readonly IMapper _mapper;
        public ProductGroupRepository(AppContex appContex, IMapper mapper)
        {
            this.appContext = appContex;
            this._mapper = mapper;
        }
        public int AddProductGroup(ProductGroupDto productGroupDto)
        {
            if (appContext.ProductGroups.Any(p => p.Name == productGroupDto.Name))
                throw new Exception("Уже есть продукт с таким именем");

            var entity = _mapper.Map<ProductGroup>(productGroupDto);
            appContext.ProductGroups.Add(entity);
            appContext.SaveChanges();
            return entity.Id;
        }

        public int DeleteProductGroup(int id)
        {
            var productGroup = appContext.ProductGroups.FirstOrDefault(p => p.Id == id);
            if (productGroup != null)
            {
                appContext.ProductGroups.Remove(productGroup);
                appContext.SaveChanges();
                return productGroup.Id;
            }
            return -1;
        }

        public IEnumerable<ProductGroupDto> GetAllProductGroups()
        {
            var listDto = appContext.ProductGroups.Select(_mapper.Map<ProductGroupDto>).ToList();
            return listDto;
        }
        public byte[] GetProductCsv()
        {
            var product = appContext.Products.Select(p => new ProductDto { Name = p.Name, Description = p.Description }).ToList();
            var content = Csv.GetCsv(product);
            return new UTF8Encoding().GetBytes(content);
        }
    }
}
