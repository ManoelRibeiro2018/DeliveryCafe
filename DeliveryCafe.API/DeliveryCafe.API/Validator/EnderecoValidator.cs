using DeliveryCafe.API.Especification;
using DeliveryCafe.API.Interface.Especification;
using DeliveryCafe.API.Models;
using DeliveryCafe.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Validator
{
    public class EnderecoValidator : AbstractValidator<EnderecoDTO>
    {
        private readonly ISpecification<EnderecoDTO> _specification;
        public EnderecoValidator(ISpecification<EnderecoDTO> specification)
        {
            _specification = specification;

            RuleFor(e => e)
                .Must(VerifyExist)
                .WithMessage("Endereço já cadastrado para o usuário");

            RuleFor(e => e)
                .Must(VerifExistUser)
                .WithMessage("Usuário inválido");

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

        private bool VerifyExist(EnderecoDTO enderecoDTO)
        {
            return !_specification.IsSatisfiedBy(enderecoDTO);
        }

        private bool VerifExistUser(EnderecoDTO enderecoDTO)
        {
            return _specification.VerifyExistEntity(enderecoDTO) ;
        }
    }
}
