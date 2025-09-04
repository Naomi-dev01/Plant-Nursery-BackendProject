using PlantNursery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantNursery.DAL.Interfaces
{
    public interface IProductRepository
    {
        Task< List<Product>> GetAllProductsByCategory(int categoryNum);
        Task< Product?> GetProductById(Guid id);
    }
}
