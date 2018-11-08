using System.ComponentModel.DataAnnotations;

namespace GuildForum.Models.Users {
  public class NewUserModel {

    [Required]
    public string UserName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
  }
}
