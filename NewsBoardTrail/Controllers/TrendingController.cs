using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Services;

namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrendingController : ControllerBase
    {
        private INewsBoardServices<Trending> _trendingCollection;

        public TrendingController(INewsBoardServices<Trending> trending)
        {
            _trendingCollection = trending;

        }
        // GET: api/<TrendingController>
        [HttpGet]
        public List<Trending> Get()
        {
            return _trendingCollection.Get();
        }

        // GET api/<TrendingController>/5
        [HttpGet("{id}")]
        public ActionResult<Trending> Get(string id)
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
        public ActionResult<Trending> Post([FromBody] Trending value)
        {
            _trendingCollection.Create(value);
            return CreatedAtAction(nameof(Get), new { id = value.TrendingId }, value);
        }

        // PUT api/<TrendingController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Trending value)
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
}
