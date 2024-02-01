using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // GET: api/Person
        [HttpGet]
        public ActionResult<Person> Get()
        {
            return new Person("Ib", 32);
        }



    }

    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        // GET: api/Person
        [HttpGet]
        public ActionResult<IEnumerable<Models.Person>> Get()
        {
            List<Models.Person> list = new List<Models.Person>();
            TestapiDbContext context = new TestapiDbContext();
            //list = context.Persons.FromSqlRaw("select * from Persons").ToList();
            list = context.Persons.ToList();


            return list;
        }



    }

    [Route("api/[controller]/{id}")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/Person
        [HttpGet]
        public ActionResult<Person> Get(int id)
        {
            return new Person("Student-Ib", 32+id);
        }



    }
}
