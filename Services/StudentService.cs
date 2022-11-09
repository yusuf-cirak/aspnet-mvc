// using StudentManagement.Models;
// using StudentManagement.ViewModels;
// using System.Text;

// namespace StudentManagement.Services
// {
//     public static class StudentMapper
//     {
//         public static List<StudentViewModel> ToStudentViewModel(this List<Student> students, List<Teacher> teachers, List<Department> departments)
//         {
//             return students.Select(student => new StudentViewModel
//             {
//                 Id=student.Id,
//                 FullName=student.FullName,
//                 ClassTeacherName=GetTeacher(teachers, false, student.ClassTeacherId),
//                 DepartmentName=GetDepartment(departments, student.DepartmentId),
//                 MentorTeacherName=GetTeacher(teachers, true, student.MentorTeacherId),
//                 HobbyNames=student.HobbyNames
//             }).ToList();
//         }

//         private static string GetUserHobbiesAsString(List<string> hobbies)
//         {
//             var sb = new StringBuilder();
//             for (int i = 0; i < hobbies.Count; i++)
//             {
//                 sb.Append(hobbies[i]);
//                 if (i!=hobbies.Count-1)
//                 {
//                     sb.Append(", ");
//                 }
//             }
//             return sb.ToString();
//         }


//         private static string GetTeacher(List<Teacher> teachers, bool isMentor, int teacherId)
//             => teachers.Where(t => t.IsMentor==isMentor && t.Id==teacherId).Select(t => t.FullName).FirstOrDefault()!;

//         private static string GetDepartment(List<Department> departments, int departmentId)
//             => departments.Where(d => d.Id==departmentId).Select(d => d.Name).FirstOrDefault()!;




//         public static StudentViewModel UpdateStudentInViewModel(this StudentViewModel studentToUpdate, Student newStudentInfos, List<Teacher> teachers, List<Department> departments)
//         {
//             studentToUpdate.FullName=newStudentInfos.FullName;
//             studentToUpdate.DepartmentName=departments.FirstOrDefault(e => e.Id==newStudentInfos.DepartmentId)!.Name;

//             studentToUpdate.ClassTeacherName=teachers.FirstOrDefault(e => e.Id==newStudentInfos.ClassTeacherId)!.FullName;

//             studentToUpdate.MentorTeacherName=teachers.FirstOrDefault(e => e.Id==newStudentInfos.MentorTeacherId)!.FullName;

//             studentToUpdate.Hobbies=GetUserHobbiesAsString(newStudentInfos.HobbyNames);

//             return studentToUpdate;
//         }
//     }
// }

using StudentManagement.Models;

public static class StudentService{
            public static Student UpdateStudent(this Student studentToUpdate, Student newStudentInfos,List<Teacher> classTeachers,List<Teacher> mentorTeachers,List<Department> departments)
        {
            studentToUpdate.FullName=newStudentInfos.FullName;
            studentToUpdate.ClassTeacher=classTeachers.FirstOrDefault(e=>e.Id==newStudentInfos.ClassTeacherId);
            studentToUpdate.ClassTeacherId=newStudentInfos.ClassTeacherId;


            studentToUpdate.Department=departments.FirstOrDefault(e=>e.Id==newStudentInfos.DepartmentId);
            studentToUpdate.DepartmentId=newStudentInfos.DepartmentId;

            studentToUpdate.MentorTeacher=mentorTeachers.FirstOrDefault(e=>e.Id==newStudentInfos.MentorTeacherId);
            studentToUpdate.MentorTeacherId=newStudentInfos.MentorTeacherId;

            studentToUpdate.Hobbies=newStudentInfos.Hobbies;

            return studentToUpdate;
        }
}