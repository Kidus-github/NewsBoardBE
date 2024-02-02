using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentTagController : ControllerBase
    {
        private INewsBoardServices<ContentTag> _contentTag;

        public ContentTagController(INewsBoardServices<ContentTag> contentTag)
        {
            _contentTag = contentTag;
            
        }
        // GET: api/<ContentTagController>
        [HttpGet]
        public List<ContentTag> Get()
        {
            return _contentTag.Get();
        }

        // GET api/<ContentTagController>/5
        [HttpGet("{id}")]
        public ActionResult<ContentTag> Get(string id)
        {
            var contentTag = _contentTag.GetById(id);
            if (contentTag == null)
            {
                return NotFound($"Content Tag with Id = {id} not found");
            }
            return contentTag;
        }

        // POST api/<ContentTagController>
        [HttpPost]
        public ActionResult<ContentTag> Post([FromBody] ContentTag value)
        {
            _contentTag.Create(value);
            return CreatedAtAction(nameof(Get), new { id = value.ContentTagId }, value);
        }

        // PUT api/<ContentTagController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] ContentTag value)
        {
            var existingUser = _contentTag.GetById(id);
            if (existingUser == null) { return NotFound($"Content Tag with Id = {id} not found"); }
            _contentTag.Update(id, value);
            return Ok($"Content Tag with id = {id} Updated");
        }

        // DELETE api/<ContentTagController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingUser = _contentTag.GetById(id);
            if (existingUser == null) { return NotFound($"Content Tag with Id = {id} not found"); }
            _contentTag.Delete(id);
            return Ok($"Content Tag with Id = {id} deleted");
        }
    }
}
