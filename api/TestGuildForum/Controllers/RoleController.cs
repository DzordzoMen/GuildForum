﻿using System.Linq;
using System.Threading.Tasks;
using GuildForum.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace GuildForum.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class RoleController : Controller {
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleController(RoleManager<IdentityRole> roleManager) {
      _roleManager = roleManager;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult GetRoleList() {
      var roles = _roleManager.Roles.ToList();
      return Ok(roles);

    }

    // TODO DELETE?
    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoleInfoAsync(string id) {
      var rank = await _roleManager.FindByIdAsync(id);
      if (rank == null) return NotFound();
      return Ok(rank);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateRoleAsync([FromBody] AddRole newRole) {
      var role = new IdentityRole { Name = newRole.Name };
      await _roleManager.CreateAsync(role);
      return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoleAsync(string id, string newName) {
      var role = await _roleManager.FindByIdAsync(id);
      if (role == null) return NotFound();

      role.Name = newName;
      await _roleManager.UpdateAsync(role);

      return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoleAsync(string id) {
      var role = await _roleManager.FindByIdAsync(id);
      if (role == null) return NotFound();

      await _roleManager.DeleteAsync(role);

      return Ok();
    }
  }
}