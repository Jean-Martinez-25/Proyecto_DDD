using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Domain.Entities
{
    [Table("Call")]
    public class Call
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty ;
        public Customer? Customer { get; set; }
    }
}
