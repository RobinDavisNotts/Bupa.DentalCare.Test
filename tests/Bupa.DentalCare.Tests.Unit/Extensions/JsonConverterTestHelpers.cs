using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bupa.DentalCare.Tests.Unit.Extensions;

public static class JsonConverterTestHelpers
{
    public static TResult? Read<TResult>(this JsonConverter<TResult> converter,
        string token,
        JsonSerializerOptions? options = null)
    {
        options ??= JsonSerializerOptions.Default;
        var bytes = Encoding.UTF8.GetBytes(token);
        var reader = new Utf8JsonReader(bytes);

        reader.Read();
        var result = converter.Read(ref reader, typeof(TResult), options);

        return result;
    }

    public static (bool Success, TResult? Result) TryRead<TResult>(this JsonConverter<TResult> converter, string token,
        JsonSerializerOptions? options)
    {
        try
        {
            var result = Read(converter, token, options);
            return (true, result);
        }
        catch (Exception)
        {
            return (Success: false, Result: default);
        }
    }
}