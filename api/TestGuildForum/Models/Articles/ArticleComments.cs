using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuildForum.Models.Users;

namespace GuildForum.Models.Articles {
  [Table("article_comments")]
  public class ArticleComments {

    [Key, Column("comment_id")]
    public int CommentID { get; set; }

    [Required, Column("article_id")]
    public int ArticleID { get; set; }

    [Required, Column("post_date")]
    public DateTime PostDate { get; set; }

    [Required, Column("user_id")]
    public int UserID { get; set; }

    [Required]
    public string Content { get; set; }

    public Article Article { get; set; }

    public User User { get; set; }
  }
}
