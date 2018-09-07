using System.Linq;
using GuildForum.Models;
using GuildForum.Models.Articles;
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
        .Include(a => a.User)
        .Select(a => new {
          a.ArticleID, 
          a.User.Nick,
          a.PostDate, 
          a.Title, 
          a.Content, 
          a.Photo
        })
        .OrderBy(a => a.PostDate).ToList();
      return Ok(articles);
    }

    [HttpGet("{id}")]
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