using System.Linq;
using GuildForum.Models;
using GuildForum.Models.Articles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildForum.Controllers {
  [Route("api/article/")]
  [ApiController]
  public class CommentsController : Controller {

    private readonly ForumContext _context;

    public CommentsController(ForumContext context) {
      _context = context;
    }
    //  zmienic id_comment tak jak jest w naviq
    //
    [Authorize] // TODO
    [HttpPost("{idArticle}/comment")]
    public IActionResult CreateComment(int idArticle, ArticleComments comment) {
      var article = _context.Articles.Find(idArticle);
      if (article == null) return NotFound();

      comment.ArticleID = idArticle;
      _context.ArticleCommentses.Add(comment);
      _context.SaveChanges();
      return Ok();
    }

    [Authorize] // TODO TYLKO OSOBA KTORA TO UTWORZYŁA MOŻE GO USUNĄĆ, ALBO ADMIN
    [HttpPut("{idArticle}/comment/{idComment}")]
    public IActionResult UpdateComment(int idArticle, int idComment, ArticleComments comment) {
      var commentToFind = _context.ArticleCommentses
        .SingleOrDefault(c => c.ArticleID == idArticle && c.CommentID == idComment);
      if (commentToFind == null) return NotFound();

      commentToFind.Content = comment.Content;
      _context.ArticleCommentses.Update(commentToFind);
      _context.SaveChanges();
      return Ok();
    }

    [Authorize] // TODO TYLKO OSOBA KTORA TO UTWORZYŁA MOŻE GO USUNĄĆ, ALBO ADMIN
    [HttpDelete("{idArticle}/comment/{idComment}")]
    public IActionResult DeleteComment(int idArticle, int idComment) {
      var comment = _context.ArticleCommentses
        .SingleOrDefault(c => c.ArticleID == idArticle && c.CommentID == idComment);
      if (comment == null) return NotFound();

      _context.ArticleCommentses.Remove(comment);
      _context.SaveChanges();
      return Ok();
    }
  }
}