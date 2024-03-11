using Affinity_Affairs.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.ContactUs;

namespace Affinity_Affairs.Pages
{
    public class ContactUsPageModel : PageModel
    {
        private readonly IMiscService _service;
        [BindProperty]
        public ContactUsModel ContactUs { get; set; }
        public ContactUsPageModel(IMiscService service)
        {
            _service = service;
        }
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPost() 
        {
            await _service.ContactUs(ContactUs);
            return RedirectToPage();
        }
    }
}
