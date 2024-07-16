
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using ERP_System.DTOS;
using Infrastrucure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        private readonly StoreContext _context;
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepostory<Product> _productRepo;
        private readonly IGenericRepostory<ProductBrand> _productBrandRepo;
        private readonly IGenericRepostory<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductController(
                        StoreContext context,
                        IProductRepository ProductRepository,
                        IGenericRepostory<Product> ProductRepo,
                        IGenericRepostory<ProductBrand> ProductBrandRepo,
                        IGenericRepostory<ProductType> ProductTypeRepo,
                        IMapper mapper
            )
        {
            _context = context;
            _productRepository = ProductRepository;
            _productRepo = ProductRepo;
            _productBrandRepo = ProductBrandRepo;
            _productTypeRepo = ProductTypeRepo;
            _mapper = mapper;
        }
        #region Product
        [HttpGet]
        public async Task<ActionResult<List<ProductToReturnDTO>>> GetProducts()
        {
            var spec = new ProductToReturnDTO();
            var products = await _productRepo.ListAllAsync();
            var map = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(products);
            return Ok(map);

        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<List<ProductToReturnDTO>>> GetAllProducts(string sort)
        {
            var spec = new ProductWithTypeAndBrandSpec(sort);
            var products = await _productRepo.ListAllAsyncSpec(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDTO>> GetProductById(int id)
        {
            var spec = new ProductWithTypeAndBrandSpec(id);
            var Product = await _productRepo.GetEntityWithSpec(spec);
            //return Ok(Product);
            var map = _mapper.Map<Product, ProductToReturnDTO>(Product);
            return Ok(map);
        }
        #endregion

        #region Brand
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }
        #endregion

        #region Types
        [HttpGet("ProductTypes")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
        #endregion

    }
}
