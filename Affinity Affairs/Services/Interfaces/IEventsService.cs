using Models.Events;
using Models.EventUser;

namespace Affinity_Affairs.Services.Interfaces
{
    public interface IEventsService
    {
        Task<List<EventViewModel>> GetAllEvents(string? query = null);
        Task<EventModel> Post(EventInsertModel insertModel, byte[]? array = null);
        Task<EventModel> Get(Guid Id);
        Task<bool> Delete(Guid Id);
        Task<EventModel> Put(EventModel model);
        Task<EventUserModel> RegisterForEvent(Guid eventId, string userId);
        Task<List<EventUserModel>> GetAllAttendees();
        Task<List<EventViewModel>> GetUserEvents(string userId);
        Task<bool> CancelEventReservation(Guid eventId, string userId);
    }
}
