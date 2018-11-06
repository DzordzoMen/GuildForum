using System.Linq;
using GuildForum.Models;
using GuildForum.Models.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuildForum.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class EventController : ControllerBase {

    private readonly ForumContext _context;

    public EventController(ForumContext context) {
      _context = context;
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult GetEventsList() {
      var events = _context.Events
        .Include(e => e.User)
        .Select(e => new {
          e.EventID, 
          e.EventName, 
          e.EventDate, 
          e.User.Nick
        })
        .ToList();
      return Ok(events);
    }

    [Authorize(Roles = "Admin")] // TODO
    [HttpPost]
    public IActionResult CreateEvent(Event newEvent) {
      _context.Events.Add(newEvent);
      _context.SaveChanges();
      return Ok();
    }

    [Authorize(Roles = "Admin")] // TODO
    [HttpPut("{idEvent}")]
    public IActionResult UpdateEvent(int idEvent, Event newEventContent) {
      var eventToUpdate = _context.Events.Find(idEvent);
      if (eventToUpdate == null) return NotFound();

      eventToUpdate.EventName = newEventContent.EventName;
      eventToUpdate.EventDescription = newEventContent.EventDescription;
      eventToUpdate.EventDate = newEventContent.EventDate;

      _context.Events.Update(eventToUpdate);
      _context.SaveChanges();
      return Ok();
    }

    [Authorize(Roles = "Admin")] // TODO
    [HttpDelete("{idEvent}")]
    public IActionResult DeleteEvent(int idEvent) {
      var eventToRemove = _context.Events.Find(idEvent);
      if (eventToRemove == null) return NotFound();

      _context.Events.Remove(eventToRemove);
      _context.SaveChanges();
      return Ok();
    }

  }
}