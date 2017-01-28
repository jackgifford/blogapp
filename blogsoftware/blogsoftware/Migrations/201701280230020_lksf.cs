namespace blogsoftware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lksf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "User_UserId", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "User_UserId" });
            RenameColumn(table: "dbo.Posts", name: "User_UserId", newName: "User_Username");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Posts", "User_Username", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Users", "Username");
            CreateIndex("dbo.Users", "Username", unique: true);
            CreateIndex("dbo.Posts", "User_Username");
            AddForeignKey("dbo.Posts", "User_Username", "dbo.Users", "Username");
            DropColumn("dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Posts", "User_Username", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "User_Username" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Posts", "User_Username", c => c.Int());
            AlterColumn("dbo.Users", "Username", c => c.String());
            AddPrimaryKey("dbo.Users", "UserId");
            RenameColumn(table: "dbo.Posts", name: "User_Username", newName: "User_UserId");
            CreateIndex("dbo.Posts", "User_UserId");
            AddForeignKey("dbo.Posts", "User_UserId", "dbo.Users", "UserId");
        }
    }
}
