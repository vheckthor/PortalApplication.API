using System;
using System.Collections.Generic;
using System.Text;

namespace PortalApplication.Core.Models
{
    public class ContactFormModel
    {
        public int Id { get; set; }
        public string SenderName { get; set; }
        public string SenderPhone { get; set; }
        public string SenderEmail { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
        public ContactFormModel()
        {
            CreationDate = DateTime.Now;
        }
    }
}
