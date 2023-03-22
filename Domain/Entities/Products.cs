using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain.Exceptions;
using Domain.Validators;

namespace Domain.Entities
{
    public class Products : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }



        public Products() { }

        public Products(string name, string description, decimal price, string imageUrl, string category)
        {
            Name = name;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;
            Category = category;
          
            _errors = new List<string>();

            Validate();
        }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangeDescription(string description)
        {
            Description = description;
            Validate();
        }

        public void Changeprice(decimal price)
        {
            Price = price;
            Validate();
        }

        public void ChangeImageUrl(string imageUrl)
        {
            ImageUrl = imageUrl;
            Validate();
        }

        public void ChangeCategory(string category)
        {
            Category = category;
            Validate();
        }
        public override bool Validate()
        {
            var validator = new ProductsValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);
                throw new DomainException("Alguns campos estão inválidos, por favor corrigir", _errors);
            }
            return true;
        }
    }
}
