using FluentValidation;
using Ozbelsan.DAL.Dto.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.Business.Validation.Project
{
    public class AddProjectValidator : AbstractValidator<AddProjectDto>
    {
        public AddProjectValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Project Name kısmı boş geçilemez")
             .MaximumLength(30).WithMessage("Project name maksımum 30 karakter olmalıdır.");
            RuleFor(p => p.DeliveryDate).NotEmpty().WithMessage("DeliveryDate boş geçilemez.");
        }

       
    }
}
