namespace StudentManagement.ViewModels
{
    public sealed class CreateStudentReceivedViewModel
    {
        public string FullName { get; set; }

        public int DepartmentId { get; set; }

        public int ClassTeacherId { get; set; }

        public int MentorTeacherId { get; set; }
        public int[] HobbyIds { get; set; }


        public bool? Status { get; set; } // 0 inactive, 1 active

        public CreateStudentReceivedViewModel()
        {
            Status=true;
        }
    }
}
