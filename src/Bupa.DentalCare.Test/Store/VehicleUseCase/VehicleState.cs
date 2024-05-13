using Bupa.DentalCare.Test.Models;
using Fluxor;

namespace Bupa.DentalCare.Test.Store.VehicleUseCase;

[FeatureState]
public class VehicleState(bool isLoading, VehicleDetails? vehicleDetails)
{
    public bool IsLoading { get; } = isLoading;
    public VehicleDetails? VehicleDetails { get; } = vehicleDetails;

    private VehicleState() : this(false, null)
    {
    }
}