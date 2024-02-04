using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;

namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private INewsBoardServices<Tag> _tagCollection;

        public TagController(INewsBoardServices<Tag> tag)
        {
            _tagCollection = tag;

        }
        // GET: api/<TagController>
        [HttpGet]
        public List<Tag> Get()
        {
            return _tagCollection.Get();
        }

        // GET api/<TagController>/5
        [HttpGet("{id}")]
        public ActionResult<Tag> Get(string id)
        {
            var tag = _tagCollection.GetById(id);
            if (tag == null)
            {
                return NotFound($"Tag with Id = {id} not found");
            }
            return tag;
        }

        // POST api/<TagController>
        [HttpPost]
        public ActionResult<Tag> Post([FromBody] Tag value)
        {
            _tagCollection.Create(value);
            return CreatedAtAction(nameof(Get), new { id = value.TagId }, value);
        }

        // PUT api/<TagController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Tag value)
        {
            var existing = _tagCollection.GetById(id);
            if (existing == null) { return NotFound($"Tag with Id = {id} not found"); }
            _tagCollection.Update(id, value);
            return Ok($"Tag with id = {id} Updated");
        }

        // DELETE api/<TagController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existing = _tagCollection.GetById(id);
            if (existing == null) { return NotFound($"Tag with Id = {id} not found"); }
            _tagCollection.Delete(id);
            return Ok($"Tag with Id = {id} deleted");
        }
    }
}
