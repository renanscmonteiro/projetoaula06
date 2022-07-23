using FluentValidation;
using ProjetoAula06a.Entities;
using ProjetoAula06a.Validators.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula06a.Validators
{
    /// <summary>
    /// Classe de validação para a entidade contato
    /// </summary>
    public class ContatoValidator : AbstractValidator<Contato>
    {
        // método construtor
        public ContatoValidator()
        {
            RuleFor(contato => contato.IdContato)
                .NotEmpty().WithMessage("O ID do contato é obrigatório");

            RuleFor(contato => contato.Nome)
                .NotEmpty().WithMessage("O nome do contato é obrigatório")
                .Length(6, 150).WithMessage("Nome deve possuir de 6 à 150 caracteres");

            RuleFor(contato => contato.Email)
                .NotEmpty().WithMessage("O email do contato é obrigatório")
                .EmailAddress().WithMessage("O email do contato é inválido");

            RuleFor(contato => contato.Cpf)
                .NotEmpty().WithMessage("O CPF do contato é obrigatório")
                .Must(CpfValidator.IsValid).WithMessage("O CPF do contato é inválido");

            RuleFor(contato => contato.Telefone)
                .NotEmpty().WithMessage("O telefone do contato é obrigatório")
                .Matches(@"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$").WithMessage("O telefone do contato é inválido");
        }
    }
}