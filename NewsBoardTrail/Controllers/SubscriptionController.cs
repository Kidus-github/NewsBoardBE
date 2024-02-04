using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private INewsBoardServices<Subscription> _subscription;

        public SubscriptionController(INewsBoardServices<Subscription> subscription)
        {
            _subscription = subscription;

        }
        // GET: api/<SubscriptionController>
        [HttpGet]
        public List<Subscription> Get()
        {
            return _subscription.Get();
        }

        // GET api/<SubscriptionController>/5
        [HttpGet("{id}")]
        public ActionResult<Subscription> Get(string id)
        {
            var subscription = _subscription.GetById(id);
            if (subscription == null)
            {
                return NotFound($"Subscription with Id = {id} not found");
            }
            return subscription;
        }

        // POST api/<SubscriptionController>
        [HttpPost]
        public ActionResult<Subscription> Post([FromBody] Subscription value)
        {
            _subscription.Create(value);
            return CreatedAtAction(nameof(Get), new { id = value.SubscriptionId }, value);
        }

        // PUT api/<SubscriptionController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Subscription value)
        {
            var existing = _subscription.GetById(id);
            if (existing == null) { return NotFound($"Subscription with Id = {id} not found"); }
            _subscription.Update(id, value);
            return Ok($"Subscription with id = {id} Updated");
        }

        // DELETE api/<SubscriptionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existing = _subscription.GetById(id);
            if (existing == null) { return NotFound($"Subscription with Id = {id} not found"); }
            _subscription.Delete(id);
            return Ok($"Subscription with Id = {id} deleted");
        }

    }
}
