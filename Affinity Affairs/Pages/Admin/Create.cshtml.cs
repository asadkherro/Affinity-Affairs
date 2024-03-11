using Affinity_Affairs.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Events;

namespace Affinity_Affairs.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly IEventsService _eventsService;
        public CreateModel(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EventInsertModel InsertModel { get; set; } = default!;
        [BindProperty]
        public IFormFile Image { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fileBytes = await GetFileBytesAsync(Image);
                    await _eventsService.Post(InsertModel, fileBytes);
                    return RedirectToPage("/Events");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error creating event: " + ex.Message);
                }
            }
            return Page();
        }
        private async Task<byte[]> GetFileBytesAsync(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var memoryStream = new MemoryStream();
                    await stream.CopyToAsync(memoryStream);
                    return memoryStream.ToArray();
                }
            }
            return null;
        }
    }
}
