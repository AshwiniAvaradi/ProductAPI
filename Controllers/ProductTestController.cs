using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Services.services;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTestController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductTestController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
       public  List<ProductTest> GetAllProducts()
        {
            return _productService.GetALLProducts();
        }
    }
}
