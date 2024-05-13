using Bupa.DentalCare.Test.Models;
using Bupa.DentalCare.Test.Services;
using Bupa.DentalCare.Test.Store;
using Bupa.DentalCare.Test.Store.VehicleFeature;
using FluentResults;
using Fluxor;
using Moq;

namespace Bupa.DentalCare.Tests.Unit.EffectTests;

public class VehicleEffectsTests
{
    [Fact]
    public async Task When_Result_Is_Success_Published_Message_Should_Be_Fetch_Vehicle_Result_Action()
    {
        var registration = "XX10ABC";
        var mockUserService = new Mock<IVehicleService>();
        var mockDispatcher = new Mock<IDispatcher>();

        mockUserService.Setup(x => x.GetVehicleDetails(registration)).ReturnsAsync(Result.Ok(new VehicleDetails()));

        var fetchVehicleAction = new FetchVehicleAction(registration);

        var sut = new VehicleEffects(mockUserService.Object);

        await sut.HandleFetchVehicleAction(fetchVehicleAction, mockDispatcher.Object);
        
        mockDispatcher.Verify(d => d.Dispatch(It.IsAny<FetchVehicleResultAction>()));
        
    }
    
    [Fact]
    public async Task When_Result_Is_Failed_Published_Message_Should_Be_Error_Result_Action()
    {
        var registration = "XX10ABC";
        var mockUserService = new Mock<IVehicleService>();
        var mockDispatcher = new Mock<IDispatcher>();

        mockUserService.Setup(x => x.GetVehicleDetails(registration)).ReturnsAsync(Result.Fail("Error"));

        var fetchVehicleAction = new FetchVehicleAction(registration);

        var sut = new VehicleEffects(mockUserService.Object);

        await sut.HandleFetchVehicleAction(fetchVehicleAction, mockDispatcher.Object);
        
        mockDispatcher.Verify(d => d.Dispatch(It.IsAny<ErrorResultAction>()));
        
    }
}