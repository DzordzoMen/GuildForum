using System.Linq;
using GuildForum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuildForum.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : Controller {

    private readonly ForumContext _context;

    public UserController(ForumContext context) {
      _context = context;
    }

    [HttpGet]
    public IActionResult GetAllUsers() {
      var users = _context.Users
        .Where(u => u.Ban == false)
        .Include(u => u.Rank)
        .Select(u => new {
          u.UserID,
          u.Nick, 
          u.Rank.RankName, 
          u.Avatar
        })
        .ToList();
      return Ok(users);
    }

    [HttpPut("{id}")]
    public IActionResult BanUser(int id) {
      var user = _context.Users.Find(id);
      if (user == null) return NotFound();

      user.Ban = true;
      _context.Users.Update(user);
      _context.SaveChanges();
      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id) {
      var user = _context.Users.Find(id);
      if (user == null) return NotFound();
      _context.Users.Remove(user);
      _context.SaveChanges();
      return Ok();
    }
  }
}