using System.Text.Json;

namespace DynamicApiClientGen.Core;

public class SwaggerParser
{
    public static JsonDocument ParseSwaggerJson(string swaggerJson)
    {
        return JsonDocument.Parse(swaggerJson);
    }
}