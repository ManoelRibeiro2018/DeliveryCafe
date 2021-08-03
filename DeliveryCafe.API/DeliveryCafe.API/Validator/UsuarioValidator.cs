using DeliveryCafe.API.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Validator
{
    public class UsuarioValidator : AbstractValidator<UsuarioDTO>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.Senha)
                .MinimumLength(4)
                .WithMessage("Senha deve ter no mínimo 4 caracteres");

            RuleFor(u => u)
              .Must(EqualsPasswords)
              .WithMessage("Senha e confimar senha são distintas");

        }
        private static bool EqualsPasswords(UsuarioDTO usuario)
        {
            return usuario.Senha == usuario.ConfirmaSenha;
        }
    }


  
}
