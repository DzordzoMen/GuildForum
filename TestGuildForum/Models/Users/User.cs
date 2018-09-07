using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuildForum.Models.Ranks;

namespace GuildForum.Models.Users {
  public class User {

    [Key, Column("user_id")]
    public int UserID { get; set; }

    [Required, Column("rank_id")]
    public int RankID { get; set; }

    [Required]
    public string Login { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Nick { get; set; }

    [Required, Column("registration_date")]
    public DateTime RegistrationDate { get; set; }

    public byte[] Avatar { get; set; }

    [Column("numbers_of_posts")]
    public int NumbersOfPosts { get; set; }

    public bool Ban { get; set; } = false;

    public Rank Rank { get; set; }
  }
}
