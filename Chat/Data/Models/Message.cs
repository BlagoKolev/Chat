namespace Chat.Data.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public string SenderId { get; set; }
        public virtual ApplicationUser Sender { get; set; }
        public DateTime SentOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
