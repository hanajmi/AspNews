namespace AspNewsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Lead = c.String(maxLength: 1000),
                        Body = c.String(),
                        SlideShow = c.Boolean(),
                        Type = c.String(nullable: false, maxLength: 50),
                        UserId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        UpdatedAt = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CategoryAudio",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        AudioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.CategoryId, t.AudioId })
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Audios", t => t.AudioId)
                .Index(t => t.CategoryId)
                .Index(t => t.AudioId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        UpdatedAt = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryMatter",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        MatterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.CategoryId, t.MatterId })
                .ForeignKey("dbo.Matters", t => t.MatterId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.MatterId);
            
            CreateTable(
                "dbo.Matters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopTitle = c.String(maxLength: 100),
                        Title = c.String(nullable: false, maxLength: 255),
                        Lead = c.String(maxLength: 1000),
                        Body = c.String(),
                        SlideShow = c.Boolean(),
                        Type = c.String(nullable: false, maxLength: 50),
                        UserId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        UpdatedAt = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Uri = c.String(nullable: false, maxLength: 255),
                        Mime = c.String(nullable: false, maxLength: 255),
                        Size = c.Long(nullable: false),
                        Type = c.String(nullable: false, maxLength: 255),
                        CreatedAt = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        UpdatedAt = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        UserID = c.Int(nullable: false),
                        MatterId = c.Int(),
                        PhotoId = c.Int(),
                        VideoId = c.Int(),
                        AudioId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Audios", t => t.AudioId)
                .ForeignKey("dbo.Matters", t => t.MatterId)
                .ForeignKey("dbo.Photos", t => t.PhotoId)
                .ForeignKey("dbo.Videos", t => t.VideoId)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.MatterId)
                .Index(t => t.PhotoId)
                .Index(t => t.VideoId)
                .Index(t => t.AudioId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Lead = c.String(maxLength: 1000),
                        Body = c.String(),
                        SlideShow = c.Boolean(),
                        Type = c.String(nullable: false, maxLength: 50),
                        UserId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        UpdatedAt = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CategoryPhoto",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        PhotoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.CategoryId, t.PhotoId })
                .ForeignKey("dbo.Photos", t => t.PhotoId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.TagPhoto",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                        PhotoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.TagId, t.PhotoId })
                .ForeignKey("dbo.Tags", t => t.TagId)
                .ForeignKey("dbo.Photos", t => t.PhotoId)
                .Index(t => t.TagId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        UpdatedAt = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagAudio",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                        AudioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.TagId, t.AudioId })
                .ForeignKey("dbo.Tags", t => t.TagId)
                .ForeignKey("dbo.Audios", t => t.AudioId)
                .Index(t => t.TagId)
                .Index(t => t.AudioId);
            
            CreateTable(
                "dbo.TagMatter",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                        MatterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.TagId, t.MatterId })
                .ForeignKey("dbo.Tags", t => t.TagId)
                .ForeignKey("dbo.Matters", t => t.MatterId)
                .Index(t => t.TagId)
                .Index(t => t.MatterId);
            
            CreateTable(
                "dbo.TagVideo",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                        VideoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.TagId, t.VideoId })
                .ForeignKey("dbo.Videos", t => t.VideoId)
                .ForeignKey("dbo.Tags", t => t.TagId)
                .Index(t => t.TagId)
                .Index(t => t.VideoId);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Lead = c.String(maxLength: 1000),
                        Body = c.String(),
                        SlideShow = c.Boolean(),
                        Type = c.String(nullable: false, maxLength: 50),
                        UserId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        UpdatedAt = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CategoryVideo",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        VideoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.CategoryId, t.VideoId })
                .ForeignKey("dbo.Videos", t => t.VideoId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.VideoId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Mobile = c.Long(nullable: false),
                        Email = c.String(maxLength: 255),
                        Passwod = c.String(nullable: false, maxLength: 255),
                        CreatedAt = c.DateTime(storeType: "smalldatetime"),
                        UpdatedAt = c.DateTime(storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagAudio", "AudioId", "dbo.Audios");
            DropForeignKey("dbo.CategoryAudio", "AudioId", "dbo.Audios");
            DropForeignKey("dbo.CategoryVideo", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CategoryPhoto", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CategoryMatter", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.TagMatter", "MatterId", "dbo.Matters");
            DropForeignKey("dbo.TagPhoto", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.TagVideo", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Videos", "UserId", "dbo.Users");
            DropForeignKey("dbo.Photos", "UserId", "dbo.Users");
            DropForeignKey("dbo.Matters", "UserId", "dbo.Users");
            DropForeignKey("dbo.Files", "UserID", "dbo.Users");
            DropForeignKey("dbo.Audios", "UserId", "dbo.Users");
            DropForeignKey("dbo.TagVideo", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.Files", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.CategoryVideo", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.TagPhoto", "TagId", "dbo.Tags");
            DropForeignKey("dbo.TagMatter", "TagId", "dbo.Tags");
            DropForeignKey("dbo.TagAudio", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Files", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.CategoryPhoto", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.Files", "MatterId", "dbo.Matters");
            DropForeignKey("dbo.Files", "AudioId", "dbo.Audios");
            DropForeignKey("dbo.CategoryMatter", "MatterId", "dbo.Matters");
            DropForeignKey("dbo.CategoryAudio", "CategoryId", "dbo.Categories");
            DropIndex("dbo.CategoryVideo", new[] { "VideoId" });
            DropIndex("dbo.CategoryVideo", new[] { "CategoryId" });
            DropIndex("dbo.Videos", new[] { "UserId" });
            DropIndex("dbo.TagVideo", new[] { "VideoId" });
            DropIndex("dbo.TagVideo", new[] { "TagId" });
            DropIndex("dbo.TagMatter", new[] { "MatterId" });
            DropIndex("dbo.TagMatter", new[] { "TagId" });
            DropIndex("dbo.TagAudio", new[] { "AudioId" });
            DropIndex("dbo.TagAudio", new[] { "TagId" });
            DropIndex("dbo.TagPhoto", new[] { "PhotoId" });
            DropIndex("dbo.TagPhoto", new[] { "TagId" });
            DropIndex("dbo.CategoryPhoto", new[] { "PhotoId" });
            DropIndex("dbo.CategoryPhoto", new[] { "CategoryId" });
            DropIndex("dbo.Photos", new[] { "UserId" });
            DropIndex("dbo.Files", new[] { "AudioId" });
            DropIndex("dbo.Files", new[] { "VideoId" });
            DropIndex("dbo.Files", new[] { "PhotoId" });
            DropIndex("dbo.Files", new[] { "MatterId" });
            DropIndex("dbo.Files", new[] { "UserID" });
            DropIndex("dbo.Matters", new[] { "UserId" });
            DropIndex("dbo.CategoryMatter", new[] { "MatterId" });
            DropIndex("dbo.CategoryMatter", new[] { "CategoryId" });
            DropIndex("dbo.CategoryAudio", new[] { "AudioId" });
            DropIndex("dbo.CategoryAudio", new[] { "CategoryId" });
            DropIndex("dbo.Audios", new[] { "UserId" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Users");
            DropTable("dbo.CategoryVideo");
            DropTable("dbo.Videos");
            DropTable("dbo.TagVideo");
            DropTable("dbo.TagMatter");
            DropTable("dbo.TagAudio");
            DropTable("dbo.Tags");
            DropTable("dbo.TagPhoto");
            DropTable("dbo.CategoryPhoto");
            DropTable("dbo.Photos");
            DropTable("dbo.Files");
            DropTable("dbo.Matters");
            DropTable("dbo.CategoryMatter");
            DropTable("dbo.Categories");
            DropTable("dbo.CategoryAudio");
            DropTable("dbo.Audios");
        }
    }
}
