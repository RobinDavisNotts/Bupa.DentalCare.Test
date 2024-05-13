using Bupa.DentalCare.Test.Models;
using FluentResults;

namespace Bupa.DentalCare.Test.Services;

public interface IVehicleService
{
    Task<Result<VehicleDetails>> GetVehicleDetails(string registrationNumber);
}