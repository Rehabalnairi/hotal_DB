using hotal_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotal_DB.Services
{
    interface IRoomService
    {
        //add business logic
        void AddRoom(Room room);
        void Update(Room romm);
        void DeleteRoom(int roomId);
        Room GetRoomById(int roomId);
        List<Room> GetAllRooms();
        List<Room> GetRoomsByType(string roomType);
    }
    }
