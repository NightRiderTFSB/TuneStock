using FluentValidation;

using tunestock.api.dto;


namespace tunestock.api.validators;

public class ValidatorInputSoundDto : AbstractValidator<InputSoundDto> {

    public ValidatorInputSoundDto(){

        RuleFor(i => i.UserID).NotNull().WithMessage("{PropertyName} → No puede ser null"); //Debe ser int
        RuleFor(i => i.Price).NotNull().WithMessage("{PropertyName} → No puede ser null"); //Debe ser double
        RuleFor(i => i.File).NotNull().WithMessage("{PropertyName} → No puede ser null"); //Debe ser string
        RuleFor(i => i.IsPremiun).NotNull().WithMessage("{PropertyName} → No puede ser null"); //debe ser bool
        RuleFor(i => i.SoundName).NotNull().WithMessage("{PropertyName} → No puede ser null"); // debe ser string


        RuleFor(i => i.UserID).NotEmpty().WithMessage("{PropertyName} → No puede estar vacío"); //Debe ser int
        RuleFor(i => i.File).NotEmpty().WithMessage("{PropertyName} → No puede estar vacío"); //Debe ser string
        RuleFor(i => i.SoundName).NotEmpty().WithMessage("{PropertyName} → No puede estar vacío"); // debe ser string
    }

}
