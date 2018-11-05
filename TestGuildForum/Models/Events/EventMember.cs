using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuildForum.Models.Users;

namespace GuildForum.Models.Events {
  [Table("event_members")]
  public class EventMember {

    [Column("event_id")]
    public int EventID { get; set; }

    [Required, Column("user_id")]
    public int UserID { get; set; }

    [Required]
    public string Standby { get; set; }

    public User User { get; set; }
  }
}
