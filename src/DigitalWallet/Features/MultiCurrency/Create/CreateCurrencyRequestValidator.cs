﻿namespace DigitalWallet.Features.MultiCurrency.Create;

public class CreateCurrencyRequestValidator : AbstractValidator<CreateCurrencyRequest>
{
    public CreateCurrencyRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(x => x.Code)
            .NotNull()
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.Ration)
            .GreaterThan(0);
    }
}
