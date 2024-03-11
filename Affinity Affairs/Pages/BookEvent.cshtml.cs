using Affinity_Affairs.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.BookEvent;

namespace Affinity_Affairs.Pages
{
    public class BookEventPageModel : PageModel
    {
        private readonly IMiscService _miscService;
        [BindProperty]
        public BookEventModel BookEvent { get; set; }
        public BookEventPageModel(IMiscService miscService)
        {
            _miscService = miscService;
        }
        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPost() 
        {
            await _miscService.BookEvent(BookEvent);
            return RedirectToPage();
        }


    }
}
