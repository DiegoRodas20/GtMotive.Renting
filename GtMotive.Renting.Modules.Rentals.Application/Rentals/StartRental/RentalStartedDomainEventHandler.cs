﻿using GtMotive.Renting.Common.Application.EventBus;
using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Rentals.Application.Rentals.GetRentalById;
using GtMotive.Renting.Modules.Rentals.Domain.Rentals;
using GtMotive.Renting.Modules.Rentals.IntegrationEvents;
using MediatR;

namespace GtMotive.Renting.Modules.Rentals.Application.Rentals.StartRental;

internal sealed class RentalStartedDomainEventHandler(

    ISender sender,

    IEventBus eventBus

) : IDomainEventHandler<RentalStartedDomainEvent>
{
    public async Task Handle(RentalStartedDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        Result<Rental> result = await sender.Send(new GetRentalByIdQuery(domainEvent.RentalId), cancellationToken);

        if (result.IsFailure)
        {
            return;
        }

        var integrationEvent = new RentalStartedIntegrationEvent(
            domainEvent.Id,
            domainEvent.OccurredOnUtc,
            result.Value.Id,
            result.Value.VehicleId
        );

        await eventBus.PublishAsync(integrationEvent, cancellationToken);
    }
}