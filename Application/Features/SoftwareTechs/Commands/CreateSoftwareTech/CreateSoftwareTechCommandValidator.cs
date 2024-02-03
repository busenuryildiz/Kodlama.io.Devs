using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.SoftwareTechs.Commands.CreateSoftwareTech
{
    public class CreateSoftwareTechCommandValidator : AbstractValidator<CreateSoftwareTechCommand>
    {
        public CreateSoftwareTechCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
