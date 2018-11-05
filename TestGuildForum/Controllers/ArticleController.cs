using System.Linq;
using GuildForum.Models;
using GuildForum.Models.Articles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuildForum.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class ArticleController : Controller {
    private readonly ForumContext _context;

    public ArticleController(ForumContext context) {
      _context = context;
    }

    [HttpGet]
    public IActionResult GetAllArticles() {
      var articles = _context.Articles
        .Join(_context.Users,
          article => article.UserID,
          user => user.UserID,
          (article, user) => new {article, user})
        .Join(_context.IdentityUserRoles,
          entity => entity.user.IdentityID,
          userRoles => userRoles.UserId,
          (entity, userRoles) => new {entity.article, entity.user, userRoles})
        .Join(_context.IdentityRoles,
          entity => entity.userRoles.RoleId,
          role => role.Id,
          (entity, role) => new {entity.user, entity.article, entity.userRoles, role})
        .Select(entity => new {
          entity.article.ArticleID,
          entity.user.Nick,
          roleName = entity.role.Name,
          entity.article.PostDate,
          entity.article.Title,
          entity.article.Content,
          entity.article.Photo
        }).OrderBy(entity => entity.PostDate)
        .ToList();
      return Ok(articles);
    }

    [HttpGet("{id}")] // TODO ROLA?
    public IActionResult GetArticleInfo(int id) {
      var article = _context.Articles
        .Include(c => c.ArticleCommentses)
        .ThenInclude(c => c.User)
        .Select(a => new {
          a.ArticleID, 
          a.PostDate, 
          a.User.Nick, 
          a.Title, 
          a.Content, 
          a.Photo, 
          articleComments = a.ArticleCommentses
            .Select(c => new {
              c.CommentID, 
              c.PostDate, 
              c.Content, 
              c.User.Nick
            })
        })
        .SingleOrDefault(a => a.ArticleID == id);

      if (article == null) return NotFound();
      return Ok(article);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult CreateArticle(Article article) {
      _context.Articles.Add(article);
      _context.SaveChanges();
      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateArticle(int id, Article article) {
      var articleToUpdate = _context.Articles.Find(id);
      if (articleToUpdate == null) return NotFound();

      articleToUpdate.Title = article.Title;
      articleToUpdate.Content = article.Content;
      articleToUpdate.Photo = article.Photo;

      _context.Articles.Update(articleToUpdate);
      _context.SaveChanges();

      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteArticle(int id) {
      var article = _context.Articles.Find(id);
      if (article == null) return NotFound();

      _context.Articles.Remove(article);
      _context.SaveChanges();
      return Ok();
    }
  }
}