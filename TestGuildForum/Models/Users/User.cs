using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuildForum.Models.Groups;

namespace GuildForum.Models.Users {
  public class User {

    [Key, Column("user_id")]
    public int UserID { get; set; }

    [Required, Column("identity_id")]
    public string IdentityID { get; set; }

    [Required, Column("group_id")]
    public int GroupID { get; set; }

    [Required]
    public string Nick { get; set; }

    [Required, Column("registration_date")]
    public DateTime RegistrationDate { get; set; }

    public byte[] Avatar { get; set; }

    [Column("numbers_of_posts")]
    public int NumbersOfPosts { get; set; }

    public bool Ban { get; set; } = false;

    public ApplicationUser ApplicationUser { get; set; }

    public Group  Group { get; set; }
  }
}
