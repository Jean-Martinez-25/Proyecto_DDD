using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Application.DTOs
{
    
    public class CallDto
    {
        public Guid Id { get; set; }
        public DateTime TimeSnap {  get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Notes {  get; set; } = string.Empty;
        public string CustomerName {  get; set; } = string.Empty ;
    }
}
