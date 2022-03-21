using FluentValidation;
using Ozbelsan.DAL.Dto.ProjectPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.Business.Validation.ProjectPerson
{
 public class UpdateProjectPersonValidator : AbstractValidator<UpdateProjectPersonDto>
    {
        public UpdateProjectPersonValidator()
        {
            RuleFor(p => p.PersonId).NotEmpty().WithMessage("PersonId boş geçilemez.");
            RuleFor(p => p.ProjectId).NotEmpty().WithMessage("ProjectId boş geçilemez.");
        }
    }
}
