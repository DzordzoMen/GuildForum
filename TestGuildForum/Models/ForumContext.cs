using Microsoft.EntityFrameworkCore;
using GuildForum.Models.Articles;
using GuildForum.Models.Events;
using GuildForum.Models.Ranks;
using GuildForum.Models.Users;


namespace GuildForum.Models {
  public class ForumContext : DbContext {

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
    }
  }
}
