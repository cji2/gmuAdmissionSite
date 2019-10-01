using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFSecurityShell.Models
{
    public class Applicant
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Display(Name = "Submission Date")]
        public DateTime CreateTime { get; set; }

        [Required(ErrorMessage = "SSN is Required")]
        [RegularExpression(@"^\d{9}|\d{3}-\d{2}-\d{4}$", ErrorMessage = "Invalid Social Security Number")]
        [Display(Name = "SSN")]
        public string SocialSecurityNo { get; set; }

        // Becomes <input type="email" ... >
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Becomes <input type="tel" ... >
        [Required]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string HomePhone { get; set; }

        // Becomes <input type="tel" ... >
        [Required]
        [Display(Name = "Cell Phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [DataType(DataType.PhoneNumber)]
        public string CellPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string Street { get; set; }

        [Required]
        [StringLength(45)]
        public string City { get; set; }

        [Required]
        [StringLength(12)]
        public string State { get; set; }

        [Required(ErrorMessage = "Zip is Required")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "High School Name")]
        public string SchoolName { get; set; }

        [Required]
        [Display(Name = "High School City")]
        public string SchoolCity { get; set; }

        [Required]
        [Display(Name = "Graduation Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime GraduationDate { get; set; }

        [Required(ErrorMessage = "GPA is required")]
        [Range(0.1, 4, ErrorMessage = "GPA must be between 0.0 and 4.0")]
        [RegularExpression(@"^\d+(.\d{1,2})?$")]
        [Display(Name = "Current GPA (4.0 scale)")]
        public decimal GPA { get; set; }

        [Required]
        [Range(0, 800)]
        [Display(Name = "SAT Math Score")]
        public int MathScore { get; set; }

        [Required]
        [Range(0, 800)]
        [Display(Name = "SAT Verbal Score")]
        public int VerbalScore { get; set; }

        [Required]
        [Display(Name = "Combined SAT Score")]
        public int TotalScore { get; set; }

        [Required]
        [Display(Name = "Primary Area of Interest")]
        public Major PAOfInterest { get; set; }

        [Required]
        [Display(Name = "Perspective Enrollment Date")]
        public Semester EnrollmentSemester { get; set; }

        [Required]
        [Range(2019, 2030)]
        [Display(Name = "Prospective Enrollment Year")]
        public int EnrollmentYear { get; set; }

        [Required]
        [Display(Name = "Enrollment Decision")]
        public Decision EnrollmentDecision { get; set; }

        public Applicant()
        {
            this.CreateTime = DateTime.Now;
        }
    }

    public enum Major
    {
        Physics,
        Mathematics,
        Statistics,
        Sociology,
        Linguistics,
        Biology
    }

    public enum Semester
    {
        Fall, Spring, Summer
    }

    public enum Decision
    {
        Admit, Reject, Wait_List
    }
}