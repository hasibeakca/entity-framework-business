using FluentValidation;
using Ozbelsan.DAL.Dto.Project;

namespace Ozbelsan.Business.Validation.Project
{
    public class UpdateProjectValidator : AbstractValidator<UpdateProjectDto>
    {
        public UpdateProjectValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Project Name kısmı boş geçilemez")
              .MaximumLength(30).WithMessage("Project name maksımum 30 karakter olmalıdır.");
            RuleFor(p => p.DeliveryDate).NotEmpty().WithMessage("DeliveryDate boş geçilemez.");

        }
    }
}
