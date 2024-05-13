using Bupa.DentalCare.Test.Models;
using Bupa.DentalCare.Test.Services;
using Fluxor;

namespace Bupa.DentalCare.Test.Store.VehicleFeature;

public class VehicleEffects(IVehicleService vehicleService)
{
    [EffectMethod]
    public async Task HandleFetchVehicleAction(FetchVehicleAction action, IDispatcher dispatcher)
    {
        var vehicleDetails = await vehicleService.GetVehicleDetails(action.RegistrationNumber);

        if (vehicleDetails.IsSuccess)
        {
            dispatcher.Dispatch(new FetchVehicleResultAction(vehicleDetails.Value));
        }
        else
        {
            dispatcher.Dispatch(new ErrorResultAction(vehicleDetails.Errors));
        }
    }
}