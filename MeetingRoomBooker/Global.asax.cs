using MeetingRoomBooker.Data.Services;
using MeetingRoomBooker.Web;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MeetingRoomBooker
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SqlConnection.ClearAllPools();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<RoomDbContext>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register); // this one has to be above RouteConfig!!!
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ContainerConfig.RegisterContainer(GlobalConfiguration.Configuration);
        }
    }
}
