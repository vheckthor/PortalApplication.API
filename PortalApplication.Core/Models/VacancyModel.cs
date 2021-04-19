using System;

namespace PortalApplication.Core.Models
{
    public class VacancyModel
    {
        public int Id { get; set; }
        public string JobId { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string[] Requirement { get; set; }
        public string[] Description { get; set; }
        public DateTime CreationDate { get; set; }
        public VacancyModel()
        {
            CreationDate = DateTime.Now;
        }
    }
}