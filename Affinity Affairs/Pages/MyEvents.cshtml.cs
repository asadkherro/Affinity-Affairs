using Affinity_Affairs.Data;
using Affinity_Affairs.Services;
using Affinity_Affairs.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Events;
using Models.EventUser;

namespace Affinity_Affairs.Pages
{
    [Authorize]
    public class MyEventsModel : PageModel
    {
        public IEnumerable<EventViewModel> Events { get; set; }
        public IEnumerable<EventUserModel> EventUsers { get; set; }
        private readonly IEventsService _eventsService;
        private readonly UserManager<ApplicationUser> _userManager;
        public MyEventsModel(IEventsService eventsService, UserManager<ApplicationUser> userManager)
        {
            _eventsService = eventsService; 
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            Events = await _eventsService.GetUserEvents(user.Id);
            EventUsers = await _eventsService.GetAllAttendees();
            return Page();
        }
        public async Task<IActionResult> OnPostCancelAsync(Guid Id)
        {
            var user = await _userManager.GetUserAsync(User);
            string userId = user.Id;
            await _eventsService.CancelEventReservation(Id, userId);
            return RedirectToPage("/EventDetail");
        }

    }
}
