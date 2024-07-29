using System.Data;
using FluentValidation;

namespace CleanArchitecture.Application.Members.Commands.Validators;

public class AddMemberCommandValidator : AbstractValidator<AddMemberCommand>
{
    public AddMemberCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome não pode ser vazio")
            .Length(3, 100).WithMessage("Nome deve ter entre 3 e 100 caracteres");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email não pode ser vazio");

        RuleFor(x => x.About)
            .NotEmpty().WithMessage("Sobre não pode ser vazio");
        
        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage("Idade não pode ser vazio");

        RuleFor(x => x.Salary)
            .Must((x, d) => IsValidDecimalValue(x.Salary))
            .WithMessage("Salario deve ser maio que 0");
        
    }

    private bool IsValidDecimalValue(decimal d)
    {
        return d > 0;
    }
}