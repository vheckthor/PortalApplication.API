using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
//using Microsoft.AspNetCore.Http;

namespace PortalApplication.Core.Models
{
    public class PortalFormData
    {
        public int Id { get; set; }
        public Guid UniqueIdentifier { get; set; }
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string Role { get; set; }
        public string TetInstitution { get; set; }
        public string ClassOfDegree { get; set; }
        public string YearofExperience { get; set; }
        public string CurrentRole { get; set; }
        public string CurrentEmployer { get; set; }
        public string ProfessionalCertificate { get; set; }
        public string WhyRole { get; set; }
        public string RelevantSkills { get; set; }
        public IFormFile CV { get; set; }
        public string CVLink { get; set; } 
        public Guid JobID { get; set; }
        public DateTime DateCreated { get; set; }

        public PortalFormData()
        {
            DateCreated = DateTime.Now;
        }
    }
    
}
