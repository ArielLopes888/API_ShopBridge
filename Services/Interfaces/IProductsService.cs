using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Services.DTO_s;

namespace Services.Interfaces
{
    public interface IProductsService
    {
        Task<ProductsDto> Create(ProductsDto productsDto);
        Task<ProductsDto> Update(ProductsDto productsDto);
        Task Remove(long id);
        Task<ProductsDto> Get(long id);
        Task<List<ProductsDto>> Get();

        Task<List<ProductsDto>> SearchByName(string name);
        Task<List<ProductsDto>> SearchByCategory(string category);
    }
}
