using rezerwacje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEventCalendar.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Choice()
        {
            return View();
        }
        public ActionResult Index(Events e)
        {
            return View(e);
        }

        public JsonResult GetEvents(string Room)
        {
            using (rpanczak3_rezerwacja_salEntities2 dc = new rpanczak3_rezerwacja_salEntities2())
            {
                var events = dc.Events.Where(x => x.Room == Room).ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(Events e)
        {
            var status = false;
            using (rpanczak3_rezerwacja_salEntities2 dc = new rpanczak3_rezerwacja_salEntities2())
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = dc.Events.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start_date = e.Start_date;
                        v.End_date = e.End_date;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                        v.Room = e.Room;
                    }
                }
                else
                {
                    dc.Events.Add(e);
                }

                dc.SaveChanges();
                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (rpanczak3_rezerwacja_salEntities2 dc = new rpanczak3_rezerwacja_salEntities2())
            {
                var v = dc.Events.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.Events.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status} };
        }
    }
}