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

        public string Cc { get; set; }
        
        public string Subject { get; set; }

        //[RegularExpression("[1-3]")]
        public string Importance { get; set; }

        public string Content { get; set; }
    }
}