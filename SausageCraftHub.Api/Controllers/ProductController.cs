using ApplicationCore1.DTOs;
using ApplicationCore1.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace SausageCraftHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductsService _productsService;

        public ProductController(IMapper mapper, IProductsService productsService)
        {
            _mapper = mapper;
            _productsService = productsService;
        }

        [HttpGet]
        [Route("allProducts")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _productsService.GetAllProductsAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productsDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _productsService.GetProductsByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPost]
        [Route("create/{id}")]
        public async Task<ActionResult> Create([FromForm] CreateProductDto createProductDto)
        {
            var product = await _productsService.CreateProductsAsync(createProductDto);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _productsService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<ActionResult> Update(int id, CreateProductDto createProductDto)
        {
            try
            {
                await _productsService.UpdateProductsAsync(id, createProductDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}