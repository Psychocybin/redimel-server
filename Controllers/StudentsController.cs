using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace redimel_server.Controllers
{

    //https://localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //GET: https://localhost:portnumber/api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] {"John", "Maria", "Stela", "Gosho"};

            return Ok(studentNames);
        }

    }
}
