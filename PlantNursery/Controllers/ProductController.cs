using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PlantNursery.BLL.Interfaces;
using PlantNursery.DAL.Entities;
using PlantNursery.DTO;

namespace PlantNursery.API.Controllers
{
    [ApiController]
        [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

                private readonly IMapper _mapper;

                public ProductController(IProductService productServoce,IMapper mapper)
                {
            _productService = productServoce;
                   _mapper = mapper;
               }

        //Get api/products/category/{categotyId}
        [HttpGet("product/category/{categoryId}")]

        public async Task<ActionResult<List<ProductDto>>> GetProductByCategory(int categoryId)
        {
            var products = await _productService.GetAllProductsByCategory(categoryId);
            return Ok(products);

        }
        //Get api/product/{id}
        [HttpGet("product/{id}")]
        public async Task<ActionResult<ProductDto>>GetProductById(Guid id)
        {
            var product= await _productService.GetProductById(id);
            return Ok(product);
        }
       
    }
}
