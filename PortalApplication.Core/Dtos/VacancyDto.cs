using System.ComponentModel.DataAnnotations;

namespace PortalApplication.Core.Dtos
{
    public class VacancyDto
    {
        [Required]
        public string JobId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string[] Requirement { get; set; }
        [Required]
        public string[] Description { get; set; }

    }
}