using Microsoft.EntityFrameworkCore;
using GuildForum.Models.Articles;
using GuildForum.Models.Events;
using GuildForum.Models.Ranks;
using GuildForum.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace GuildForum.Models {
  public class ForumContext : IdentityDbContext<ApplicationUser> {

    //public DbSet<SettingsDataModel> Settings { get; set; }

    public ForumContext(DbContextOptions<ForumContext> options) : base(options) {
    }

    public DbSet<Article> Articles { get; set; }
    public DbSet<ArticleComments> ArticleCommentses { get; set; }
    public DbSet<Rank> Ranks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventMember> EventMembers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<EventMember>()
        .HasKey(m => new {m.EventID, m.UserID});

      base.OnModelCreating(modelBuilder);
    }
  }
}
