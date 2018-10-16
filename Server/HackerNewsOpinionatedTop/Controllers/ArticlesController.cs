using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HackerNewsOpinionatedTopApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace HackerNewsOpinionatedTopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly HnContext _context;

        public ArticlesController(HnContext context)
        {
            _context = context;

            
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Article>> GetAll()
        {
            return _context.Articles.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetArticle")]
        public ActionResult<Article> GetById(int id)
        {
            var article = _context.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }
            return article;
        }

        // Create article at api/values
        [HttpPost, Authorize]
        public IActionResult Create(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();

            //return 123;
            return CreatedAtRoute("GetArticle", new { id = article.Id }, article);
        }

        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            var article = _context.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(article);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
