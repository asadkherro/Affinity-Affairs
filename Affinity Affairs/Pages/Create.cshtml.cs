using Affinity_Affairs.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Events;

namespace Affinity_Affairs.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public EventInsertModel InsertModel { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        private readonly IEventsService _eventsService;
        public CreateModel(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fileBytes = await GetFileBytesAsync(Image);
                    await _eventsService.Post(InsertModel, fileBytes);
                    return RedirectToPage("./events");
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
