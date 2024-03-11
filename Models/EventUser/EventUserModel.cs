using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EventUser
{
    
    public record EventUserModel
    {
        public Guid EventId { get; init; }
        public string UserId { get; init; }
    }
}
