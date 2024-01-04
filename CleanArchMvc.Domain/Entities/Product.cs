using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExeceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categotyId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categotyId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExeceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExeceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            DomainExeceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. description is required");

            DomainExeceptionValidation.When(description.Length < 5,
                "Invalid description, too short, minimum 5 characters");

            DomainExeceptionValidation.When(price < 0, "Invalid price value");

            DomainExeceptionValidation.When(stock < 0, "Invalid stock value");

            DomainExeceptionValidation.When(image.Length > 250,
                "Invalid description, too long, maximum 250 characters");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
