using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; private set; }
        public string Name { get; private  set; }
        public Category(String name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExeceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(String name)
        {
            DomainExeceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExeceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            Name = name;
        }
    }
}
