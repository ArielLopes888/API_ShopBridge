using System.ComponentModel.DataAnnotations;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class ProductsValidator : AbstractValidator<Products>
    {
        public ProductsValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("The product cannot be empty")

                .NotNull()
                .WithMessage("The product cannot be null");


            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("The name cannot be empty")

                .NotNull()
                .WithMessage("The name cannot be null")

                .MinimumLength(3)
                .WithMessage("The description must be at least 3 characters long.")

                .MaximumLength(80)
                .WithMessage("The description must be a maximum of 80 characters.");
            

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("The description cannot be empty")

                .NotNull()
                .WithMessage("The description cannot be null")

                .MinimumLength(10)
                .WithMessage("The description must be at least 10 characters long.")

                .MaximumLength(180)
                .WithMessage("The description must be a maximum of 180 characters.");

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("The price cannot be empty")

                .NotNull()
                .WithMessage("Price is required.")

                .GreaterThan(0)
                .WithMessage("Price must be greater than zero.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty()
                .WithMessage("The Image cannot be empty")

                .NotNull()
                .WithMessage("The Image cannot be null");

            RuleFor(x => x.Category)
               .NotEmpty()
               .WithMessage("The Category cannot be empty")

               .NotNull()
               .WithMessage("The Category cannot be null");
        }
    }
}
