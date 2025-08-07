using System.Collections.Generic;
using System.Linq;
using hotal_DB.Data;
using hotal_DB.Models;
using Microsoft.EntityFrameworkCore;

namespace hotal_DB.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelContext _context;

        public BookingRepository(HotelContext context)
        {
            _context = context;
        }

        // Add a new booking
        public void Add(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        // Get all bookings
        public List<Booking> GetAll()
        {
            return _context.Bookings
                           .Include(b => b.Guest)
                           .Include(b => b.Room)
                           .ToList();
        }

        // Get booking by ID
        public Booking GetById(int id)
        {
            return _context.Bookings
                           .Include(b => b.Guest)
                           .Include(b => b.Room)
                           .FirstOrDefault(b => b.Id == id);
        }

        // Update a booking
        public void Update(Booking booking)
        {
            var existing = _context.Bookings.Find(booking.Id);
            if (existing != null)
            {
                existing.RoomId = booking.RoomId;
                existing.GuestId = booking.GuestId;
                existing.StartDate = booking.StartDate;
                existing.EndDate = booking.EndDate;
                existing.roomNumber = booking.roomNumber;
                _context.SaveChanges();
            }
        }

        // Delete a booking
        public void Delete(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }
    }
}
