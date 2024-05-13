namespace Bupa.DentalCare.Test.Store;

public class FetchVehicleAction(string registrationNumber)
{
    public string RegistrationNumber { get; } = registrationNumber;
}