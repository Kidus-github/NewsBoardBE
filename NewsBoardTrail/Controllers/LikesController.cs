using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ILikeService _likeService;
        public LikesController(ILikeService like)
        {
            _likeService = like;
        }
        // GET: api/<LikesController>
        [HttpGet]
        public ActionResult<List<likes>> Get()
        {
            return _likeService.Get();
        }


        // POST api/<LikesController>
        [HttpPost]
        public ActionResult<likes> Post([FromBody] likes like)
        {
            _likeService.Create(like);
            return CreatedAtAction(nameof(Get), new { id = like.LikeId }, like);
        }

        // DELETE api/<LikesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingUser = _likeService.GetById(id);
            if (existingUser == 0) { return NotFound($"Like with Id = {id} not found"); }
            _likeService.Delete(id);
            return Ok($"Like with Id = {id} deleted");
        }
        [HttpGet("{id}")]
        public ActionResult<long> GetById(string id)
        {
            var like = _likeService.GetById(id);

            return like;
        }
        }
}
