using FluentValidation;
using tunestock.api.dto;

namespace tunestock.api.validators;

public class ValidatorInputUserPurchaseDto : AbstractValidator<InputUserPurchaseDto>
{
    public ValidatorInputUserPurchaseDto()
    {
        RuleFor(i => i.UserID_FK).NotNull().WithMessage("{PropertyName} → No puede ser null");
        RuleFor(i => i.SoundID_FK).NotNull().WithMessage("{PropertyName} → No puede ser null");
        RuleFor(i => i.SoundPrice).NotNull().WithMessage("{PropertyName} → No puede ser null");
        RuleFor(i => i.PurchasedDate).NotNull().WithMessage("{PropertyName} → No puede ser null");
        RuleFor(i => i.PaymentStatus).NotNull().WithMessage("{PropertyName} → No puede ser null");
        RuleFor(i => i.PaymentMethod).NotNull().WithMessage("{PropertyName} → No puede ser null");

        RuleFor(i => i.UserID_FK).NotEmpty().WithMessage("{PropertyName} → No puede estar vacío");
        RuleFor(i => i.SoundID_FK).NotEmpty().WithMessage("{PropertyName} → No puede estar vacío");
        RuleFor(i => i.SoundPrice).NotEmpty().WithMessage("{PropertyName} → No puede estar vacío");
        RuleFor(i => i.PurchasedDate).NotEmpty().WithMessage("{PropertyName} → No puede estar vacío");

        RuleFor(i => i.PaymentMethod).NotEmpty().WithMessage("{PropertyName} → No puede estar vacío");
    }
}