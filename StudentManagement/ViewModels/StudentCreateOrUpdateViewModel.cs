using StudentManagement.Models;

namespace StudentManagement.ViewModels
{
    public sealed class StudentCreateOrUpdateViewModel
    {

        public Student Student { get; set; }
        public List<Teacher> ClassTeachers { get; set; }
        public List<Teacher> MentorTeachers { get; set; }
        public List<Department> Departments { get; set; }
        public List<Hobby> Hobbies { get; set; }

        public StudentCreateOrUpdateViewModel(Student student, List<Teacher> classTeachers, List<Teacher> mentorTeachers, List<Department> departments, List<Hobby> hobbies)
        {
            Student = student;
            ClassTeachers = classTeachers;
            MentorTeachers = mentorTeachers;
            Departments = departments;
            Hobbies = hobbies;
        }
    }
}
