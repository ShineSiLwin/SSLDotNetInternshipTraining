using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSLDotNetInternshipTraining.AdoDotNet
{
    public  class Student
    {
        public int StudentId { get; set; }

        public string StudentNo { get; set; } = string.Empty;

        public string StudentName { get; set; } = string.Empty;
        public string? FatherName { get; set; }

        public string? Address { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
