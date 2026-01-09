using EmployeeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController() { }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            List<Employee> employees = new List<Employee>(){
            new Employee { Id = 1, Name = "Deepti Karambelkar", Address = "test address", Email = "test@gmail.com", Phone = "1234567890" },
            new Employee { Id = 2, Name = "Aarya Karambelkar", Address = "test address", Email = "test@gmail.com", Phone = "1234567890" },
            new Employee { Id = 3, Name = "Shreya Karambelkar", Address = "test address", Email = "test@gmail.com", Phone = "1234567890" }
            };
            return (IEnumerable<Employee>)employees;
        }

    }
}
