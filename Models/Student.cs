using System;
using System.ComponentModel.DataAnnotations;

namespace Student.Models
{
    public class StudentEntity
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Please enter the student's first name."), StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the student's last name."), StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the student's major."), StringLength(50, ErrorMessage = "Major cannot exceed 50 characters.")]
        public string Major { get; set; } = string.Empty;

        //double? because student's may not have a gpa yet.
        [Range(0, 4.0, ErrorMessage = "GPA must be between 0 and 4.0")]
        public double? GPA { get; set; }
        
        [Required(ErrorMessage = "Please enter the student's enrollment date."), Display(Name = "Enrollment Date"), DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
