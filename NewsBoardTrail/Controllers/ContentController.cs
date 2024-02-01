using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;


namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly INewsBoardServices<Content> contentServices;
        public ContentController(INewsBoardServices<Content> ContentService)
        {
            contentServices = ContentService;
        }

        // GET: api/<ContentController>
        [HttpGet]
        public ActionResult<List<Content>> Get()
        {
            return contentServices.Get();
        }

        // GET api/<ContentController>/5
        [HttpGet("{id}")]
        public ActionResult<Content> Get(string id)
        {
            var content = contentServices.GetById(id);
            if (content == null)
            {
                return NotFound($"User with Id = {id} not found");
            }
            return content;
             
        }

        // POST api/<ContentController>
        [HttpPost]
        public ActionResult<Content> Post([FromBody] Content content)
        {
            contentServices.Create(content);
            return CreatedAtAction(nameof(Get), new { id = content.ContentId }, content);
        }

        // PUT api/<ContentController>/5
        [HttpPut("{id}")]
        public ActionResult<Content> Put(string id, [FromBody] Content content)
        {
            var existingUser = contentServices.GetById(id);
            if (existingUser == null) { return NotFound($"User with Id = {id} not found"); }
            contentServices.Update(id, content);
            return Ok($"Content with id = {id} Updated");
        }

        // DELETE api/<ContentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingUser = contentServices.GetById(id);
            if (existingUser == null) { return NotFound($"User with Id = {id} not found"); }
            contentServices.Delete(id);
            return Ok($"Content with Id = {id} deleted");
        }
    }
}
