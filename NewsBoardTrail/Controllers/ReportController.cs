using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private INewsBoardServices<Report> _report;

        public ReportController(INewsBoardServices<Report> report)
        {
            _report = report;

        }
        // GET: api/<ReportController>
        [HttpGet]
        public List<Report> Get()
        {
            return _report.Get();
        }

        // GET api/<ReportController>/5
        [HttpGet("{id}")]
        public ActionResult<Report> Get(string id)
        {
            var report = _report.GetById(id);
            if (report == null)
            {
                return NotFound($"Report with Id = {id} not found");
            }
            return report;
        }

        // POST api/<ReportController>
        [HttpPost]
        public ActionResult<Report> Post([FromBody] Report value)
        {
            _report.Create(value);
            return CreatedAtAction(nameof(Get), new { id = value.ReportId }, value);
        }

        // PUT api/<ReportController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Report value)
        {
            var existingUser = _report.GetById(id);
            if (existingUser == null) { return NotFound($"Report with Id = {id} not found"); }
            _report.Update(id, value);
            return Ok($"Report with id = {id} Updated");
        }

        // DELETE api/<ReportController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingUser = _report.GetById(id);
            if (existingUser == null) { return NotFound($"report with Id = {id} not found"); }
            _report.Delete(id);
            return Ok($"report with Id = {id} deleted");
        }
    }
}
