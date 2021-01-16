namespace MeetingRoomBooker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hostMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        Number = c.String(nullable: false, maxLength: 6),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoomTypes", t => t.TypeId)
                .Index(t => t.TypeId); ;
            
            CreateTable(
                "dbo.RoomStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        MeetingStart = c.DateTime(),
                        MeetingEnd = c.DateTime(),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomStatus", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.RoomStatus", new[] { "Room_Id" });
            DropTable("dbo.RoomTypes");
            DropTable("dbo.RoomStatus");
            DropTable("dbo.Rooms");
        }
    }
}
