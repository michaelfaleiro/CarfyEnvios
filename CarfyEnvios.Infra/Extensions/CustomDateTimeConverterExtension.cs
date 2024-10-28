using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class CustomDateTimeConverterExtension : JsonConverter<DateTime>
{
    private readonly string _format = "dd/MM/yyyy HH:mm";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateString = reader.GetString();
        if (dateString == "0001-01-01T00:00:00")
        {
            return DateTime.MinValue;
        }
        return DateTime.ParseExact(dateString, _format, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_format));
    }
}
