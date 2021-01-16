using MeetingRoomBooker.Data.Models;
using MeetingRoomBooker.Data.Services;
using System;
using System.Web.Mvc;

namespace MeetingRoomBooker.Controllers
{
    public class RoomsController : Controller
    {
        IRoomData roomData;

        public RoomsController(IRoomData roomData)
        {
            this.roomData = roomData;
        }

        public ActionResult Index()
        {
            var model = roomData.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = roomData.GetRoom(id);

            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // on every post operation!
        public ActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                roomData.Add(room);
                return RedirectToAction("Details", new { id = room.Id });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = roomData.GetRoom(id);

            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // on every post operation!
        public ActionResult Edit(Room room)
        {
            roomData.Update(room);
            return RedirectToAction("Index", roomData.GetAll());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = roomData.GetRoom(id);

            if (model == null)
            {
                return View("NotFound");
            }

            if(model.Status == true)
            {
                ModelState.AddModelError(nameof(model.Number), "This room is currently in status 'Booked'!");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form) // added FormCollection just to not to make compiler moody because of two identical Delete methods getting the same parameters
        {
            roomData.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Book(int id)
        {
            var model = roomData.GetRoomStatus(id);

            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // on every post operation!
        public ActionResult Book(RoomStatus roomStatus)
        {
            var msd = (DateTime)roomStatus.MeetingStartDay;
            var msh = (DateTime)roomStatus.MeetingStartHour;
            var med = (DateTime)roomStatus.MeetingEndDay;
            var meh = (DateTime)roomStatus.MeetingEndHour;

            roomStatus.MeetingStart = new DateTime(msd.Year, msd.Month, msd.Day, msh.Hour, msh.Minute, 0);
            roomStatus.MeetingEnd = new DateTime(med.Year, med.Month, med.Day, meh.Hour, meh.Minute, 0);

            if(roomStatus.MeetingStart <= roomStatus.MeetingEnd)
            {
                ModelState.AddModelError(nameof(roomStatus), "Wrong date selected!");
            }

            roomData.UpdateStatus(roomStatus);
            return RedirectToAction("Index", roomData.GetAll());
        }
    }
}