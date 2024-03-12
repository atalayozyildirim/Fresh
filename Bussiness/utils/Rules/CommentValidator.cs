using Entity.Concrete;
using FluentValidation;

namespace Bussiness.utils.Rules;

public class CommentValidator: AbstractValidator<Comment>
{
    public CommentValidator()
    {
        RuleFor(comment => comment.Content).NotEmpty().WithMessage("Yorum boş olamaz");
    }
}