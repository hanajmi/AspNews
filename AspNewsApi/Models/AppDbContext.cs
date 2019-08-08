namespace AspNewsApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        public virtual DbSet<Audio> Audios { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Matter> Matters { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Audio>()
                .HasMany(e => e.Categories)
                .WithMany(e => e.Audios)
                .Map(m => m.ToTable("CategoryAudio").MapLeftKey("AudioId").MapRightKey("CategoryId"));

            modelBuilder.Entity<Audio>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Audios)
                .Map(m => m.ToTable("TagAudio").MapLeftKey("AudioId").MapRightKey("TagId"));

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Matters)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("CategoryMatter").MapLeftKey("CategoryId").MapRightKey("MatterId"));

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Photos)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("CategoryPhoto").MapLeftKey("CategoryId").MapRightKey("PhotoId"));

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Videos)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("CategoryVideo").MapLeftKey("CategoryId").MapRightKey("VideoId"));

            modelBuilder.Entity<Matter>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Matters)
                .Map(m => m.ToTable("TagMatter").MapLeftKey("MatterId").MapRightKey("TagId"));

            modelBuilder.Entity<Photo>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Photos)
                .Map(m => m.ToTable("TagPhoto").MapLeftKey("PhotoId").MapRightKey("TagId"));

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.Videos)
                .WithMany(e => e.Tags)
                .Map(m => m.ToTable("TagVideo").MapLeftKey("TagId").MapRightKey("VideoId"));

            modelBuilder.Entity<User>()
                .HasMany(e => e.Audios)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Files)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Matters)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Photos)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Videos)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
