using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Domain.Entities
{
    [Table("Agent")]
    public class Agent
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "Agent"; // Puedes usar "Supervisor", "Admin", etc.

        // Navegación (opcional)
        public ICollection<Schedule>? Schedules { get; set; }
    }
}
