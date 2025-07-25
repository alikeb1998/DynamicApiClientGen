using System.Text;
using System.Text.Json;

namespace DynamicApiClientGen.Core;

public class ApiClientGenerator
{
    public static string GenerateApiClient(JsonDocument swaggerDoc, string className = "GeneratedApiClient")
        {
            var sb = new StringBuilder();

            sb.AppendLine("using System.Net.Http;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using System.Text.Json;");
            sb.AppendLine();
            sb.AppendLine($"public class {className}");
            sb.AppendLine("{");
            sb.AppendLine("    private readonly HttpClient _httpClient;");
            sb.AppendLine();
            sb.AppendLine($"    public {className}(HttpClient httpClient)");
            sb.AppendLine("    {");
            sb.AppendLine("        _httpClient = httpClient;");
            sb.AppendLine("    }");
            sb.AppendLine();

            var paths = swaggerDoc.RootElement.GetProperty("paths");

            foreach (var path in paths.EnumerateObject())
            {
                var endpointUrl = path.Name;
                var methods = path.Value.EnumerateObject();

                foreach (var method in methods)
                {
                    var methodName = $"{method.Name.ToUpper()}_{endpointUrl.Trim('/').Replace("/", "_").Replace("{", "").Replace("}", "")}";

                    sb.AppendLine($"    public async Task<string> {SanitizeMethodName(methodName)}()");
                    sb.AppendLine("    {");
                    sb.AppendLine($"        var response = await _httpClient.{GetHttpMethodCall(method.Name)}(\"{endpointUrl}\");");
                    sb.AppendLine("        response.EnsureSuccessStatusCode();");
                    sb.AppendLine("        return await response.Content.ReadAsStringAsync();");
                    sb.AppendLine("    }");
                    sb.AppendLine();
                }
            }

            sb.AppendLine("}");

            return sb.ToString();
        }

        private static string SanitizeMethodName(string methodName)
        {
            return methodName.Replace("-", "_").Replace(".", "_");
        }

        private static string GetHttpMethodCall(string method)
        {
            return method.ToLower() switch
            {
                "get" => "GetAsync",
                "post" => "PostAsync",  
                "put" => "PutAsync",
                "delete" => "DeleteAsync",
                _ => "GetAsync"
            };
        }
    }
