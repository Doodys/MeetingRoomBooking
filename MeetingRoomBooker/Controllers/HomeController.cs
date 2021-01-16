using MeetingRoomBooker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingRoomBooker.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoomData roomData;

        public HomeController(IRoomData roomData)
        {
            this.roomData = roomData;
        }
        public ActionResult Index()
        {
            var model = roomData.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "We did our best ~ non-web backend developers.";

            return View();
        }
    }
}