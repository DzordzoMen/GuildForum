using System.Linq;
using System.Threading.Tasks;
using GuildForum.Models;
using GuildForum.Models.Response;
using GuildForum.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GuildForum.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : Controller {

    private readonly ForumContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserController(ForumContext context, UserManager<ApplicationUser> userManager) {
      _context = context;
      _userManager = userManager;
    }

    [HttpGet]
    public IActionResult GetAllUsers() {
      var users = _context.Users
        .Join(_context.IdentityUserRoles,
          user => user.IdentityID,
          userRoles => userRoles.UserId,
          (user, userRoles) => new {user, userRoles})
        .Join(_context.IdentityRoles,
          entity => entity.userRoles.RoleId,
          role => role.Id,
          (entity, role) => new {entity.user, entity.userRoles, role})
        .Where(entity => entity.user.Ban == false)
        .Select(entity => new {
          entity.user.UserID,
          entity.user.Nick,
          entity.user.Avatar,
          roleName = entity.role.Name,
        }).ToList();
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

    [Authorize(Roles = "Admin")]
    [HttpPut("{idUser}/authorize")]
    public async Task<IActionResult> GiveUserRoleAsync(int idUser, AddRole role) {
      var user = _context.Users
        .SingleOrDefault(u => u.UserID == idUser);
      if (user == null) return NotFound();
      var identityUser = await _userManager.FindByIdAsync(user.IdentityID);
      await _userManager.AddToRoleAsync(identityUser, role.Name);
      return Ok();
    }
  }
}