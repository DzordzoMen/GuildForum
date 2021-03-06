﻿using System.Linq;
using GuildForum.Models;
using GuildForum.Models.Articles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildForum.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class ArticleController : Controller {
    private readonly ForumContext _context;

    public ArticleController(ForumContext context) {
      _context = context;
    }
    [AllowAnonymous]
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
          (entity, role) => new {entity.user, entity.article, role})
        .Select(entity => new {
          entity.article.ArticleID,
          author = entity.user.Nick,
          entity.user.UserID,
          roleName = entity.role.Name,
          entity.article.PostDate,
          entity.article.Title,
          entity.article.Content,
          entity.article.Photo
        }).OrderBy(entity => entity.PostDate)
        .ToList();
      return Ok(articles);
    }
    [AllowAnonymous]
    [HttpGet("{articleId}")] // TODO ROLE FOR COMMENTS?
    public IActionResult GetArticleInfo(int articleId) {
      var article = _context.Articles
        .Join(_context.Users,
          art => art.UserID,
          user => user.UserID,
          (art, user) => new { art, user })
        .Join(_context.IdentityUserRoles,
          entity => entity.user.IdentityID,
          userRole => userRole.UserId,
          (entity, userRole) => new { entity.art, entity.user, userRole })
        .Join(_context.IdentityRoles,
          entity => entity.userRole.RoleId,
          role => role.Id,
          (entity, role) => new { entity.art, entity.user, role })
        .Where(entity => entity.art.ArticleID == articleId)
        .Select(entity => new {
          entity.art.ArticleID,
          entity.art.PostDate,
          author = entity.user.Nick,
          entity.user.UserID,
          roleName = entity.role.Name,
          entity.art.Title,
          entity.art.Content,
          entity.art.Photo,
          articleComments = _context.ArticleComments
          .Join(_context.Users,
            comment => comment.UserID,
            user => user.UserID,
            (comment, user) => new { comment, user })
          .Where(artComment => artComment.comment.ArticleID == articleId)
          .Select(artComment => new {
            artComment.comment.CommentID,
            artComment.comment.PostDate,
            artComment.comment.Content,
            artComment.user.Nick,
          })
        }).SingleOrDefault();
      if (article == null) return NotFound();
      return Ok(article);
    }

    [Authorize(Roles = "Admin")] // TODO MORE ROLES TO CREATE, UPDATE AND DELETE
    [HttpPost]
    public IActionResult CreateArticle(Article article) {
      _context.Articles.Add(article);
      _context.SaveChanges();
      return Ok();
    }

    [Authorize(Roles = "Admin")] // TODO MORE ROLES TO CREATE, UPDATE AND DELETE
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

    [Authorize(Roles = "Admin")] // TODO MORE ROLES TO CREATE, UPDATE AND DELETE
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