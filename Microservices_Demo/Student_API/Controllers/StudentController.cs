using Student_API.Entities;
using Student_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Student_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentRepository repository, ILogger<StudentController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Student>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _repository.GetStudents();
            return Ok(students);
        }

        [HttpGet("{id:length(1)}", Name = "GetStudent")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Student), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Student>> GetStudentById(string id)
        {
            var student = await _repository.GetStudent(id);
            if (student == null)
            {
                _logger.LogError($"Student with id: {id}, not found.");
                return NotFound();
            }
            return Ok(student);
        }

        [Route("[action]/{year}", Name = "GetStudentByYear")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Student>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentByYear(int year)
        {
            var students = await _repository.GetStudentByYear(year);
            return Ok(students);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Student), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Student>> CreateProduct([FromBody] Student student)
        {
            await _repository.CreateStudent(student);

            return CreatedAtRoute("GetStudent", new { id = student.Id }, student);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Student), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student)
        {
            return Ok(await _repository.UpdateStudent(student));
        }

        [HttpDelete("{id:length(1)}", Name = "DeleteStudent")]
        [ProducesResponseType(typeof(Student), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteStudentById(string id)
        {
            return Ok(await _repository.DeleteStudent(id));
        }
    }
}

