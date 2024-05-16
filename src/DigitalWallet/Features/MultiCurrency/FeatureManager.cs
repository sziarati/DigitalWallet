﻿using DigitalWallet.Features.MultiCurrency.Create;
using DigitalWallet.Features.MultiCurrency.UpdateRation;

namespace DigitalWallet.Features.MultiCurrency;

public static class FeatureManager
{
    public const string EndpointTagName = "Currency";


    public static IServiceCollection ConfigureMultiCurrencyFeature(this IServiceCollection services)
    {
        services.AddScoped<CurrencyService>();
        services.AddSingleton<CurrencyConverter>();

        return services;
    }

    public static IEndpointRouteBuilder MapCurrencyFeatures(this IEndpointRouteBuilder endpoint)
    {
        var groupEndpoint = endpoint.MapGroup("/Currency")
                                    .WithTags(EndpointTagName)
                                    .WithDescription("Provides endpoints related to currency management.");

        groupEndpoint.MapCreateCurrencyEndpoint();
        groupEndpoint.AddUpdateRatioEndpoint();

        return endpoint;
    }
}
