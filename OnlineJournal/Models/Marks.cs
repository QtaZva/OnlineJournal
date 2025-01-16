namespace OnlineJournal.Models
{
    public class Marks
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SubjectId { get; set; }
        public int Mark {  get; set; }
        public string? date { get; set; }
        public Subject? Subject { get; set; }
    }
}
