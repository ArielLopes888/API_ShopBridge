using API.Utilities;
using API.ViewModels;
using AutoMapper;
using Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTO_s;
using Services.Interfaces;


namespace API.Controllers
{

    [ApiController]
    public class ProductsControllers : ControllerBase
    {

        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;

        public ProductsControllers(IProductsService productsservice, IMapper mapper)
        {
            _productsService = productsservice;
            _mapper = mapper;
        }


        [HttpPost]
        [Authorize]
        [Route("/api/v1/products/create")]
        public async Task<IActionResult> Create([FromBody] CreateProductsViewModel createViewModel)
        {
            try
            {
                var productDTO = _mapper.Map<ProductsDto>(createViewModel);

                var productCreated = await _productsService.Create(productDTO);

                return Ok(new ResultViewModel
                {
                    Success = true,
                    Data = productCreated,
                    Message = "Product Added Successfully"
                });

            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
        [HttpPut]
        [Authorize]
        [Route("/api/v1/products/update")]
        public async Task<IActionResult> Update([FromBody] UpdateProductsViewModel updateProductsViewModel)
        {
            try
            {
                var productsDTO = _mapper.Map<ProductsDto>(updateProductsViewModel);
                var productsUpdated = await _productsService.Update(productsDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Product updated successfully!",
                    Success = true,
                    Data = productsUpdated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("/api/v1/products/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                var product = await _productsService.Get(id);
                await _productsService.Remove(id);
                if (product == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "No product found with the ID entered!",
                        Success = true,
                        Data = null
                    });
                }
                return Ok(new ResultViewModel
                {
                    Message = "Product removed successfully!",
                    Success = true,
                    Data = product
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/products/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var product = await _productsService.Get(id);

                if (product == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "No product found with the ID entered!",
                        Success = true,
                        Data = product
                    });
                }
                return Ok(new ResultViewModel
                {
                    Message = "Product found successfully!",
                    Success = true,
                    Data = product
                });


            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }


        [HttpGet]
        [Authorize]
        [Route("/api/v1/products/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allProducts = await _productsService.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Products successfully found!",
                    Success = true,
                    Data = allProducts
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }



        [HttpGet]
        [Authorize]
        [Route("/api/v1/products/search-by-name")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            try
            {
                var allProducts = await _productsService.SearchByName(name);

                if (allProducts.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "No product found with the Name entered!",
                        Success = true,
                        Data = null
                    });
                }
                return Ok(new ResultViewModel
                {
                    Message = "Product successfully found!",
                    Success = true,
                    Data = allProducts
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }

        }


        [HttpGet]
        [Authorize]
        [Route("/api/v1/products/search-by-category")]
        public async Task<IActionResult> SearchByCategory([FromQuery] string email)
        {
            try
            {
                var allProducts = await _productsService.SearchByCategory(email);

                if (allProducts.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "No products found with the informed category!",
                        Success = true,
                        Data = null
                    });
                }
                return Ok(new ResultViewModel
                {
                    Message = "Product successfully found!",
                    Success = true,
                    Data = allProducts
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}
