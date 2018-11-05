using System.ComponentModel.DataAnnotations;

namespace GuildForum.Models.Users {
  public class LoginModel {
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
  }
}
