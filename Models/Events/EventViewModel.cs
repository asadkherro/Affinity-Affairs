using Models.EventUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Events
{
    public record EventViewModel : EventModel
    {
        public EventViewModel()
        {
                
        }
        public EventViewModel(EventModel model) : base(model)
        {
                
        }
        public EventUserModel EventUsers { get; init; }
        public int TotalAttendees {  get; set; }
    }
}
