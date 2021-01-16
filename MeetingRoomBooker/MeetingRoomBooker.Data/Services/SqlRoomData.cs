using MeetingRoomBooker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace MeetingRoomBooker.Data.Services
{
    public class SqlRoomData : IRoomData
    {
        private readonly RoomDbContext dbContext;

        public SqlRoomData(RoomDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Room room)
        {
            dbContext.Rooms.Add(room);

            dbContext.RoomStatus.Add(
                new RoomStatus
                    {
                        Id = room.Id,
                        Room = room,
                        Status = room.Status,
                        MeetingStart = null,
                        MeetingEnd = null
                    });

            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var room = dbContext.Rooms.Find(id);
            var roomStatus = dbContext.RoomStatus.Find(id);
            dbContext.Rooms.Remove(room);
            dbContext.RoomStatus.Remove(roomStatus);
            dbContext.SaveChanges();
        }

        public IEnumerable<Room> GetAll()
        {
            return dbContext.Rooms.OrderBy(r => r.Id);
        }

        public IEnumerable<Room> GetFreeRooms(bool status)
        {
            return dbContext.Rooms.Where(r => r.Status == false).ToList();
        }

        public Room GetRoom(int id)
        {
            return dbContext.Rooms.FirstOrDefault(r => r.Id == id);
        }

        public RoomStatus GetRoomStatus(int id)
        {
            var roomStatus = dbContext.RoomStatus.FirstOrDefault(rs => rs.Id == id);
            roomStatus.Room = dbContext.Rooms.FirstOrDefault(r => r.Id == id);
            return roomStatus;
        }

        public IEnumerable<Room> GetTakenRooms(bool status)
        {
            return dbContext.Rooms.Where(r => r.Status == true).ToList();
        }

        public void Update(Room room)
        {
            var entry = dbContext.Entry(room); // get entry of modification on current object
            entry.State = EntityState.Modified; // tell the system that given object is currently modified
            dbContext.SaveChanges();
        }

        public void UpdateStatus(RoomStatus roomStatus)
        {
            var entryStatus = dbContext.Entry(roomStatus);
            entryStatus.State = EntityState.Modified;

            var room = dbContext.Rooms.FirstOrDefault(r => r.Id == roomStatus.Id);
            room.Status = true;

            var entryRoom = dbContext.Entry(room);
            entryRoom.State = EntityState.Modified;

            dbContext.SaveChanges();
        }
    }
}
