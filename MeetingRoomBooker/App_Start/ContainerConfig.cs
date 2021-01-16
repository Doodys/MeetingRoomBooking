using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using MeetingRoomBooker.Data.Services;
using System.Web.Http;
using System.Web.Mvc;

namespace MeetingRoomBooker.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            //always remember about RegisterType for dbContext and sqlData of dbContext and interface
            builder.RegisterType<SqlRoomData>() // every time someone calls (...)
                .As<IRoomData>() // return it as (...)
                .InstancePerRequest(); // and create many instances (many users)
                                       //.SingleInstance(); // or create single instance of it (single is for app only for one user!)
            builder.RegisterType<RoomDbContext>().InstancePerRequest(); // continuation for above InstancePerRequest

            var container = builder.Build(); // whenever mvc needs to resolve dependencies - it should use this container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}