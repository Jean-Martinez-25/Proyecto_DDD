using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Domain.Entities
{
    [Table("Customers")]
    public class Customer
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Customer(string fullName, string email, string phoneNumber) { 
            Id = Guid.NewGuid();
            FullName = !string.IsNullOrWhiteSpace(fullName) ? fullName: throw new ArgumentException("El nombre es obligatorio");
            Email = email ??  throw new ArgumentException("El email es obligatorio"); ;
            PhoneNumber = phoneNumber ?? throw new ArgumentException("El numero telefonico es obligatorio"); ;
            CreatedAt = DateTime.Now;

        }
        public void UpdateContactoInfo(string email, string phoneNumber)
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
