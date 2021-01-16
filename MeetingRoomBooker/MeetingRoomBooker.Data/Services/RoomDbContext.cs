using MeetingRoomBooker.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingRoomBooker.Data.Services
{
    public class RoomDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomStatus> RoomStatus { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
    }
}
