using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;


namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser newsBoadService;

        public UserController(IUser NewsBoardservices)
        {
            newsBoadService = NewsBoardservices;
        }
        // GET: api/<UserController>

        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {
            var user = newsBoadService.GetById(id);
            if (user == null)
            {
                return NotFound($"User with Id = {id} not found");
            }
            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            newsBoadService.Create(user);
            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] User user)
        {
            var existingUser = newsBoadService.GetById(id);
            if (existingUser == null) { return NotFound($"User with Id = {id} not found"); }
            newsBoadService.Update(id, user);
            return NoContent();

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingUser = newsBoadService.GetById(id);
            if (existingUser == null) { return NotFound($"User with Id = {id} not found"); }
            newsBoadService.Delete(id);
            return Ok($"User with Id = {id} deleted");
        }
        [HttpGet("GetUserNametBYid")]
        public ActionResult<string> GetUserNameById(string id)
        {
            var username = newsBoadService.GetUserName(id);
            if (username == null)
            {
                return NotFound($"Comment with Id = {id} not found");
            }
            return username;

        }
    }
}
