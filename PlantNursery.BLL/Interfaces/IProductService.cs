using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantNursery.DTO;


namespace PlantNursery.BLL.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsByCategory(int num);
        Task<ProductDto?> GetProductById(Guid id);
        
    }
}
