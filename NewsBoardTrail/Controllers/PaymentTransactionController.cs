using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTransactionController : ControllerBase
    {
        private INewsBoardServices<PaymentTransaction> _paymentTransaction;

        public PaymentTransactionController(INewsBoardServices<PaymentTransaction> paymentTransaction)
        {
            _paymentTransaction = paymentTransaction;

        }
        // GET: api/<PaymentTransactionController>
        [HttpGet]
        public List<PaymentTransaction> Get()
        {
            return _paymentTransaction.Get();
        }

        // GET api/<PaymentTransactionController>/5
        [HttpGet("{id}")]
        public ActionResult<PaymentTransaction> Get(string id)
        {
            var paymentTransaction = _paymentTransaction.GetById(id);
            if (paymentTransaction == null)
            {
                return NotFound($"Payment Transaction with Id = {id} not found");
            }
            return paymentTransaction;
        }

        // POST api/<PaymentTransactionController>
        [HttpPost]
        public ActionResult<PaymentTransaction> Post([FromBody] PaymentTransaction value)
        {
            _paymentTransaction.Create(value);
            return CreatedAtAction(nameof(Get), new { id = value.TransactionId }, value);
        }

        // PUT api/<PaymentTransactionController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] PaymentTransaction value)
        {
            var existingUser = _paymentTransaction.GetById(id);
            if (existingUser == null) { return NotFound($"Payment Transaction with Id = {id} not found"); }
            _paymentTransaction.Update(id, value);
            return Ok($"Payment Transaction with id = {id} Updated");
        }

        // DELETE api/<PaymentTransactionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {

            var existingUser = _paymentTransaction.GetById(id);
            if (existingUser == null) { return NotFound($"Payment Transaction with Id = {id} not found"); }
            _paymentTransaction.Delete(id);
            return Ok($"Payment Transaction with Id = {id} deleted");
        }
    
    }
}
