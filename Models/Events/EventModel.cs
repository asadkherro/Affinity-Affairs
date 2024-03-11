using Models.Images;
using System.ComponentModel.DataAnnotations;

namespace Models.Events
{
    public record EventModel : EventInsertModel
    {
        public EventModel()
        {
                
        }
        public EventModel(EventInsertModel model) : base(model)
        {
            
        }
        [Key]
        public Guid Id { get; init; } = Guid.NewGuid(); 
        public ImagesModel Image { get; init; }
    }
}
