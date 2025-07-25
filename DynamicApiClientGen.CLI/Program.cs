using System.CommandLine;
using DynamicApiClientGen.Core;

var inputOption = new Option<string>(
    "--input",
    "Input Swagger/OpenAPI file path or URL"
);

var outputOption = new Option<string>(
    "--output",
    "Output C# file path"
);

var rootCommand = new RootCommand("DynamicApiClientGen CLI Tool")
{
    inputOption,
    outputOption
};

rootCommand.SetHandler(async (string input, string output) =>
{
    string swaggerJson;

    if (Uri.IsWellFormedUriString(input, UriKind.Absolute))
    {
        Console.WriteLine("Fetching Swagger from URL...");
        using var httpClient = new HttpClient();
        swaggerJson = await httpClient.GetStringAsync(input);
    }
    else if (File.Exists(input))
    {
        Console.WriteLine("Reading Swagger from local file...");
        swaggerJson = await File.ReadAllTextAsync(input);
    }
    else
    {
        Console.WriteLine("ERROR: Invalid input. Must be a valid URL or existing file path.");
        return;
    }

    var swaggerDoc = SwaggerParser.ParseSwaggerJson(swaggerJson);

    Console.WriteLine("Generating API Client...");
    var generatedCode = ApiClientGenerator.GenerateApiClient(swaggerDoc);

    FileWriter.WriteToFile(output, generatedCode);

    Console.WriteLine($"✔ API Client generated successfully at: {output}");

}, inputOption, outputOption);

return await rootCommand.InvokeAsync(args);