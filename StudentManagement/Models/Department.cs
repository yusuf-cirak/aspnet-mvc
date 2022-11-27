using StudentManagement.Models.Common;

namespace StudentManagement.Models
{
    public sealed class Department : Entity
    {
        public string Name { get; set; }


        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
