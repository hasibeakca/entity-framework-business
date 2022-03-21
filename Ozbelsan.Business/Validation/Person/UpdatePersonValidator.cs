using FluentValidation;
using Ozbelsan.DAL.Dto.Person;

namespace Ozbelsan.Business.Validation.Person
{
    public class UpdatePersonValidator : AbstractValidator<UpdatePersonDto>
    {
        public UpdatePersonValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("İsim boş geçilemez.")
                .MinimumLength(2).WithMessage("İsim en az 2 karakter olmalıdır")
                .MaximumLength(20).WithMessage("İsim en fazla 20 karakter olmalıdır.");
            RuleFor(p => p.Surname).NotEmpty().WithMessage("Soyisim boş geçilemez.")
                .MinimumLength(2).WithMessage("Soyisim en az 2 karakter olmalıdır")
                .MaximumLength(20).WithMessage("Soyisim en fazla 20 karakter olmalıdır.");
            RuleFor(p => p.PersonNumber).NotEmpty().WithMessage("Kişi numarası boş geçilemez.");
           
        }
    }
}
