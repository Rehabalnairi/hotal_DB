using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotal_DB.Data;
using hotal_DB.Models;

namespace hotal_DB.Repositories
{
    class RoomRepostory : IRoomRepostory

    {
        private readonly HotelContext _context;
        public RoomRepostory(HotelContext context)
        {
            _context = context;
        }

        // Add a new room
        public void AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }
        // Get all rooms
        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }
        // Get room by ID
        public Room GetRoomById(int roomId)
        {
            return _context.Rooms.Find(roomId);
        }
        // Update a room
        public void UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            _context.SaveChanges();
        }
        // Delete a room
        public void DeleteRoom(int roomId)
        {
            var room = _context.Rooms.Find(roomId);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }
        // Get rooms by type
        public List<Room> GetRoomsByType(string roomType)
        {
            return _context.Rooms.Where(r => r.RoomType == roomType).ToList();
        }
    }
}
