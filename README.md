# DynamicApiClientGen 🛠

Generate fully-typed C# API clients from Swagger/OpenAPI definitions — fast, automatic, and CLI-friendly.

---

## 📆 Features

* Parses Swagger/OpenAPI JSON
* Generates strongly-typed C# API client classes
* Supports HTTP methods: `GET`, `POST`, `PUT`, `DELETE`
* Integrates with `HttpClientFactory`
* Simple CLI usage (install once, use anywhere)
* Usable as a .NET library in your own code
* Cross-platform

---

## 🚀 Installation

### 📌 CLI Tool (Global)

```bash
dotnet tool install --global DynamicApiClientGen
```

### 📆 Core Library (NuGet)

```bash
dotnet add package DynamicApiClientGen.Core
```

---

## 🧪 Usage

### ✅ CLI Tool (Command-Line)

#### From a local Swagger JSON file

```bash
DynamicApiClientGen --input ./swagger.json --output ./GeneratedApiClient.cs
```

#### From a remote Swagger URL

```bash
DynamicApiClientGen --input https://api.example.com/swagger/v1/swagger.json --output ./Client.cs
```

---

### ✅ Core Library (Programmatic Usage in C#)

```csharp
using DynamicApiClientGen.Core;
using System.Text.Json;

var swaggerJson = File.ReadAllText("swagger.json");
var swaggerDoc = SwaggerParser.ParseSwaggerJson(swaggerJson);

var generatedCode = ApiClientGenerator.GenerateApiClient(swaggerDoc);
File.WriteAllText("GeneratedClient.cs", generatedCode);
```
### With URL :

```csharp
var json = await new HttpClient().GetStringAsync("https://api.example.com/swagger.json");
using var swagger = JsonDocument.Parse(json);
var code = ApiClientGenerator.GenerateApiClient(swagger);
```
### ٌهف
---

## 📄 License

This project is licensed under the **MIT License**.
You are free to use, modify, distribute, and integrate it into personal or commercial projects.

---

## 🌐 Repository

GitHub: [github.com/alikeb1998/DynamicApiClientGen](https://github.com/alikeb1998/DynamicApiClientGen)

---

## ✨ NuGet Packages

| Project                 | Package Name               | Installation Command                               |
| ----------------------- | -------------------------- | -------------------------------------------------- |
| CLI Tool                | `DynamicApiClientGen`      | `dotnet tool install --global DynamicApiClientGen` |
| Core Library (C# usage) | `DynamicApiClientGen.Core` | `dotnet add package DynamicApiClientGen.Core`      |

---

## 🙌 Contributing

Feel free to open [issues](https://github.com/alikeb1998/DynamicApiClientGen/issues) or submit pull requests.
Feedback and contributions are always welcome!
---
> ☕ Like this project? [Buy me a coffee](https://buymeacoffee.com/alikeb) — every bit of support helps!

