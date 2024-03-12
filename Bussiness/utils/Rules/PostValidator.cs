using Entity.Concrete;
using FluentValidation;

namespace Bussiness.utils.Rules;

public class PostValidator: AbstractValidator<Post>
{
    public PostValidator()
    {
        RuleFor(post => post.Title).NotEmpty().WithMessage("Başlık boş olamaz");
        RuleFor(post => post.Content).NotEmpty().WithMessage("İçerik boş olamaz");
    }
}