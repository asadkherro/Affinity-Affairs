using Models.BookEvent;
using Models.ContactUs;

namespace Affinity_Affairs.Services.Interfaces
{
    public interface IMiscService
    {
        Task<ContactUsModel> ContactUs(ContactUsModel model);
        Task<BookEventModel> BookEvent(BookEventModel model);
    }
}
