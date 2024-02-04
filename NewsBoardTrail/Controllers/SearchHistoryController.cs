using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchHistoryController : ControllerBase
    {
        private INewsBoardServices<SearchHistory> _searchHistory;

        public SearchHistoryController(INewsBoardServices<SearchHistory> searchHistory)
        {
            _searchHistory = searchHistory;

        }
        // GET: api/<SearchHistoryController>
        [HttpGet]
        public List<SearchHistory> Get()
        {
            return _searchHistory.Get();
        }

        // GET api/<SearchHistoryController>/5
        [HttpGet("{id}")]
        public ActionResult<SearchHistory> Get(string id)
        {
            var searchHistory = _searchHistory.GetById(id);
            if (searchHistory == null)
            {
                return NotFound($"Search History with Id = {id} not found");
            }
            return searchHistory;
        }

        // POST api/<SearchHistoryController>
        [HttpPost]
        public ActionResult<SearchHistory> Post([FromBody] SearchHistory value)
        {
            _searchHistory.Create(value);
            return CreatedAtAction(nameof(Get), new { id = value.SearchId }, value);
        }

        // PUT api/<SearchHistoryController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] SearchHistory value)
        {
            var existingUser = _searchHistory.GetById(id);
            if (existingUser == null) { return NotFound($"Search History with Id = {id} not found"); }
            _searchHistory.Update(id, value);
            return Ok($"Search History with id = {id} Updated");
        }

        // DELETE api/<SearchHistoryController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existing = _searchHistory.GetById(id);
            if (existing == null) { return NotFound($"Search History with Id = {id} not found"); }
            _searchHistory.Delete(id);
            return Ok($"Search History with Id = {id} deleted");
        }
    }
}
