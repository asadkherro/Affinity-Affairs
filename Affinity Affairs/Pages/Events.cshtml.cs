using Affinity_Affairs.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Events;

namespace Affinity_Affairs.Pages
{
    public class EventsPageModel : PageModel
    {
        private readonly IEventsService _eventService;
        public EventsPageModel(IEventsService eventsService)
        {
            _eventService = eventsService;
        }
        public IEnumerable<EventModel> Events { get; set; }
        public async void OnGetAsync()
        {
            Events = await _eventService.GetAllEvents();
        }
        public async Task<IActionResult> OnPostDeleteAsync(Guid Id)
        {
            await _eventService.Delete(Id);
            return RedirectToPage("/Events");
        }

    }
}
