using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private INewsBoardServices<Notification> _notification;

        public NotificationController(INewsBoardServices<Notification> notification)
        {
            _notification = notification;

        }
        // GET: api/<NotificationController>
        [HttpGet]
        public List<Notification> Get()
        {
            return _notification.Get();
        }

        // GET api/<NotificationController>/5
        [HttpGet("{id}")]
        public ActionResult <Notification> Get(string id)
        {
            
            var notification = _notification.GetById(id);
            if (notification == null)
            {
                return NotFound($"Notification with Id = {id} not found");
            }
            return notification;
        }

        // POST api/<NotificationController>
        [HttpPost]
        public ActionResult<Notification> Post([FromBody] Notification value)
        {
            _notification.Create(value);
            return CreatedAtAction(nameof(Get), new { id = value.NotificationID }, value);
        }

        // PUT api/<NotificationController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            var existingUser = _notification.GetById(id);
            if (existingUser == null) { return NotFound($"User with Id = {id} not found"); }
            _notification.Update(id, value);
            return Ok($"Content with id = {id} Updated");
        }

        // DELETE api/<NotificationController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            var existingUser = _notification.GetById(id);
            if (existingUser == null) { return NotFound($"notification with Id = {id} not found"); }
            _notification.Delete(id);
            return Ok($"notification with Id = {id} deleted");
        }
    }
}
