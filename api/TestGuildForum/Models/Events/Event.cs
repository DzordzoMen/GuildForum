using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuildForum.Models.Users;

namespace GuildForum.Models.Events {
  public class Event {

    [Key, Column("event_id")]
    public int EventID { get; set; }

    [Required, Column("event_date")]
    public DateTime EventDate { get; set; }

    [Required, Column("event_name")]
    public string EventName { get; set; }

    [Column("event_description")]
    public string EventDescription { get; set; }

    [Required, Column("user_id")]
    public  int UserID{ get; set; }

    public ICollection<EventMember> EventMembers { get; set; }

    public User User { get; set; }
  }
}
