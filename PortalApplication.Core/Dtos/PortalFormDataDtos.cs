using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PortalApplication.Core.Dtos
{
     public class PortalFormDataDtos
     {
        [Required]
        [StringLength(100)]
        public string Fullname { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string TetInstitution { get; set; }
        [Required]
        public string ClassOfDegree { get; set; }
        [Required]
        public int YearofExperience { get; set; }
        [Required]
        public string CurrentRole { get; set; }
        [Required]
        public string CurrentEmployer { get; set; }
        
        public string ProfessionalCertificate { get; set; }
        [Required]
        public string WhyRole { get; set; }
        [Required]
        public List<string> RelevantSkills { get; set; }
        [Required]
        public IFormFile CV { get; set; }
     }
}
