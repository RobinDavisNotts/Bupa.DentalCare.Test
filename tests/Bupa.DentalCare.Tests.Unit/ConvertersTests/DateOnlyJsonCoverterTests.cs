using Bupa.DentalCare.Test.Converters;
using Bupa.DentalCare.Tests.Unit.Extensions;
using Shouldly;

namespace Bupa.DentalCare.Tests.Unit.ConvertersTests;


public class DateOnlyJsonCoverterTests
{
    private readonly DateOnlyJsonConverter _sut = new DateOnlyJsonConverter();
    
    [Fact]
    public void can_read_mot_format_as_dateonly()
    {
        var result = _sut.Read("\"2024.05.10\"");
        
        result.ShouldBe(new DateOnly(2024, 05, 10));
    }
}