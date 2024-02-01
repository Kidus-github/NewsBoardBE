using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly INewsBoardServices<Category> _categoryService;

        public CategoryController(INewsBoardServices<Category> category)
        {
            _categoryService = category;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public ActionResult<List<Category>> Get()
        {
            return _categoryService.Get();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public ActionResult<Category> Get(string id) { 

            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound($"User with Id = {id} not found");
            }
            return category;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public ActionResult<Category> Post([FromBody] Category category)
        {
            _categoryService.Create(category);
            return CreatedAtAction(nameof(Get), new { id = category.CategoryId }, category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public ActionResult<Category> Put(string id, [FromBody] Category category)
        {
            var existingUser = _categoryService.GetById(id);
            if (existingUser == null) { return NotFound($"User with Id = {id} not found"); }
            _categoryService.Update(id, category);
            return Ok($"Content with id = {id} Updated");
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingUser = _categoryService.GetById(id);
            if (existingUser == null) { return NotFound($"User with Id = {id} not found"); }
            _categoryService.Delete(id);
            return Ok($"Content with Id = {id} deleted");
        }
    }
}
