using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentServices;
        public CommentController(ICommentService ContentService)
        {
            _commentServices = ContentService;
        }

        [HttpGet]
        public ActionResult<List<Comment>> Get()
        {
            return _commentServices.Get();
        }

        [HttpGet("CountByid")]
        public ActionResult<long> GetCount(string id)
        {
            var comment = _commentServices.GetCount(id);
            
            return comment;

        }
        [HttpGet("{id}")]
        public ActionResult<Comment> GetById(string id)
        {
            var comment = _commentServices.GetById(id);
            if (comment == null)
            {
                return NotFound($"Comment with Id = {id} not found");
            }
            return comment;

        }



        [HttpPost]
        public ActionResult<Comment> Post([FromBody] Comment comment)
        {
            _commentServices.Create(comment);
            return CreatedAtAction(nameof(Get), new { id = comment.ContentId }, comment);
        }

    
        [HttpPut("{id}")]
        public ActionResult<Comment> Put(string id, [FromBody] Comment comment)
        {
            var existingUser = _commentServices.GetById(id);
            if (existingUser == null) { return NotFound($"User with Id = {id} not found"); }
            _commentServices.Update(id, comment);
            return Ok($"Content with id = {id} Updated");
        }

        
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingUser = _commentServices.GetById(id);
            if (existingUser == null) { return NotFound($"User with Id = {id} not found"); }
            _commentServices.Delete(id);
            return Ok($"Content with Id = {id} deleted");
        }
    }
}
