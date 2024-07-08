using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

public class JsonValueConverter<T> : ValueConverter<ICollection<T>, string>
{
    public JsonValueConverter() : base(
        v => JsonSerializer.Serialize(v, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }),
        v => JsonSerializer.Deserialize<ICollection<T>>(v, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }))
    {
    }
}