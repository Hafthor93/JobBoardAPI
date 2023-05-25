namespace JobBoardAPI.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string Company { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public DateTime Date { get; set; }
        public string Info { get; set; }
        public string Infrastructure { get; set; }
        public string Goals { get; set; }
    }
}
