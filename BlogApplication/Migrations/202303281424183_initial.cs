namespace BlogApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.content",
                c => new
                    {
                        postId = c.Guid(nullable: false),
                        authorId = c.Guid(nullable: false),
                        title = c.String(),
                        rating = c.Int(nullable: false),
                        source = c.String(),
                        User_userId = c.Guid(),
                    })
                .PrimaryKey(t => t.postId)
                .ForeignKey("dbo.User", t => t.User_userId)
                .Index(t => t.User_userId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        userId = c.Guid(nullable: false),
                        userName = c.String(),
                        password = c.String(),
                        isAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.content", "User_userId", "dbo.User");
            DropIndex("dbo.content", new[] { "User_userId" });
            DropTable("dbo.User");
            DropTable("dbo.content");
        }
    }
}
