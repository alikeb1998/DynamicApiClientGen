# DynamicApiClientGen 🛠

Generate fully-typed C# API clients from Swagger/OpenAPI definitions — fast, automatic, and CLI-friendly.

---

## 📦 Features

* Parses Swagger/OpenAPI JSON
* Generates strongly-typed C# API client classes
* Supports HTTP methods: `GET`, `POST`, `PUT`, `DELETE`
* Integrates with `HttpClientFactory`
* Simple CLI usage (install once, use anywhere)
* Cross-platform

---

## 🚀 Installation

```bash
dotnet tool install --global DynamicApiClientGen
```

---

## 🧪 Usage

### From a local Swagger JSON file

```bash
DynamicApiClientGen --input ./swagger.json --output ./GeneratedApiClient.cs
```

### From a remote Swagger URL

```bash
DynamicApiClientGen --input https://api.example.com/swagger/v1/swagger.json --output ./Client.cs
```

---

## 📄 License

This project is licensed under the MIT License.

---

## 🌐 Repository

GitHub: [github.com/yourname/DynamicApiClientGen](https://github.com/yourname/DynamicApiClientGen)
