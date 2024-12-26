﻿using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Rentals.Domain.Rentals;
using GtMotive.Renting.Modules.Vehicles.PublicApi;

namespace GtMotive.Renting.Modules.Rentals.Application.Rentals.StartRental;

internal sealed class StartRentalCommandHandler(

    IRentalRepository rentalRepository,

    IVehiclesApi vehiclesApi

) : ICommandHandler<StartRentalCommand>
{
    public async Task<Result> Handle(StartRentalCommand request, CancellationToken cancellationToken)
    {
        ValidateVehicleStatusResponse? validateStatus = await vehiclesApi.ValidateVehicleStatus(request.VehicleId, cancellationToken);

        if (validateStatus is null)
        {
            return Result.Failure(RentalErrors.NotFoundVehicle(request.VehicleId));
        }

        if (!validateStatus.IsValid)
        {
            return Result.Failure(RentalErrors.NotValidVehicleStatus(request.VehicleId));
        }

        bool validateCustomer = await rentalRepository.ValidateCustomerForRental(
            request.CustomerId,
            request.StartDate,
            request.EndDate
        );

        if (validateCustomer)
        {
            return Result.Failure(RentalErrors.CustomerHasActiveReservation(request.CustomerId));
        }

        var rental = Rental.Create(
            request.CustomerId,
            request.VehicleId,
            request.StartDate,
            request.EndDate
        );

        await rentalRepository.StartRental(rental);

        return Result.Success();
    }
}