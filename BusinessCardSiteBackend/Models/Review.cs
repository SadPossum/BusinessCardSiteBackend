using System.ComponentModel.DataAnnotations;

namespace BusinessCardSiteBackend.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public string AuthorName { get; set; } = "";

        [StringLength(256)]
        public string AuthorContacts { get; set; } = "";

        [StringLength(1024)]
        public string AuthorInformation { get; set; } = "";

        [Required]
        [StringLength(1024)]
        public string SubjectDescription { get; set; } = "";

        [Required]
        [StringLength(1024)]
        public string SubjectOpinion { get; set; } = "";
    }
}

