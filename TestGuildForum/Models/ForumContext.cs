using Microsoft.EntityFrameworkCore;
using GuildForum.Models.Articles;
using GuildForum.Models.Events;
using GuildForum.Models.Groups;
using GuildForum.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace GuildForum.Models {
  public class ForumContext : IdentityDbContext<ApplicationUser> {

    //public DbSet<SettingsDataModel> Settings { get; set; }

    public ForumContext(DbContextOptions<ForumContext> options) : base(options) {
    }

    public DbSet<Article> Articles { get; set; }
    public DbSet<ArticleComments> ArticleCommentses { get; set; }
    public DbSet<IdentityRole> IdentityRoles { get; set; }
    public DbSet<IdentityUserRole<string>> IdentityUserRoles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventMember> EventMembers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<EventMember>()
        .HasKey(m => new {m.EventID, m.UserID});

      modelBuilder.Entity<ArticleComments>()
        .HasOne(a => a.Article)
        .WithMany(ac => ac.ArticleCommentses)
        .HasForeignKey(a => a.ArticleID)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Article>()
        .HasMany(ac => ac.ArticleCommentses)
        .WithOne(a => a.Article)
        .HasForeignKey(a => a.ArticleID)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<User>()
        .HasOne(u => u.ApplicationUser)
        .WithOne()
        .HasForeignKey<User>(u => u.IdentityID);
    }
  }
}
