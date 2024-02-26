using CAPIV3.DTO;
using CAPIV3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CAPIV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly Capiv3dbContext _db;
        private IWebHostEnvironment _environment;

        public EmployeesController(Capiv3dbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }
        [HttpGet]
        public System.Object Get()
        {

            var res = (from emp in _db.Employees
                       join exp in _db.Experiences
                       on emp.EmployeeId equals exp.EmployeeId
                       select new
                       {
                           emp.EmployeeId,
                           emp.EmployeeName,
                           emp.IsActive,
                           emp.ImageName,
                           emp.JoinDate,
                           emp.Experiences,
                           emp.ImageUrl
                       }).ToList();
            return res;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ep = (from e in _db.Employees
                      where e.EmployeeId == id
                      select new
                      {
                          e.EmployeeName,
                          e.EmployeeId,
                          e.JoinDate,
                          e.IsActive,
                          e.ImageName,
                          e.ImageUrl,
                          e.Experiences
                      }).FirstOrDefault();
            var exp = (from ex in _db.Experiences
                       where ex.EmployeeId == id
                       select new
                       {
                           ex.ExperienceId,
                           ex.Title,
                           ex.Duration
                       }).ToList();
            return Ok(new { ep, exp });
        }
        [HttpPost]
        public async Task<IActionResult> PostEmp([FromForm] Common com)
        {
            string fileName = com.ImageName + ".jpg";
            string url = "\\Upload\\" + fileName;
            if (com.ImageFile?.Length > 0)
            {
                if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                {
                    Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                }
                using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + com.ImageFile.FileName))
                {
                    com.ImageFile.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }
            Employee employee = new Employee
            {
                EmployeeName = com.EmployeeName,
                JoinDate = (DateTime)com.JoinDate,
                IsActive = (bool)com.IsActive,
                ImageName = fileName,
                ImageUrl = url
            };
            _db.Employees.Add(employee);
            await _db.SaveChangesAsync();
            var emp = _db.Employees.FirstOrDefault(x => x.EmployeeName == com.EmployeeName);
            int empId = emp.EmployeeId;
            List<Experience> list =
            JsonConvert.DeserializeObject<List<Experience>>(com.Experiences);
            AddExperiences(empId, list);
            await _db.SaveChangesAsync();
            return Ok("Successfully Added Data ~.~");
        }

        private void AddExperiences(int empId, List<Experience>? list)
        {
            if (list.Any())//same as if not null(list!=null&&list.Count>0)
            {
                foreach (var item in list)
                {
                    Experience exp = new Experience
                    {
                        EmployeeId = empId,
                        Title = item.Title,
                        Duration = item.Duration
                    };
                    _db.Experiences.Add(exp);
                }
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmp(int id, [FromForm] Common com)
        {
            var emp = await _db.Employees.FindAsync(id);
            if (emp == null || id != emp.EmployeeId)
            {
                return NotFound();
            }
            string fileName = com.ImageName + ".jpg";
            string url = "\\Upload\\" + fileName;
            if (com.ImageFile?.Length > 0)
            {
                if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                {
                    Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                }
                using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + com.ImageFile.FileName))
                {
                    com.ImageFile.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }
            emp.EmployeeName = com.EmployeeName;
            emp.IsActive = (bool)com.IsActive;
            emp.JoinDate = (DateTime)com.JoinDate;
            emp.ImageName = fileName;
            emp.ImageUrl = url;

            var exitEx = _db.Experiences.Where(x => x.EmployeeId == id);//Where(x => x.EmployeeId == emp.EmployeeId)
            _db.Experiences.RemoveRange(exitEx);
            List<Experience> list = JsonConvert.DeserializeObject<List<Experience>>(com.Experiences);
            AddExperiences(emp.EmployeeId, list);
            await _db.SaveChangesAsync();
            return Ok("Updated successfully -.-");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmp(int id)
        {
            var emp = await _db.Employees.FindAsync(id);
            _db.Employees.Remove(emp);
            await _db.SaveChangesAsync();
            return Ok("Deleted");
        }
    }
}
