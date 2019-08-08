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
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
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
                .ForeignKey("dbo.Users", t => t.UserId)
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
                        UserId = c.Int(nullable: false),
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
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
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
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
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
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
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
            
            CreateTable(
                "dbo.TagVideo",
                c => new
                    {
                        TagId = c.Int(nullable: false),
                        VideoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagId, t.VideoId })
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.VideoId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.VideoId);
            
            CreateTable(
                "dbo.TagPhoto",
                c => new
                    {
                        PhotoId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PhotoId, t.TagId })
                .ForeignKey("dbo.Photos", t => t.PhotoId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.PhotoId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.TagMatter",
                c => new
                    {
                        MatterId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MatterId, t.TagId })
                .ForeignKey("dbo.Matters", t => t.MatterId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.MatterId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.CategoryMatter",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
                        MatterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryId, t.MatterId })
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Matters", t => t.MatterId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.MatterId);
            
            CreateTable(
                "dbo.CategoryPhoto",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
                        PhotoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryId, t.PhotoId })
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Photos", t => t.PhotoId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.CategoryVideo",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
                        VideoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryId, t.VideoId })
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.VideoId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.VideoId);
            
            CreateTable(
                "dbo.CategoryAudio",
                c => new
                    {
                        AudioId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AudioId, t.CategoryId })
                .ForeignKey("dbo.Audios", t => t.AudioId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.AudioId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.TagAudio",
                c => new
                    {
                        AudioId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AudioId, t.TagId })
                .ForeignKey("dbo.Audios", t => t.AudioId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.AudioId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagAudio", "TagId", "dbo.Tags");
            DropForeignKey("dbo.TagAudio", "AudioId", "dbo.Audios");
            DropForeignKey("dbo.CategoryAudio", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CategoryAudio", "AudioId", "dbo.Audios");
            DropForeignKey("dbo.CategoryVideo", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.CategoryVideo", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CategoryPhoto", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.CategoryPhoto", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CategoryMatter", "MatterId", "dbo.Matters");
            DropForeignKey("dbo.CategoryMatter", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.TagMatter", "TagId", "dbo.Tags");
            DropForeignKey("dbo.TagMatter", "MatterId", "dbo.Matters");
            DropForeignKey("dbo.TagPhoto", "TagId", "dbo.Tags");
            DropForeignKey("dbo.TagPhoto", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.TagVideo", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.TagVideo", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Videos", "UserId", "dbo.Users");
            DropForeignKey("dbo.Photos", "UserId", "dbo.Users");
            DropForeignKey("dbo.Matters", "UserId", "dbo.Users");
            DropForeignKey("dbo.Files", "UserId", "dbo.Users");
            DropForeignKey("dbo.Audios", "UserId", "dbo.Users");
            DropForeignKey("dbo.Files", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.Files", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.Files", "MatterId", "dbo.Matters");
            DropForeignKey("dbo.Files", "AudioId", "dbo.Audios");
            DropIndex("dbo.TagAudio", new[] { "TagId" });
            DropIndex("dbo.TagAudio", new[] { "AudioId" });
            DropIndex("dbo.CategoryAudio", new[] { "CategoryId" });
            DropIndex("dbo.CategoryAudio", new[] { "AudioId" });
            DropIndex("dbo.CategoryVideo", new[] { "VideoId" });
            DropIndex("dbo.CategoryVideo", new[] { "CategoryId" });
            DropIndex("dbo.CategoryPhoto", new[] { "PhotoId" });
            DropIndex("dbo.CategoryPhoto", new[] { "CategoryId" });
            DropIndex("dbo.CategoryMatter", new[] { "MatterId" });
            DropIndex("dbo.CategoryMatter", new[] { "CategoryId" });
            DropIndex("dbo.TagMatter", new[] { "TagId" });
            DropIndex("dbo.TagMatter", new[] { "MatterId" });
            DropIndex("dbo.TagPhoto", new[] { "TagId" });
            DropIndex("dbo.TagPhoto", new[] { "PhotoId" });
            DropIndex("dbo.TagVideo", new[] { "VideoId" });
            DropIndex("dbo.TagVideo", new[] { "TagId" });
            DropIndex("dbo.Videos", new[] { "UserId" });
            DropIndex("dbo.Photos", new[] { "UserId" });
            DropIndex("dbo.Files", new[] { "AudioId" });
            DropIndex("dbo.Files", new[] { "VideoId" });
            DropIndex("dbo.Files", new[] { "PhotoId" });
            DropIndex("dbo.Files", new[] { "MatterId" });
            DropIndex("dbo.Files", new[] { "UserId" });
            DropIndex("dbo.Matters", new[] { "UserId" });
            DropIndex("dbo.Audios", new[] { "UserId" });
            DropTable("dbo.TagAudio");
            DropTable("dbo.CategoryAudio");
            DropTable("dbo.CategoryVideo");
            DropTable("dbo.CategoryPhoto");
            DropTable("dbo.CategoryMatter");
            DropTable("dbo.TagMatter");
            DropTable("dbo.TagPhoto");
            DropTable("dbo.TagVideo");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Users");
            DropTable("dbo.Videos");
            DropTable("dbo.Tags");
            DropTable("dbo.Photos");
            DropTable("dbo.Files");
            DropTable("dbo.Matters");
            DropTable("dbo.Categories");
            DropTable("dbo.Audios");
        }
    }
}
