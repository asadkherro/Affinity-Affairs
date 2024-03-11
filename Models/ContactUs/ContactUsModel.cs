using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ContactUs
{
    public record ContactUsModel
    {
        [Key]
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; init; } 
        public string Email { get; init; }
        public string Message {  get; init; }
    }
}
