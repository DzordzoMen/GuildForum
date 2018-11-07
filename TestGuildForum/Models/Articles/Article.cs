using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuildForum.Models.Users;

namespace GuildForum.Models.Articles {
  public class Article {

    [Key, Column("article_id")]
    public int ArticleID { get; set; }

    [Required, Column("post_date")]
    public DateTime PostDate { get; set; }

    [Required, Column("user_id")]
    public int UserID { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    public byte[] Photo { get; set; }

    public ICollection<ArticleComments> ArticleComments { get; set; }

    public User User { get; set; }
  }
}
