using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Exceptions;
using Domain.Entities;
using Infra.Interfaces;
using Services.DTO_s;
using Services.Interfaces;

namespace Services.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IMapper _mapper;
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IMapper mapper, IProductsRepository userRepository)
        {
            _mapper = mapper;
            _productsRepository = userRepository;
        }

        public async Task<ProductsDto> Create(ProductsDto productsDto)
        {
            var userExist = await _productsRepository.Get(productsDto.Id);

            if (userExist != null)
                throw new DomainException("There is already a product registered with this ID.");

            var product = _mapper.Map<Products>(productsDto);
            product.Validate();

            var productCreated = await _productsRepository.Create(product);

            return _mapper.Map<ProductsDto>(productCreated);
        }
        public async Task<ProductsDto> Update(ProductsDto productsDto)
        {
            var productExist = await _productsRepository.Get(productsDto.Id);

            if (productExist == null)
                throw new DomainException("There is no registered product with this id.");

            var product = _mapper.Map<Products>(productsDto);
            product.Validate();

            var productUpdated = await _productsRepository.Update(product);

            return _mapper.Map<ProductsDto>(productUpdated);
        }

        public async Task Remove(long id)
        {
            await _productsRepository.Remove(id);
        }

        public async Task<ProductsDto> Get(long id)
        {
            var product = await _productsRepository.Get(id);

            return _mapper.Map<ProductsDto>(product);
        }
        public async Task<List<ProductsDto>> Get()
        {
            var allProducts = await _productsRepository.Get();

            return _mapper.Map<List<ProductsDto>>(allProducts);
        }

        public async Task<List<ProductsDto>> SearchByName(string name)
        {
            var product = await _productsRepository.SearchByName(name);

            return _mapper.Map<List<ProductsDto>>(product);
        }
        public async Task<List<ProductsDto>> SearchByCategory(string category)
        {
            var product = await _productsRepository.SearchByCategory(category);

            return _mapper.Map<List<ProductsDto>>(product);
        }
    }
}
