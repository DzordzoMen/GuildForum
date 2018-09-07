using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuildForum.Models.Ranks {
  public class Rank {

    [Key, Column("rank_id")]
    public int RankID { get; set; }

    [Required, Column("rank_name")]
    public string RankName { get; set; }

  }
}
