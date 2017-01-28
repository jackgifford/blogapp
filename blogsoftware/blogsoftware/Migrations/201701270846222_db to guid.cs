namespace blogsoftware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbtoguid : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Posts");
            AlterColumn("dbo.Posts", "PostID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Posts", "PostID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Posts");
            AlterColumn("dbo.Posts", "PostID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Posts", "PostID");
        }
    }
}
