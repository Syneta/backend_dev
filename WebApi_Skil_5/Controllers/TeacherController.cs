using ErdToDatabase.Models.DTOs;
using ErdToDatabase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Skil_5.Data.Interface;
using WebApi_Skil_5.Models;

namespace WebApi_Skil_5.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeacherController : ControllerBase
    {
        private readonly IRepository<Teacher> _repository;

        public TeacherController(IRepository<Teacher> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherDTO>>> GetTeachers()
        {
            try
            {
                var teachers = await _repository.GetAllAsync();
                var teacherDTOs = teachers.Select(t => new TeacherDTO
                {
                    TeacherId = t.TeacherId,
                    TeacherFirstName = t.TeacherFirstName,
                    TeacherLastName = t.TeacherLastName,
                    Subjects = t.Subjects.Select(s => new SubjectDTO
                    {
                        SubjectId = s.SubjectId,
                        Title = s.Title
                    }).ToList()
                }).ToList();
                return Ok(teacherDTOs);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDTO>> GetTeacher(int id)
        {
            var teacher = await _repository.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            var teacherDTO = new TeacherDTO
            {
                TeacherId = teacher.TeacherId,
                TeacherFirstName = teacher.TeacherFirstName,
                TeacherLastName = teacher.TeacherLastName,
                Subjects = teacher.Subjects.Select(s => new SubjectDTO
                {
                    SubjectId = s.SubjectId,
                    Title = s.Title
                }).ToList()
            };
            return Ok(teacherDTO);
        }

        [HttpPost]
        public async Task<ActionResult<TeacherDTO>> CreateTeacher(TeacherDTO teacherDTO)
        {
            var teacher = new Teacher
            {
                TeacherFirstName = teacherDTO.TeacherFirstName,
                TeacherLastName = teacherDTO.TeacherLastName,
                Subjects = teacherDTO.Subjects.Select(s => new Subject
                {
                    SubjectId = s.SubjectId,
                    Title = s.Title
                }).ToList()
            };
            await _repository.AddAsync(teacher);
            teacherDTO.TeacherId = teacher.TeacherId;
            return CreatedAtAction(nameof(GetTeacher), new { id = teacherDTO.TeacherId }, teacherDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, TeacherDTO teacherDTO)
        {
            if (id != teacherDTO.TeacherId)
            {
                return BadRequest();
            }

            var teacher = new Teacher
            {
                TeacherId = teacherDTO.TeacherId,
                TeacherFirstName = teacherDTO.TeacherFirstName,
                TeacherLastName = teacherDTO.TeacherLastName,
                Subjects = teacherDTO.Subjects.Select(s => new Subject
                {
                    SubjectId = s.SubjectId,
                    Title = s.Title
                }).ToList()
            };

            await _repository.UpdateAsync(teacher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _repository.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            await _repository.RemoveAsync(teacher);
            return NoContent();
        }
    }
}
