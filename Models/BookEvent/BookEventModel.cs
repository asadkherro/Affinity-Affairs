using Models.Enumeration;
using System.ComponentModel.DataAnnotations;

namespace Models.BookEvent
{
    public record BookEventModel
    {
        [Key]
        public Guid Id { get; init; } = Guid.NewGuid();
        public EventCategory Category { get; init; }
        public string Name {  get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
        public string Message { get; init; }
    }
}
