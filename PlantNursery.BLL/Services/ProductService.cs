using Microsoft.EntityFrameworkCore.Metadata;
using PlantNursery.BLL.Interfaces;
using PlantNursery.DAL.Repositories;
using PlantNursery.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantNursery.DAL.Interfaces;

namespace PlantNursery.BLL.Services
{
    public class ProductService: IProductService
    {
        //הזרקת תלויות
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        //בנאh
        public ProductService(IProductRepository productRepo, IMapper mapper)
        {
            _productRepository = productRepo;
            _mapper = mapper;
        }
      
        public async Task<List<ProductDto>> GetAllProductsByCategory(int categoryId)
        {
            var products = await _productRepository.GetAllProductsByCategory(categoryId);
            return _mapper.Map<List<ProductDto>>(products);
        }

        public  async Task<ProductDto> GetProductById(Guid id)
        {
            var product =await _productRepository.GetProductById(id);
            return product is null? null: _mapper.Map<ProductDto>(product);
        }
    }
}
