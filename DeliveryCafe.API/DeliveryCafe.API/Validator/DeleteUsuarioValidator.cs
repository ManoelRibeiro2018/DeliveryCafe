using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Validator
{
    public class DeleteUsuarioValidator : AbstractValidator<int>
    {
        public DeleteUsuarioValidator()
        {
            RuleFor(i => i)
                .NotNull()
                .WithMessage("informe um usuário");


            RuleFor(i => i)
                .NotEqual(0)
                .WithMessage("informe um usuário");
        }    
    }
}
