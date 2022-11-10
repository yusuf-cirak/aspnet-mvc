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

        private List<Student> _students = InMemoryDataGenerator.GenerateStudents().Where(e=>e.Status==true).ToList();

        private List<Teacher> _classTeachers = InMemoryDataGenerator.GenerateClassTeachers();
        private List<Teacher> _mentorTeachers = InMemoryDataGenerator.GenerateMentorTeachers();

        private List<Department> _departments = InMemoryDataGenerator.GenerateDepartments();

        private List<Hobby> _hobbies = InMemoryDataGenerator.GenerateHobbies();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_students);
        }

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

    [HttpPost]
    [Consumes("application/json")]
    public ActionResult Edit([FromBody] UpdateStudentReceivedViewModel student)
    {
        if (!ModelState.IsValid)
        {
            throw new Exception(ModelState.Values.SelectMany(v => v.Errors).ToString());
        }
            _students.FirstOrDefault(e => e.Id==student.Id)?.UpdateStudent(student, _classTeachers, _mentorTeachers, _departments, _hobbies);

            return PartialView("List",_students.Where(e=>e.Status==true).ToList());
    }

    [HttpPost]
    [Consumes("application/json")]
    public ActionResult Create([FromBody] CreateStudentReceivedViewModel receivedStudent)
    {
        if (!ModelState.IsValid)
        {
            throw new Exception(ModelState.Values.SelectMany(v => v.Errors).ToString());
        }

        var student=receivedStudent.CreateStudent(_hobbies,_classTeachers,_mentorTeachers,_departments,_students.Max(e=>e.Id));
        
        _students.Add(student);

            return PartialView("List",_students.Where(e=>e.Status==true).ToList());
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