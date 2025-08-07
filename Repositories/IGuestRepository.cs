using hotal_DB.Models;

namespace hotal_DB.Repositories
{
    public interface IGuestRepository
    {
        void AddGuest(Guest guest);
        void DeleteGuest(int guestid);
        List<Guest> GetAllGuests();
        Guest GetGuestById(int guestid);
        void UpdateGuest(Guest guest);
    }
}