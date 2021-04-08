using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PortalApplication.Core.Dtos
{
    public class ContactFormDto
    {
        [Required]
        [StringLength(30)]
        public string SenderName { get; set; }
        [Required]
        [Phone]
        public string SenderPhone { get; set; }
        [Required]
        [EmailAddress]
        public string SenderEmail { get; set; }
        [Required]
        [StringLength(150,MinimumLength =10,ErrorMessage ="String length cannot be less than 10 or longer than 150")]
        public string Message { get; set; }
    }
}
