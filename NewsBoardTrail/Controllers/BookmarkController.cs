using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly INewsBoardServices<Bookmark> _bookmarkServices;
        public BookmarkController(INewsBoardServices<Bookmark> ContentService)
        {
            _bookmarkServices = ContentService;
        }

        [HttpGet]
        public ActionResult<List<Bookmark>> Get()
        {
            return _bookmarkServices.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Bookmark> Get(string id)
        {
            var bookmark = _bookmarkServices.GetById(id);
            if (bookmark == null)
            {
                return NotFound($"User with Id = {id} not found");
            }
            return bookmark;

        }


        [HttpPost]
        public ActionResult<Bookmark> Post([FromBody] Bookmark bookmark)
        {
            _bookmarkServices.Create(bookmark);
            return CreatedAtAction(nameof(Get), new { id = bookmark.BookmarkId }, bookmark);
        }


        [HttpPut("{id}")]
        public ActionResult<Bookmark> Put(string id, [FromBody] Bookmark bookmark)
        {
            var existingUser = _bookmarkServices.GetById(id);
            if (existingUser == null) { return NotFound($"User with Id = {id} not found"); }
            _bookmarkServices.Update(id, bookmark);
            return Ok($"Content with id = {id} Updated");
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingUser = _bookmarkServices.GetById(id);
            if (existingUser == null) { return NotFound($"User with Id = {id} not found"); }
            _bookmarkServices.Delete(id);
            return Ok($"Content with Id = {id} deleted");
        }
    }
}
