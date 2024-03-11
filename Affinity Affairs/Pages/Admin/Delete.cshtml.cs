using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Affinity_Affairs.Data;
using Models.Events;

namespace Affinity_Affairs.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly Affinity_Affairs.Data.ApplicationDbContext _context;

        public DeleteModel(Affinity_Affairs.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public EventModel EventModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var eventmodel = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);

            if (eventmodel == null)
            {
                return NotFound();
            }
            else 
            {
                EventModel = eventmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }
            var eventmodel = await _context.Events.FindAsync(id);

            if (eventmodel != null)
            {
                EventModel = eventmodel;
                _context.Events.Remove(EventModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
