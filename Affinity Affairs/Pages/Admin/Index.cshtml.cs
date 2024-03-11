using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Affinity_Affairs.Data;
using Models.Events;
using Microsoft.AspNetCore.Authorization;

namespace Affinity_Affairs.Pages.Admin
{
    [Authorize(Roles ="Admin")]
    public class IndexModel : PageModel
    {
        private readonly Affinity_Affairs.Data.ApplicationDbContext _context;

        public IndexModel(Affinity_Affairs.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<EventModel> EventModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Events != null)
            {
                EventModel = await _context.Events.ToListAsync();
            }
        }
    }
}
