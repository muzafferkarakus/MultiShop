using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entites;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _context.UserComments.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _context.UserComments.Add(userComment);
            _context.SaveChanges();
            return Ok("Yorum Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var values = _context.UserComments.Find(id);
            _context.UserComments.Remove(values);
            _context.SaveChanges();
            return Ok("Yorum Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var values = _context.UserComments.Find(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _context.UserComments.Update(userComment);
            _context.SaveChanges();
            return Ok("Yorum Güncellendi");
        }
        [HttpGet("CommentListByProductId/{id}")]
        public IActionResult CommentListByProductId(string id)
        {
            var value = _context.UserComments.Where(x => x.ProductId == id).ToList();
            return Ok(value);
        }
    }
}
