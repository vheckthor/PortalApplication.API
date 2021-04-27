using System;
using System.Collections.Generic;

namespace PortalApplication.Core.Models
{
    public class VacancyModel
    {
        public int Id { get; set; }
        public string JobId { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public ICollection<Requirements> Requirement { get; set; }
        public Guid VacancyUniqueId { get; set; }
        public ICollection<Descriptions> Description { get; set; }
        public DateTime CreationDate { get; set; }
        public VacancyModel()
        {
            CreationDate = DateTime.Now;
        }
    }

    public class Requirements
    {
        public int Id { get; set; }
        public Guid VacancyUniqueId { get; set; }
        public string JobRequirements { get; set; }
    }

    public class Descriptions
    {
        public long Id { get; set; }
        public Guid VacancyUniqueId { get; set; }
        public string  JobDescriptions { get; set; }
    }
}