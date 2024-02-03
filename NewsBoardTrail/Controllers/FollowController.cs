using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private INewsBoardServices<Follow> _follow;

        public FollowController(INewsBoardServices<Follow> follow)
        {
            _follow = follow;

        }
        // GET: api/<FollowController>
        [HttpGet]
        public List<Follow> Get()
        {
            return _follow.Get();
        }

        // GET api/<FollowController>/5
        [HttpGet("{id}")]
        public ActionResult<Follow> Get(string id)
        {
            var follow = _follow.GetById(id);
            if (follow == null)
            {
                return NotFound($"Follow with Id = {id} not found");
            }
            return follow;
        }

        // POST api/<FollowController>
        [HttpPost]
        public ActionResult<Follow> Post([FromBody] Follow value)
        {
            _follow.Create(value);
            return CreatedAtAction(nameof(Get), new { id = value.FollowId }, value);
        }

        // PUT api/<FollowController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Follow value)
        {
            var existingUser = _follow.GetById(id);
            if (existingUser == null) { return NotFound($"Follow with Id = {id} not found"); }
            _follow.Update(id, value);
            return Ok($"Follow with id = {id} Updated");
        }

        // DELETE api/<FollowController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingUser = _follow.GetById(id);
            if (existingUser == null) { return NotFound($"Content Tag with Id = {id} not found"); }
            _follow.Delete(id);
            return Ok($"Content Tag with Id = {id} deleted");
        }
    }
}
