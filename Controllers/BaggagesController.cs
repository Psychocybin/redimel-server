using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using redimel_server.Data;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaggagesController : ControllerBase
    {
        private readonly RedimelServerDbContext dbContext;

        public BaggagesController(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var baggages = dbContext.Baggages.ToList();

            return Ok(baggages);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var baggage = dbContext.Baggages.Find(id);

            //var baggage = dbContext.Baggages.FirstOrDefault(x => x.Id == id);

            if (baggage == null)
            {
                return NotFound();
            }

            return Ok(baggage);
        }
    }
}
