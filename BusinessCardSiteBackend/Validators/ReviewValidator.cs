using BusinessCardSiteBackend.Models.DataModels;
using FluentValidation;

namespace BusinessCardSiteBackend.Validators
{
    public class ReviewValidator : AbstractValidator<Review>
    {
        public ReviewValidator()
        {
            RuleFor(model => model.AuthorName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(model => model.AuthorInformation).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(model => model.AuthorContacts).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(model => model.SubjectDescription).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(model => model.SubjectOpinion).NotNull().NotEmpty().MaximumLength(200);
        }
    }
}
