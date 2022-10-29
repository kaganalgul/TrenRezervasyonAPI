using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrenRezervasyon.ApplicationCore.Entities.Concrete;

namespace TrenRezervasyon.ApplicationCore.Validators.Entity
{
    public class VagonValidator : AbstractValidator<Vagon>
    {
        readonly string notNullMessage = "This field can not be empty.";
        readonly string maxLengthMessage = "This field can contains max 100 character.";

        public VagonValidator()
        {
            RuleFor(x => x.Ad)
                .NotNull().WithMessage(notNullMessage)
                .NotEmpty().WithMessage(notNullMessage)
                .MaximumLength(100).WithMessage(maxLengthMessage);
        }
    }
}
