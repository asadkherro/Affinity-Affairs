using Affinity_Affairs.Data;
using Affinity_Affairs.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Events;
using Models.EventUser;
using Models.Images;

namespace Affinity_Affairs.Services
{
    public class EventsService : IEventsService
    {
        private readonly ApplicationDbContext _context;
        public EventsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<EventViewModel>> GetAllEvents(string? query = null)
        {
            var events = _context.Events.Include(x=> x.Image).ToListAsync().GetAwaiter().GetResult();
            var eventUser = _context.EventUsers.ToListAsync().GetAwaiter().GetResult();
            var response = new List<EventViewModel>();
            foreach (var item in events)
            {
                var result = new EventViewModel(item)
                {
                    EventUsers = eventUser.FirstOrDefault(x=>x.EventId == item.Id),
                    TotalAttendees = eventUser.Where(x=>x.EventId == item.Id).Count()
                };
                response.Add(result);
            }
            if(!string.IsNullOrEmpty(query))
            {
                response = response.Where(x => x.Name.ToLower().Contains(query.ToLower())).ToList();
            }
            return response;
        }
        public async Task<EventModel> Post(EventInsertModel insertModel, byte[]? array = null)
        {
            EventModel model = new EventModel(insertModel);
            if (array != null)
            {
                ImagesModel imageModel = new ImagesModel() { Data = array , EntityId = model.Id, Id = Guid.NewGuid() };
                model = model with { Image = imageModel };
            }
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();  
            return model;
        }
        public async Task<EventModel> Get(Guid Id)
        {
            var result = await _context.Events.FirstOrDefaultAsync(x => x.Id == Id);
            return result;
        }
        public async Task<bool> Delete(Guid Id)
        {
            var result = await _context.Events.FirstOrDefaultAsync(x => x.Id == Id);
            if (result != null) 
            {
                _context.Events.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<EventModel> Put(EventModel model)
        {
            var result = await _context.Events.FirstOrDefaultAsync(x => x.Id == model.Id);
            if ( result != null )
            {
                _context.Entry(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return model;
        }
        public async Task<EventUserModel> RegisterForEvent(Guid eventId, string userId)
        {
            var model = new EventUserModel() { EventId = eventId , UserId = userId};
            await _context.AddAsync(model); 
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<List<EventUserModel>> GetAllAttendees()
        {
            var result = _context.EventUsers.ToListAsync().GetAwaiter().GetResult();
            return result;
        }
        public async Task<List<EventViewModel>> GetUserEvents(string userId)
        {
            var events = await GetAllEvents();
            return events.Where(x=> x.EventUsers!=null && x.EventUsers.UserId == userId).ToList();
        }
        public async Task<bool> CancelEventReservation(Guid eventId, string userId)
        {
            var result = _context.EventUsers.FirstOrDefaultAsync(x => x.EventId == eventId && x.UserId == userId).GetAwaiter().GetResult();
            if (result==null)
            {
                return false;
            }
            _context.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
