using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;

namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrendingController : ControllerBase
    {
        private INewsBoardServices<Trendings> _trendingCollection;

        public TrendingController(INewsBoardServices<Trendings> trending)
        {
            _trendingCollection = trending;

        }
        // GET: api/<TrendingController>
        [HttpGet]
        public List<Trendings> Get()
        {
            return _trendingCollection.Get();
        }

        // GET api/<TrendingController>/5
        [HttpGet("{id}")]
        public ActionResult<Trendings> Get(string id)
        {
            var trending = _trendingCollection.GetById(id);
            if (trending == null)
            {
                return NotFound($"Trending with Id = {id} not found");
            }
            return trending;
        }

        // POST api/<TrendingController>
        [HttpPost]
        public ActionResult<Trendings> Post([FromBody] Trendings value)
        {
            _trendingCollection.Create(value);
            return CreatedAtAction(nameof(Get), new { id = value.TrendingID }, value);
        }

        // PUT api/<TrendingController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Trendings value)
        {
            var existing = _trendingCollection.GetById(id);
            if (existing == null) { return NotFound($"Trending with Id = {id} not found"); }
            _trendingCollection.Update(id, value);
            return Ok($"Trending with id = {id} Updated");
        }

        // DELETE api/<TrendingController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existing = _trendingCollection.GetById(id);
            if (existing == null) { return NotFound($"Trending with Id = {id} not found"); }
            _trendingCollection.Delete(id);
            return Ok($"Trending with Id = {id} deleted");
        }
    }
}
