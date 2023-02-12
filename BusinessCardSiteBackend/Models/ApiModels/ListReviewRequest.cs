using BusinessCardSiteBackend.Models.LogicModels;

namespace BusinessCardSiteBackend.Models.ApiModels
{
    public class ListReviewRequest
    {
        public string? AuthorName { get; set; } = null;
        public PaginationFilter? Pagination { get; set; } = null;
        public List<SortCriteria>? Sort { get; set; } = null;
    }
}
