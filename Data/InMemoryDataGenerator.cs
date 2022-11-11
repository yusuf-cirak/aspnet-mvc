using StudentManagement.Models;

namespace StudentManagement.Data
{
    public static class InMemoryData
    {
        private static List<Department>? _departments;
        public static List<Department> Departments =>_departments??= GenerateDepartments();

        private static List<Hobby>? _hobbies;
        public static List<Hobby> Hobbies =>_hobbies??= GenerateHobbies();

        private static List<Teacher>? _classTeachers;
        public static List<Teacher> ClassTeachers =>_classTeachers??= GenerateClassTeachers();

        private static List<Teacher>? _mentorTeachers;
        public static List<Teacher> MentorTeachers =>_mentorTeachers??= GenerateMentorTeachers();

         private static List<Student>? _students;
        public static List<Student> Students =>_students??= GenerateStudents();

        public static List<Department> GenerateDepartments()
        {
            List<Department> departments = new()
            {
                new(1, "Felsefe"),
                new(2, "Matematik")
            };

            return departments;
        }

        public static List<Hobby> GenerateHobbies()
        {
            List<Hobby> hobbies = new()
            {
                new(1, "Yüzme"),
                new(2, "Basketbol"),
                new(3, "Müzik"),
                new(4, "Edebiyat")
            };

            return hobbies;
        }

        public static List<Teacher> GenerateClassTeachers()
        {
            List<Teacher> classTeachers = new()
            {
                new Teacher(1, "Namık San", false),
                new Teacher(2, "Halil Meşe", false),
                
            };
            return classTeachers;
        }

        public static List<Teacher> GenerateMentorTeachers()
        {
            List<Teacher> mentorTeachers = new()
            {
                new Teacher(3, "Melda Sönmez", true),
                new Teacher(4, "Nida Akyüz", true)
            };
            return mentorTeachers;
        }

        public static List<Student> GenerateStudents()
        {
            List<Student> students = new();


            students.Add(new(1, 1, 1, 4, "Mehmet Söylemez")
            {
                Hobbies=new List<Hobby>
                {
                    new(1,"Yüzme"),
                    new(2,"Basketbol")
                },
                Department=new(1,"Felsefe"),
                ClassTeacher=new(2,"Halil Meşe",false),
                MentorTeacher=new(4,"Nida Akyüz",true)
            });

            students.Add(new(2, 2, 2, 3, "Berkay Hinci")
            {
                Hobbies=new List<Hobby>
                {
                    new(3,"Müzik"),
                    new(4,"Edebiyat")
                },
                Department=new(2,"Matematik"),
                ClassTeacher=new(1,"Namık San",false),
                MentorTeacher=new(3,"Melda Sönmez",true)
            });

            return students;
        }


    }
}
