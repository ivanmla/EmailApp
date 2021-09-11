using API.Enums;
using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Email
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public string From { get; set; }
        public string Subject { get; set; }
        public Importance Importance { get; set; }
        public string Content { get; set; }

        public virtual ICollection<ToEmail> Tos { get; set; }
    }
}