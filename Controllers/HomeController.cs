using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.ViewModels;
using System.Diagnostics;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private List<Student> _students = InMemoryData.Students;

        private List<Teacher> _classTeachers = InMemoryData.ClassTeachers;
        private List<Teacher> _mentorTeachers = InMemoryData.MentorTeachers;

        private List<Department> _departments = InMemoryData.Departments;

        private List<Hobby> _hobbies = InMemoryData.Hobbies;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_students);
        }

        [HttpGet]

        public ActionResult GetStudents() => PartialView("List",_students.Where(e=>e.Status==true).ToList());

        [HttpGet]
    public ActionResult GetCreateOrUpdatePartial([FromQuery] string partialName){

        StudentCreateOrUpdateViewModel viewModel=new(new(),_classTeachers,_mentorTeachers,_departments,_hobbies);

    return PartialView(partialName,viewModel);
    }


    [HttpGet]
    public async Task<JsonResult> Edit([FromQuery]int? id)
    {
        var student = _students.FirstOrDefault(e=>e.Id==id);

        return Json(student);
    }

    [HttpPut]
    [Consumes("application/json")]
    public JsonResult Edit([FromBody]UpdateStudentReceivedViewModel student)
    {
        if (!ModelState.IsValid)
        {
            throw new Exception(ModelState.Values.SelectMany(v => v.Errors).ToString());
        }
            var updatedStudent=_students.FirstOrDefault(e => e.Id==student.Id)?.UpdateStudent(student, _classTeachers, _mentorTeachers, _departments, _hobbies);

            // return PartialView("List",_students.Where(e=>e.Status==true).ToList());
            return Json(updatedStudent);
    }

    [HttpPost]
    [Consumes("application/json")]
    public JsonResult Create([FromBody] CreateStudentReceivedViewModel receivedStudent)
    {
        if (!ModelState.IsValid)
        {
            throw new Exception(ModelState.Values.SelectMany(v => v.Errors).ToString());
        }

        var student=receivedStudent.CreateStudent(_hobbies,_classTeachers,_mentorTeachers,_departments,_students.Max(e=>e.Id));
        
        _students.Add(student);

            return Json(student);
    }

    [HttpDelete]
    [Consumes("application/json")]
    public void Delete([FromQuery] int id)
    {
        if (!ModelState.IsValid)
        {
            throw new Exception(ModelState.Values.SelectMany(v => v.Errors).ToString());
        }
        
        _students.First(e=>e.Id==id).Status=false;

    }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}