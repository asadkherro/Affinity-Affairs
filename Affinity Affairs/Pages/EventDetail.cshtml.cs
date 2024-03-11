using Affinity_Affairs.Data;
using Affinity_Affairs.Services;
using Affinity_Affairs.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Events;
using Models.EventUser;
using System.Web;

namespace Affinity_Affairs.Pages
{
    public class EventDetailModel : PageModel
    {
        private readonly IEventsService _eventService;
        private readonly UserManager<ApplicationUser> _userManager;
        public IEnumerable<EventViewModel> Events { get; set; }
        public IEnumerable<EventUserModel> EventUsers { get; set; }
        public EventDetailModel(IEventsService eventsService, UserManager<ApplicationUser> userManager)
        {
            _eventService = eventsService;
            _userManager = userManager;
        }
        public async void OnGet(string? searchTerm)
        {
            var SearchTerm = HttpUtility.UrlEncode(searchTerm);
            Events = await _eventService.GetAllEvents(SearchTerm);
            EventUsers = await _eventService.GetAllAttendees();
        }
        public async Task<IActionResult> OnPostRegisterAsync(Guid Id)
        {
            var user = await _userManager.GetUserAsync(User);
            string userId = user.Id;
            await _eventService.RegisterForEvent(Id, userId);
            return RedirectToPage("/EventDetail");
        }
        public async Task<IActionResult> OnPostCancelAsync(Guid Id)
        {
            var user = await _userManager.GetUserAsync(User);
            string userId = user.Id;
            await _eventService.CancelEventReservation(Id, userId);
            return RedirectToPage("/EventDetail");
        }

    }
}
