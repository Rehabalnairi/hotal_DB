using hotal_DB.Models;

namespace hotal_DB.Repositories
{
    public interface IBookingRepository
    {
        void Add(Booking booking);
        void Delete(int id);
        List<Booking> GetAll();
        Booking GetById(int id);
        void Update(Booking booking);
    }
}