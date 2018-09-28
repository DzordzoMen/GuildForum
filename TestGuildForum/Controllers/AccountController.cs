using System.Linq;
using System.Threading.Tasks;
using GuildForum.Models;
using GuildForum.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GuildForum.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class AccountController : Controller {

    private readonly ForumContext _context;

    private readonly UserManager<ApplicationUser> _userManager;

    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(
      ForumContext context,
      UserManager<ApplicationUser> userManager,
      SignInManager<ApplicationUser> signInManager) {

      _context = context;
      _userManager = userManager;
      _signInManager = signInManager;

    }
    // register
    [HttpPost("create")]
    public async Task<IActionResult> CreateUserAsync(NewUserModel newUser) {
      var result = await _userManager.CreateAsync(new ApplicationUser {
        UserName = newUser.UserName,
        Email = newUser.Email
      }, newUser.Password);

      if (result.Succeeded)
        return Ok();

      return BadRequest();
    }

    // jesli sie nie uda to przekierowuje do /account/login
    [Authorize]
    [HttpGet("private")]
    public IActionResult PrivateArea() {
      return Content($"This is a private area. Welcome {HttpContext.User.Identity.Name}", "text/html");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(NewUserModel user) {
      // sprawdzic dokladnosc tych true co robia      
      var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, true, true);

      if (result.Succeeded)
        return Ok();

      return BadRequest();
    }

    // TODO przemyslec jeszcze to wszystko bo hasla itp
    [HttpPut("edit/{idUser}")]
    public IActionResult EditAccount(User user, int idUser) {
      var userFromDb = _context.Users
        .SingleOrDefault(u => u.UserID == idUser);

      if (userFromDb == null) return NotFound();

      userFromDb.Nick = user.Nick;
      userFromDb.Avatar = user.Avatar;

      _context.Users.Update(userFromDb);

      return Ok();
    }

  }
}