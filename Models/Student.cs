using StudentManagement.Models.Common;

namespace StudentManagement.Models
{
    public sealed class Student : Entity
    {
        public int DepartmentId { get; set; }

        public int ClassTeacherId { get; set; }

        public int MentorTeacherId { get; set; }

        public string FullName { get; set; }

        public bool? Status { get; set; } // 0 inactive, 1 active


        public Department? Department { get; set; }

        public List<Hobby>? Hobbies { get; set; }

        public Teacher? ClassTeacher { get; set; }

        public Teacher? MentorTeacher { get; set; }

        public Student()
        {
        }

        public Student(int id, int departmentId, int classTeacherId, int mentorTeacherId, string fullName)
        {
            Id = id;
            DepartmentId = departmentId;
            ClassTeacherId = classTeacherId;
            MentorTeacherId = mentorTeacherId;
            FullName = fullName;
            Status=true;
        }
    }
}
