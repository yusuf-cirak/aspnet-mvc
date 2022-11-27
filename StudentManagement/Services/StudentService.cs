using StudentManagement.Models;
using StudentManagement.ViewModels;

public static class StudentService{
            public static Student UpdateStudent(this Student studentToUpdate, UpdateStudentReceivedViewModel receivedUser,List<Teacher> classTeachers,List<Teacher> mentorTeachers,List<Department> departments,List<Hobby> hobbies)
        {

            studentToUpdate.FullName=receivedUser.FullName;

            studentToUpdate.ClassTeacher=classTeachers.FirstOrDefault(e=>e.Id==receivedUser.ClassTeacherId);
            studentToUpdate.ClassTeacherId=receivedUser.ClassTeacherId;

            studentToUpdate.Department=departments.FirstOrDefault(e=>e.Id==receivedUser.DepartmentId);
            studentToUpdate.DepartmentId=receivedUser.DepartmentId;

            studentToUpdate.MentorTeacher=mentorTeachers.FirstOrDefault(e=>e.Id==receivedUser.MentorTeacherId);
            studentToUpdate.MentorTeacherId=receivedUser.MentorTeacherId;


            studentToUpdate.Hobbies=SetStudentHobbies(receivedUser.HobbyIds,hobbies);

            return studentToUpdate;
        }

        public static Student CreateStudent(this CreateStudentReceivedViewModel receivedStudent,List<Hobby> hobbies,List<Teacher> classTeachers,List<Teacher> mentorTeachers,List<Department> departments,int maxId){
            Student student=new();
            student.Id=maxId+1;

            student.FullName=receivedStudent.FullName;

            student.ClassTeacher=classTeachers.FirstOrDefault(e=>e.Id==receivedStudent.ClassTeacherId);
            student.ClassTeacherId=receivedStudent.ClassTeacherId;

            student.Department=departments.FirstOrDefault(e=>e.Id==receivedStudent.DepartmentId);
            student.DepartmentId=receivedStudent.DepartmentId;

            student.MentorTeacher=mentorTeachers.FirstOrDefault(e=>e.Id==receivedStudent.MentorTeacherId);
            student.MentorTeacherId=receivedStudent.MentorTeacherId;


            student.Hobbies=SetStudentHobbies(receivedStudent.HobbyIds,hobbies);

            return student;
        }



        private static List<Hobby> SetStudentHobbies(int[] hobbyIds,List<Hobby> hobbies){
            List<Hobby> hobbyList=new();

            foreach (var id in hobbyIds)
            {
                hobbyList.Add(hobbies.First(e=>e.Id==id)!);
            }

            return hobbyList;

        }
}