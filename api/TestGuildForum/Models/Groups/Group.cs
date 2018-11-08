using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuildForum.Models.Groups {
  public class Group {

    [Required, Column("group_id")]
    public int GroupID { get; set; }

    [Required, Column("group_name")]
    public string GroupName { get; set; }
  }
}
