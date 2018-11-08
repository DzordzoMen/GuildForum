using System.Linq;
using GuildForum.Models;
using GuildForum.Models.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildForum.Controllers {
  [Route("api/event/")]
  [ApiController]
  public class EventMemberController : Controller {

    private readonly ForumContext _context;

    public EventMemberController(ForumContext context) {
      _context = context;
    }

    [AllowAnonymous]
    [HttpGet("{idEvent}/members")]
    public IActionResult GetEventMembers(int idEvent) {
      var guildEvent = _context.Events
        .Join(_context.Users,
          gEvent => gEvent.UserID,
          user => user.UserID,
          (gEvent, user) => new { gEvent, user })
        .GroupJoin(_context.EventMembers,
          entity => entity.gEvent.EventID,
          eventMembers => eventMembers.EventID,
          (entity, eventMembers) => new { entity.gEvent, entity.user, eventMembers })
        .Join(_context.Groups,
          entity => entity.user.GroupID,
          group => group.GroupID,
          (entity, group) => new { entity.user, entity.gEvent, entity.eventMembers, group })
        .GroupBy(entity => entity.gEvent.EventID)
        .Select(grouping => grouping.FirstOrDefault(entity => entity.gEvent.EventID == idEvent))
        .Where(entity => entity.gEvent.EventID == idEvent)
        .Select(entity => new {
          entity.gEvent.EventID,
          entity.gEvent.EventDate,
          entity.gEvent.EventDescription,
          entity.gEvent.EventName,
          entity.user.Nick,
          entity.group.GroupName,
          entity.user.Avatar,
          eventMembers = entity.eventMembers
            .Join(_context.Users,
              eventMember => eventMember.UserID,
              user => user.UserID,
              (eventMember, user) => new { eventMember, user })
            .Join(_context.Groups,
              userAndEventMember => userAndEventMember.user.GroupID,
              group => group.GroupID,
              (userAndEventMember, group) => new { userAndEventMember.eventMember, userAndEventMember.user, group })
            .Where(userAndEventMember => userAndEventMember.eventMember.UserID == userAndEventMember.user.UserID)
            .Select(userAndEventMember => new {
              userAndEventMember.eventMember.UserID,
              userAndEventMember.eventMember.Standby,
              userAndEventMember.user.Nick,
              userAndEventMember.group.GroupName,
              userAndEventMember.user.Avatar
            })
        }).SingleOrDefault();
      if (guildEvent == null) return NotFound();
      return Ok(guildEvent);
    }

    [AllowAnonymous]
    [HttpPost("{idEvent}/members")]
    public IActionResult AddMember(int idEvent, EventMember member) {
      if (_context.Events.Find(idEvent) == null) return NotFound();

      member.EventID = idEvent;

      _context.EventMembers.Add(member);
      _context.SaveChanges();
      return Ok();
    }

    [Authorize(Roles = "Admin")]  // TODO MORE ROLES TO CREATE, UPDATE AND DELETE
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

    [Authorize(Roles = "Admin")]  // TODO MORE ROLES TO CREATE, UPDATE AND DELETE or CREATOR?
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