using System.Linq;
using GuildForum.Models;
using GuildForum.Models.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuildForum.Controllers {
  [Route("api/event/")]
  [ApiController]
  public class EventMemberController : Controller {

    private readonly ForumContext _context;

    public EventMemberController(ForumContext context) {
      _context = context;
    }

    [HttpGet("{idEvent}/members")]
    public IActionResult GetEventMembers(int idEvent) {
      var guildEvent = _context.Events
        .Include(m => m.EventMembers)
        .ThenInclude(m => m.User)
        .ThenInclude(u => u.Rank)
        .Select(e => new {
          e.EventID, 
          e.EventDate, 
          e.EventDescription, 
          e.EventName, 
          e.User.Nick, 
          e.User.Rank.RankName, 
          e.User.Avatar, 
          eventMembers = e.EventMembers
            .Select(m => new {
              m.EventID, 
              m.Standby, 
              m.User.Nick, 
              m.User.Rank.RankName, 
              m.User.Avatar
            })
        })
        .SingleOrDefault(e => e.EventID == idEvent);
      if (guildEvent == null) return NotFound();
      return Ok(guildEvent);
    }

    [HttpPost("{idEvent}/members")]
    public IActionResult AddMember(int idEvent, EventMember member) {
      if (_context.Events.Find(idEvent) == null) return NotFound();

      member.EventID = idEvent;

      _context.EventMembers.Add(member);
      _context.SaveChanges();
      return Ok();
    }

    [HttpPut("{idEvent}/members/{idMember}")]
    public IActionResult UpdateMember(int idEvent, int idMember, EventMember member) {
      var eventMember = _context.EventMembers
        .SingleOrDefault(m => m.EventID == idEvent && m.UserID == idMember);
      if (eventMember == null) return NotFound();

      eventMember.Standby = member.Standby;
      _context.EventMembers.Update(eventMember);
      _context.SaveChanges();

      return Ok();
    }

    [HttpDelete("{idEvent}/members/{idMember}")]
    public IActionResult RemoveMember(int idEvent, int idMember) {
      var eventMember = _context.EventMembers
        .SingleOrDefault(m => m.EventID == idEvent && m.UserID == idMember);
      if (eventMember == null) return NotFound();

      eventMember.Standby = "Odrzucono";

      _context.EventMembers.Update(eventMember);
      _context.SaveChanges();
      return Ok();
    }
  }
}