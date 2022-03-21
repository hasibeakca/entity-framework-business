using FluentValidation;
using Ozbelsan.DAL.Dto.PersonUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.Business.Validation.PersonUnit
{
   public class UpdatePersonUnitValidator : AbstractValidator<UpdatePersonUnitDto>
    {
        public UpdatePersonUnitValidator()
        {
            RuleFor(p => p.UnitName).NotEmpty().WithMessage("PersonUnit adı boş geçilemez.")
      .MaximumLength(50).WithMessage("Maksimum 50 karakterde girilebilir.");
            RuleFor(p => p.Department).NotEmpty().WithMessage("Derpartment boş geçilemez.")
                .MaximumLength(50).WithMessage("Maksimum 50 karakter girilebilir.");
            RuleFor(p => p.PersonelNumber).NotEmpty().WithMessage("PersonNumber boş geçilemez.");
        }
    }
}
