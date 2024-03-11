using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Affinity_Affairs.Data;
using Models.Events;

namespace Affinity_Affairs.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly Affinity_Affairs.Data.ApplicationDbContext _context;

        public EditModel(Affinity_Affairs.Data.ApplicationDbContext context)
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

            var eventmodel =  await _context.Events.FirstOrDefaultAsync(m => m.Id == id);
            if (eventmodel == null)
            {
                return NotFound();
            }
            EventModel = eventmodel;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(EventModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventModelExists(EventModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EventModelExists(Guid id)
        {
          return (_context.Events?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
