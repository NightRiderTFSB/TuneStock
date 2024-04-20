using FluentValidation;

using tunestock.api.dto;

namespace tunestock.api.validators;

public class ValidatorInputUserDownload : AbstractValidator<InputUserDownloadDto> {

    public ValidatorInputUserDownload(){
        RuleFor(i => i.SoundID_FK).NotNull().WithMessage("{PropertyName} → No puede ser null");
        RuleFor(i => i.UserID_FK).NotNull().WithMessage("{PropertyName} → No puede ser null");
        RuleFor(i => i.DownloadedDate).NotNull().WithMessage("{PropertyName} → No puede ser null");

        RuleFor(i => i.SoundID_FK).NotEmpty().WithMessage("{PropertyName} → No puede estar vacío");
        RuleFor(i => i.UserID_FK).NotEmpty().WithMessage("{PropertyName} → No puede estar vacío");
        RuleFor(i => i.DownloadedDate).NotEmpty().WithMessage("{PropertyName} → No puede estar vacío");

    }

}