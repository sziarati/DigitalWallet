﻿using DigitalWallet.Common.Persistence;
using DigitalWallet.Features.UserWallet.Common;
using DigitalWallet.Features.UserWallet.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWallet.Features.UserWallet.ChangeTitle;

public static class Endpoint
{

    public static IEndpointRouteBuilder AddChangeTitleEndpoint(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapPatch("/{wallet-id:guid:required}",
            async ([FromRoute(Name = "wallet-id")]Guid Id, ChangeTitleRequest request, WalletService _service, CancellationToken cancellationToken) =>
            {
                var walletId = WalletId.Create(Id);
                await _service.ChangeTitleAsync(walletId, request.Title, cancellationToken);
                
                return Results.Ok("Wallet title changed successfully!");
            }).Validator<ChangeTitleRequestValidator>();

        return endpoint;
    }

}
