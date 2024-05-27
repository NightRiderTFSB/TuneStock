using FluentValidation;
using tunestock.api.dto;

namespace tunestock.api.validators;

public class ValidatorInputUserDto : AbstractValidator<InputUserDto>
{
    public ValidatorInputUserDto()
    {
        RuleFor(i => i.Username).NotNull().WithMessage("{PropertyName} → No puede ser null");
        RuleFor(i => i.Email).NotNull().WithMessage("{PropertyName} → No puede ser null");
        RuleFor(i => i.Password).NotNull().WithMessage("{PropertyName} → No puede ser null");


        RuleFor(i => i.Username).NotEmpty().WithMessage("{PropertyName} → No puede estar vacío");
        RuleFor(i => i.Email).NotEmpty().WithMessage("{PropertyName} → No puede estar vacío");
        RuleFor(i => i.Password).NotEmpty().WithMessage("{PropertyName} → No puede estar vacío");
    }
}