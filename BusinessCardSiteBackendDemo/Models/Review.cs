namespace BusinessCardSiteBackendDemo.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string AuthorName { get; set; } = "";
        public string AuthorContacts { get; set; } = "";
        public string AuthorInformation { get; set; } = "";
        public string SubjectDescription { get; set; } = "";
        public string SubjectOpinion { get; set; } = "";
    }
}
