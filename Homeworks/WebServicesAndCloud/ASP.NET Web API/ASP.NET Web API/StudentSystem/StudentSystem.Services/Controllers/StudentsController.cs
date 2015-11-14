namespace StudentSystem.Services.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    public class StudentsController : ApiController
    {
        // GET: api/students
        public IEnumerable<string> Get()
        {
            return new string[] { "student1", "student2" };
        }

        // GET: api/students/5
        public string Get(int id)
        {
            return $"student {id}";
        }
    }
}
