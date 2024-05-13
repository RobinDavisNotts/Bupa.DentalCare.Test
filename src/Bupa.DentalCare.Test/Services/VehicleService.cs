using Bupa.DentalCare.Test.Models;
using FluentResults;
using Microsoft.Extensions.Options;

namespace Bupa.DentalCare.Test.Services;

public class VehicleService(HttpClient httpClient, IOptions<MotApiSettings> options) : IVehicleService
{
    public async Task<Result<VehicleDetails>> GetVehicleDetails(string registrationNumber)
    {
        httpClient.DefaultRequestHeaders.Add("x-api-key", options.Value.Key);

        try
        {
            var result = await httpClient.GetFromJsonAsync<VehicleDetails[]>(
                $"https://beta.check-mot.service.gov.uk/trade/vehicles/mot-tests?registration={registrationNumber.Replace(" ", "")}");

            return Result.Ok(result.FirstOrDefault());
        }
        catch (HttpRequestException e)
        {
            return Result.Fail(e.Message);
        }
        

        
        
    }
}