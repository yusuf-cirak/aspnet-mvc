using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagement.Models;

namespace StudentManagement.ViewModels
{
    public sealed class UpdateStudentReceivedViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int DepartmentId { get; set; }

        public int[] HobbyIds { get; set; }

        public int ClassTeacherId { get; set; }

        public int MentorTeacherId { get; set; }
    }
}