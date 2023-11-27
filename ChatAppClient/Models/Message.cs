namespace ChatAppClient.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int SendUserId { get; set; }
        public int ReceiverUserId { get; set; }
        public DateTime Time { get; set; }
    }
}
