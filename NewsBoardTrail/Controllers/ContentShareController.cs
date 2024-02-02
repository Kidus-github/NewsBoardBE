using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentShareController : ControllerBase
    {
        private INewsBoardServices<ContentShare> _contentShare;

        public ContentShareController(INewsBoardServices<ContentShare> contentShare)
        {
            _contentShare = contentShare;
            
        }
        // GET: api/<ContentShareController>
        [HttpGet]
        public List<ContentShare> Get()
        {
            return _contentShare.Get();
        }

        // GET api/<ContentShareController>/5
        [HttpGet("{id}")]
        public ActionResult<ContentShare> Get(string id)
        {
            var contentShare = _contentShare.GetById(id);
            if (contentShare == null)
            {
                return NotFound($"Content share with Id = {id} not found");
            }
            return contentShare;
        }

        // POST api/<ContentShareController>
        [HttpPost]
        public ActionResult<ContentShare> Post([FromBody] ContentShare value)
        {
            _contentShare.Create(value);
            return CreatedAtAction(nameof(Get), new { id = value.ShareID }, value);
        }

        // PUT api/<ContentShareController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] ContentShare value)
        {
            var existingUser = _contentShare.GetById(id);
            if (existingUser == null) { return NotFound($"User with Id = {id} not found"); }
            _contentShare.Update(id, value);
            return Ok($"Content with id = {id} Updated");
        }

        // DELETE api/<ContentShareController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingUser = _contentShare.GetById(id);
            if (existingUser == null) { return NotFound($"User with Id = {id} not found"); }
            _contentShare.Delete(id);
            return Ok($"Content with Id = {id} deleted");
        }
    }
}
