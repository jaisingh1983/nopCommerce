using FluentValidation;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Nop.Web.Models.Books;

namespace Nop.Web.Validators.Books
{
    public class BookValidator : BaseNopValidator<BooksModel>
    {
        public BookValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Web.Books.Fields.Name.Required"));
            RuleFor(x => x.CreatedOn).NotEmpty().WithMessage(localizationService.GetResource("Web.Books.Fields.CreatedOn.Required"));
        }
    }
}
