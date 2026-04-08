# ApiDataProcessor

Console application developed in **C# / .NET** to consume and process data from multiple external APIs.

## Features

* **Real-time weather lookup** by city
* **Currency exchange rate lookup**
* **User listing** from a public API
* Error handling for request and data processing failures
* Layered project organization with separation of responsibilities

## Technologies Used

* C#
* .NET 9
* HttpClient
* System.Text.Json

## Project Structure

```plaintext
ApiDataProcessor
├── Models
│   ├── WeatherData.cs
│   ├── CurrencyData.cs
│   └── UserData.cs
│
├── Services
│   ├── WeatherService.cs
│   ├── CurrencyService.cs
│   └── UserService.cs
│
└── Program.cs
```

## APIs Used

* Weather API: OpenWeather
* Currency API: Frankfurter
* User API: JSONPlaceholder

## How to Run

1. Clone the repository:

```bash
git clone https://github.com/luancarvalh-o/api-data-processor.git
```

2. Navigate to the project folder:

```bash
cd ApiDataProcessor
```

3. Run the application:

```bash
dotnet run
```

## What I Practiced

* Consuming REST APIs
* JSON deserialization and manipulation
* Exception handling
* Organizing code with a simple layered architecture
* C# development best practices

## Author

Developed by Luan.
