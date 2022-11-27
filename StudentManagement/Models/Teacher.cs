using StudentManagement.Models.Common;

namespace StudentManagement.Models
{
    public sealed class Teacher : Entity
    {
        public string FullName { get; set; }
        public bool IsMentor { get; set; }


        public Teacher()
        {

        }

        public Teacher(int id, string fullName, bool isMentor)
        {
            Id= id;
            FullName= fullName;
            IsMentor= isMentor;
        }
    }
}
