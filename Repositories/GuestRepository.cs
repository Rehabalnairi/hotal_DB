using hotal_DB.Data;
using hotal_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotal_DB.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelContext _context;

        public GuestRepository(HotelContext context)
        {
            _context = context;
        }
        public void AddGuest(Guest guest)
        {
            _context.Guests.Add(guest);
            _context.SaveChanges();
        }
        public void UpdateGuest(Guest guest)
        {
            _context.Guests.Update(guest);
            _context.SaveChanges();
        }

        public void DeleteGuest(int guestid)
        {
            var guest = _context.Guests.Find(guestid);
            if (guest != null)
            {
                _context.Guests.Remove(guest);
                _context.SaveChanges();
            }

        }

        public Guest GetGuestById(int guestid)
        {
            return _context.Guests.Find(guestid);
        }

        public List<Guest> GetAllGuests()
        {
            return _context.Guests.ToList();
        }

    }
}
