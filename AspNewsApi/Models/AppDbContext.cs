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
        public virtual DbSet<CategoryAudio> CategoryAudios { get; set; }
        public virtual DbSet<CategoryMatter> CategoryMatters { get; set; }
        public virtual DbSet<CategoryPhoto> CategoryPhotoes { get; set; }
        public virtual DbSet<CategoryVideo> CategoryVideos { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Matter> Matters { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TagAudio> TagAudios { get; set; }
        public virtual DbSet<TagMatter> TagMatters { get; set; }
        public virtual DbSet<TagPhoto> TagPhotoes { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagVideo> TagVideos { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Audio>()
                .HasMany(e => e.CategoryAudios)
                .WithRequired(e => e.Audio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Audio>()
                .HasMany(e => e.TagAudios)
                .WithRequired(e => e.Audio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.CategoryAudios)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.CategoryMatters)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.CategoryPhotoes)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.CategoryVideos)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Matter>()
                .HasMany(e => e.CategoryMatters)
                .WithRequired(e => e.Matter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Matter>()
                .HasMany(e => e.TagMatters)
                .WithRequired(e => e.Matter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Photo>()
                .HasMany(e => e.CategoryPhotoes)
                .WithRequired(e => e.Photo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Photo>()
                .HasMany(e => e.TagPhotoes)
                .WithRequired(e => e.Photo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.TagAudios)
                .WithRequired(e => e.Tag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.TagMatters)
                .WithRequired(e => e.Tag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.TagPhotoes)
                .WithRequired(e => e.Tag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.TagVideos)
                .WithRequired(e => e.Tag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Video>()
                .HasMany(e => e.CategoryVideos)
                .WithRequired(e => e.Video)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Video>()
                .HasMany(e => e.TagVideos)
                .WithRequired(e => e.Video)
                .WillCascadeOnDelete(false);
        }
    }
}
