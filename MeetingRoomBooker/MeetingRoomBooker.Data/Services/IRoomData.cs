using MeetingRoomBooker.Data.Models;
using System.Collections.Generic;

namespace MeetingRoomBooker.Data.Services
{
    public interface IRoomData
    {
        IEnumerable<Room> GetAll();
        Room GetRoom(int id);
        IEnumerable<Room> GetFreeRooms(bool status);
        IEnumerable<Room> GetTakenRooms(bool status);
        void UpdateStatus(RoomStatus roomStatus);
        void Add(Room room);
        void Delete(int id);
        void Update(Room room);
        RoomStatus GetRoomStatus(int id);
    }
}
