using Entity.Concrete;
using FluentValidation;

namespace Bussiness.utils.Rules;

public class ProfileValidator: AbstractValidator<Profile>
{
    public ProfileValidator()
    {
        RuleFor(x => x.Content).MinimumLength(10).WithMessage("Açıklamanız en az 10 karakter olmalıdır");
        RuleFor(x => x.Content).MaximumLength(100).WithMessage("Açıklamanız en fazla 100 karakter olmalıdır");
        
    }
}