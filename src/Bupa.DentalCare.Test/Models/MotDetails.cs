using System.Text.Json.Serialization;
using Bupa.DentalCare.Test.Converters;

namespace Bupa.DentalCare.Test.Models;

public class MotDetails
{
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly ExpiryDate { get; set; }
    public int OdometerValue { get; set; }
    
}