using System;
using System.Collections.Generic;

namespace API.Models
{
    public class EmailMessage
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public string From { get; set; }
        public string To { get; set; }
        public ICollection<EmailAddress> Cc { get; set; }
        public string Subject { get; set; }
        public string Importance { get; set; }
        public string Content { get; set; }
    }
}