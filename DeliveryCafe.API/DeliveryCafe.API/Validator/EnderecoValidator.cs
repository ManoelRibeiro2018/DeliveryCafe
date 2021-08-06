using DeliveryCafe.API.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Validator
{
    public class EnderecoValidator : AbstractValidator<EnderecoDTO>
    {
        public EnderecoValidator()
        {
            RuleFor(e => e.IdUsuario)
                .NotNull()
                .NotEmpty()
                .WithMessage("Necessário informar um usuário");

            RuleFor(e => e.CEP)
                .NotNull()
                .NotEmpty()
                .WithMessage("Necessário informar o CEP");

            RuleFor(e => e.Cidade)
                .NotNull()
                .NotEmpty()
                .WithMessage("Necessário informar a cidade");

            RuleFor(e => e.Bairro)
                .NotNull()
                .NotEmpty()
                .WithMessage("Necessário informar o bairro");
        }
    }
}
