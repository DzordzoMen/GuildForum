using System.Linq;
using GuildForum.Models;
using Microsoft.AspNetCore.Mvc;
using GuildForum.Models.Ranks;

namespace GuildForum.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class RankController : Controller {
    private readonly ForumContext _context;

    public RankController(ForumContext context) {
      _context = context;
    }

    [HttpGet]
    public IActionResult GetRanks() {
      var ranks = _context.Ranks.ToList();
      return Ok(ranks);

    }

    [HttpGet("{id}")]
    public IActionResult GetRankInfo(int id) {
      var rank = _context.Ranks.Find(id);
      if (rank == null) return NotFound();
      return Ok(rank);
    }

    [HttpPost]
    public IActionResult CreateRank(Rank rank) {
      _context.Ranks.Add(rank);
      _context.SaveChanges();
      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRank(int id, Rank rank) {
      var rankToUpdate = _context.Ranks.Find(id);
      if (rankToUpdate == null) return NotFound();

      rankToUpdate.RankName = rank.RankName;
      _context.Ranks.Update(rankToUpdate);
      _context.SaveChanges();

      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRank(int id) {
      var rank = _context.Ranks.Find(id);
      if (rank == null) return NotFound();

      _context.Ranks.Remove(rank);
      _context.SaveChanges();

      return Ok();
    }
  }
}