using hotal_DB.Models;

namespace hotal_DB.Repositories
{
    internal interface IRoomRepostory
    {
        void AddRoom(Room room);
        void DeleteRoom(int roomId);
        List<Room> GetAllRooms();
        Room GetRoomById(int roomId);
        List<Room> GetRoomsByType(string roomType);
        void UpdateRoom(Room room);
    }
}