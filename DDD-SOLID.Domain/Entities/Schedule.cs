using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Domain.Entities
{
    [Table("Schedule")]
    public class Schedule
    {
        public Guid Id {  get; set; }
        public Guid AgentId { get; set; }
        public Guid TimeSlotId { get; set; }
        public Guid CustomerId { get; set; }
        public string Status { get; set; }
        public DateTime Creation {  get; set; }
        //Navegacion
        public Agent? Agent { get; set; }
        public Customer? Customer { get; set; }
        public TimeSlot? TimeSlot { get; set; }
    }
}
