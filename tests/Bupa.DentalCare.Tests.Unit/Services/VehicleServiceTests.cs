using System.Net;
using Bupa.DentalCare.Test.Models;
using Bupa.DentalCare.Test.Services;
using Microsoft.Extensions.Options;
using Moq;
using RichardSzalay.MockHttp;
using Shouldly;

namespace Bupa.DentalCare.Tests.Unit.Services;

public class VehicleServiceTests
{
    [Fact]
    public async Task Returns_Success_With_Valid_Registration()
    {
        var registration = "XX10ABC";
        var mockOptions = new Mock<IOptions<MotApiSettings>>();
        mockOptions.Setup(x => x.Value).Returns(new MotApiSettings
        {
            Key = "Api Key"
        } );
        
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When($"https://beta.check-mot.service.gov.uk/trade/vehicles/mot-tests?registration={registration}")
            .WithHeaders(new Dictionary<string, string>
            {
                {"x-api-key", "Api Key"}
            })
            .Respond("application/json", "[{\"Registration\":\"XX10ABC\"}]");

        var sut = new VehicleService(mockHttp.ToHttpClient(), mockOptions.Object);

        var result = await sut.GetVehicleDetails(registration);
        
        result.IsSuccess.ShouldBeTrue();
        result.Value.Registration.ShouldBe(registration);
    }
    
    [Fact]
    public async Task Returns_Failure_With_Invalid_Registration()
    {
        var registration = "XX10ABC";
        var mockOptions = new Mock<IOptions<MotApiSettings>>();
        mockOptions.Setup(x => x.Value).Returns(new MotApiSettings
        {
            Key = "Api Key"
        } );
        
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When($"https://beta.check-mot.service.gov.uk/trade/vehicles/mot-tests?registration={registration}")
            .WithHeaders(new Dictionary<string, string>
            {
                { "x-api-key", "Api Key" }
            })
            .Throw(new HttpRequestException("Vehicle not found", null, HttpStatusCode.NotFound));

        var sut = new VehicleService(mockHttp.ToHttpClient(), mockOptions.Object);

        var result = await sut.GetVehicleDetails(registration);
        
        result.IsSuccess.ShouldBeFalse();
        result.Errors.ShouldContain(x => x.Message == "Vehicle not found");
    }
}