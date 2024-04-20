using FluentValidation;

using tunestock.api.dto;


namespace tunestock.api.validators;

public class ValidatorInputLabelDto : AbstractValidator<InputLabelDto> {

    public ValidatorInputLabelDto(){
        
        RuleFor(i => i.Labelname).NotEmpty().WithMessage("{PropertyName} → No puede estar vacío");
        RuleFor(i => i.Description).NotEmpty().WithMessage("{PropertyName} → No puede estar vacío");

        RuleFor(i => i.Labelname).NotNull().WithMessage("{PropertyName} → No puede ser null");
        RuleFor(i => i.Description).NotNull().WithMessage("{PropertyName} → No puede ser null");


    }

}