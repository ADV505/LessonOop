using System.Text;
using WebGraph.Dto;

namespace WebGraph.OutTypeFile
{
    public class Csv
    {
        public static string GetCsv(IEnumerable<ProductDto> productsDto)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (ProductDto productDto in productsDto)
            {
                stringBuilder.AppendLine(productDto.Name + ";" + productDto.Description + "\n");
            }
            return stringBuilder.ToString();
        }
    }
}
