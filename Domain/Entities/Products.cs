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

            Validate();  //checks if the values ​​are valid according to the rules defined in the ProductsValidator class
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
