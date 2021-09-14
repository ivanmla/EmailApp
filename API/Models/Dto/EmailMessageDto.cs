using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Dto
{
    public class EmailMessageDto
    {
        [Required]
        [EmailAddress]
        public string From { get; set; }

        [Required]
        [EmailAddress]
        public string To { get; set; }

        [Required]
        public string Cc { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Importance { get; set; }

        [Required]
        public string Content { get; set; }
    }
}