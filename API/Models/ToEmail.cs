namespace API.Models
{
    public class ToEmail
    {
        public int Id { get; set; }
        public string ToEml { get; set; }

        public int EmailId { get; set; }
        public virtual Email Email { get; set; }
    }
}