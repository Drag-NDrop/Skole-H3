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
            return new Person("Ib", 32, "murer");
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
            return new Person("Student-Ib", 32+id, "Clown");
        }
    }


    [Route("api/[controller]")]
    public class StudentQueryController : ControllerBase
    {
        // GET: api/Student?username={username}&age={age}
        [HttpGet]
        public ActionResult<Person> Get(string username, int age)
        {

            // Set a cookie in the response
            // The parameters are: cookie name, cookie value, and cookie options
            var cookieOptions = new CookieOptions
            {
                // Set the cookie to expire in 1 day
                Expires = DateTime.Now.AddDays(1),
                // Setting HttpOnly to true prevents client-side scripts from accessing the cookie,
                // enhancing security when you don't need to access the cookie from JavaScript.
                HttpOnly = true,
                // Use Secure=true if you want to send the cookie over HTTPS only.
                // Secure = true
            };

            HttpContext.Response.Cookies.Append("Username", username, cookieOptions);
            HttpContext.Response.Cookies.Append("Age", age.ToString(), cookieOptions);
            

            // You can now use the username and age parameters as needed
            // For demonstration purposes, we'll return a new Person with the provided username and age
            return new Person(username, age, "Unemployed");
        }


        // GET: https://localhost:7280/api/StudentQuery/GetFromCookie
        [HttpGet]
        [Route("[action]")]
        public string GetFromCookie()
        {
            string test = Request.Cookies["Username"];
           return test;
        }

    }
}
