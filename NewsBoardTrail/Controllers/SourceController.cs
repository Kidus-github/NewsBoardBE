using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceController : ControllerBase {

        private INewsBoardServices<Source> _source;

        public SourceController(INewsBoardServices<Source> source)
        {
            _source = source;

        }
        // GET: api/<SourceController>
        [HttpGet]
        public List<Source> Get()
        {
            return _source.Get();
        }

        // GET api/<SourceController>/5
        [HttpGet("{id}")]
        public ActionResult<Source> Get(string id)
        {
            var source = _source.GetById(id);
            if (source == null)
            {
                return NotFound($"Source with Id = {id} not found");
            }
            return source;
        }

        // POST api/<SourceController>
        [HttpPost]
        public ActionResult<Source> Post([FromBody] Source value)
        {
            _source.Create(value);
            return CreatedAtAction(nameof(Get), new { id = value.SourceId }, value);
        }

        // PUT api/<SourceController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Source value)
        {
            var existingUser = _source.GetById(id);
            if (existingUser == null) { return NotFound($"Source with Id = {id} not found"); }
            _source.Update(id, value);
            return Ok($"Source with id = {id} Updated");
        }

        // DELETE api/<SourceController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existing = _source.GetById(id);
            if (existing == null) { return NotFound($"Source with Id = {id} not found"); }
            _source.Delete(id);
            return Ok($"Source with Id = {id} deleted");
        }

    }
 }

