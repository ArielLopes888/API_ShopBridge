using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO_s
{
    public class ProductsDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }

        public ProductsDto()
        {}

        public ProductsDto(int id, string name, string description, decimal price, string imageUrl, string category)
        {
            Id=id;
            Name=name;
            Description=description;
            Price=price;
            ImageUrl=imageUrl;
            Category=category;
        }

    }
}
