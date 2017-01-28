namespace blogsoftware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedrelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "User_UserId", c => c.Int());
            CreateIndex("dbo.Posts", "User_UserId");
            AddForeignKey("dbo.Posts", "User_UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "User_UserId", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "User_UserId" });
            DropColumn("dbo.Posts", "User_UserId");
        }
    }
}
