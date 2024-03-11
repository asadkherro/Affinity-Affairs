using Affinity_Affairs.Data;
using Affinity_Affairs.Services.Interfaces;
using Models.BookEvent;
using Models.ContactUs;

namespace Affinity_Affairs.Services
{
    public class MiscService : IMiscService
    {
        private readonly ApplicationDbContext _context;
        public MiscService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BookEventModel> BookEvent(BookEventModel model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<ContactUsModel> ContactUs(ContactUsModel model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

    }
}
