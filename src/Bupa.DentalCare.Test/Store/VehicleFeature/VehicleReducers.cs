using Bupa.DentalCare.Test.Store.VehicleUseCase;
using Fluxor;

namespace Bupa.DentalCare.Test.Store.VehicleFeature;

public class VehicleReducers
{
    [ReducerMethod]
    public static VehicleState ReduceFetchVehicleAction(VehicleState state, FetchVehicleAction action) => 
        new VehicleState(isLoading: true, vehicleDetails: null);
    
    [ReducerMethod]
    public static VehicleState ReduceFetchVehicleResultAction(VehicleState state, FetchVehicleResultAction action) => 
        new VehicleState(isLoading: false, vehicleDetails: action.VehicleDetails);
}