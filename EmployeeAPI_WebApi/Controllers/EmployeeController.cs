using EmployeeAPI_WebApi.Models;
using EmployeeAPI_WebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = Repository.EmployeeRepository.GetAll();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById([FromRoute] int id)
        {
            var emp = EmployeeRepository.GetById(id);
            if ((emp== null))
            {
                return NotFound("Employee doesn't found");
            }
           return Ok(emp);
        }


        [HttpGet("bydept/{dept}")]  
        public IActionResult GetEmployeesByDept([FromRoute] string dept)
        {
            var emps = EmployeeRepository.GetByDept(dept);
            if (emps.Count == 0)
            {
                return NotFound("No employees found in the specified department.");
            }
            return Ok(emps);
        }


        [HttpPost]
        public IActionResult AddEmployee([FromBody] Models.Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (EmployeeRepository.GetById(emp.Id) != null)
                return Conflict("Employee with this ID already exists.");

            EmployeeRepository.Add(emp);
            return Ok("Addes sucessfully");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee([FromRoute] int id, [FromBody] Employee employee)
        {
            if (id != employee.Id)
                return BadRequest("ID mismatch.");

            if (!EmployeeRepository.Update(employee))
                return NotFound($"Employee with ID {id} not found.");

            return NoContent();
        }

        // PATCH: api/employees/updateEmail/{id}?email=new@mail.com
        [HttpPatch("updateEmail/{id}")]
        public IActionResult UpdateEmployeeEmail([FromRoute] int id, [FromQuery] string email)
        {
            if (!EmployeeRepository.UpdateEmail(id, email))
                return NotFound($"Employee with ID {id} not found.");

            return Ok($"Email updated successfully for employee {id}.");
        }

        // DELETE: api/employees/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            if (!EmployeeRepository.Delete(id))
                return NotFound($"Employee with ID {id} not found.");

            return NoContent();
        }

    }
}
