using StudentManagement.Models.Common;

namespace StudentManagement.Models
{
    public sealed class Hobby : Entity
    {
        public string Name { get; set; }

        public Hobby()
        {
        }

        public Hobby(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
