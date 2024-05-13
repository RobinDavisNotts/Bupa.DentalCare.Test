using Bupa.DentalCare.Test.Models;

namespace Bupa.DentalCare.Test.Store;

public class FetchVehicleResultAction(VehicleDetails vehicleDetails)
{
    public VehicleDetails VehicleDetails { get; } = vehicleDetails;
}