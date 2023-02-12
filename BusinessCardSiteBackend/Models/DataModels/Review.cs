namespace BusinessCardSiteBackend.Models.DataModels
{
    public class Review
    {
        public int Id { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorContacts { get; set; } = string.Empty;
        public string AuthorInformation { get; set; } = string.Empty;
        public string SubjectDescription { get; set; } = string.Empty;
        public string SubjectOpinion { get; set; } = string.Empty;
    }
}

