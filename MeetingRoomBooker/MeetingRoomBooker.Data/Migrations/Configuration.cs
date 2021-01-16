namespace MeetingRoomBooker.Data.Migrations
{
    using MeetingRoomBooker.Data.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MeetingRoomBooker.Data.Services.RoomDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MeetingRoomBooker.Data.Services.RoomDbContext context)
        {
            context.RoomTypes.SeedEnumValues<RoomType, RoomTypeEnum>(@enum => @enum);
            context.SaveChanges();
        }
    }
}
