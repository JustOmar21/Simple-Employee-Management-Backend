using Backend.Filters;
using Backend.Models;
using Backend.Repo.RepoInterface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServerExceptions]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo employeeRepo;
        public EmployeeController(IEmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }
        [HttpPost("Create")]
        public IActionResult Add(Employee employee)
        {
            return StatusCode((int)employeeRepo.Add(employee));
        }
        [HttpPut("Update")]
        public IActionResult Edit(EmployeeUpdate employee)
        {
            return StatusCode((int)employeeRepo.Update(employee));
        }
        [HttpDelete("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            return StatusCode((int)employeeRepo.Delete(id));
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(employeeRepo.GetAll());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetEmployee(int id)
        {
            return Ok(employeeRepo.GetById(id));
        }

    }
}
