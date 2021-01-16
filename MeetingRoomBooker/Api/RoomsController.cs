using MeetingRoomBooker.Data.Models;
using MeetingRoomBooker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MeetingRoomBooker.Web
{
    public class RoomsController : ApiController
    {
        private readonly IRoomData roomData;

        public RoomsController(IRoomData roomData)
        {
            this.roomData = roomData;
        }
        public IEnumerable<Room> Get()
        {
            var model = roomData.GetAll();
            return model;
        }
    }
}