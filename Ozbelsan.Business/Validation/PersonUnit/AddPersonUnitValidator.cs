using FluentValidation;
using Ozbelsan.DAL.Dto.PersonUnit;

namespace Ozbelsan.Business.Validation.PersonUnit
{
     public class AddPersonUnitValidator : AbstractValidator<AddPersonUnitDto>
    {
        public AddPersonUnitValidator()
        {
            RuleFor(p => p.UnitName).NotEmpty().WithMessage("PersonUnit adı boş geçilemez.")
      .MaximumLength(50).WithMessage("Maksimum 50 karakterde girilebilir.");
            RuleFor(p => p.Department).NotEmpty().WithMessage("Derpartment boş geçilemez.")
                .MaximumLength(50).WithMessage("Maksimum 50 karakter girilebilir.");
            RuleFor(p => p.PersonelNumber).NotEmpty().WithMessage("PersonNumber boş geçilemez.");
        }
    }
}
