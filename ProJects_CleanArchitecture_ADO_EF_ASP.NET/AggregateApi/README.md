# API Aggregation Service

## Table of Contents

1. [Introduction](#introduction)
2. [Getting Started](#getting-started)
   - [Prerequisites](#prerequisites)
   - [Installation](#installation)
   - [Configuration](#configuration)
3. [API Endpoints](#api-endpoints)
   - [Aggregated Data Endpoint](#aggragated-data-endpoint)
   - [Statistics Endpoint](#statistics-endpoint)
4. [Error Handling](#error-handling)
5. [Testing](#testing)
6. [Architecture](#architecture)
7. [Performance and Optimization](#performance-and-optimization)

## Introduction

The API Aggregation Service consolidates data from multiple external APIs and provides a unified endpoint for accessing the aggregated information. This service supports integration with various APIs and offers functionalities for filtering, sorting, and performance optimization.

**Integrated APIs:**

- **[WeatherBit API](https://www.weatherbit.io/):** Provides weather data for various locations, including current weather conditions and forecasts.
- **[News API](https://newsapi.org/):** Delivers news articles based on specific keywords. Users can retrieve the latest news and headlines from various sources worldwide.
- **[Football API](https://www.api-football.com/):** Provides football standings and related data, such as team rankings, points, goals, and match statistics for the Greek league.

## Getting Started

### Prerequisites

- .NET 8 SDK
- API keys for the external APIs (WeatherBit API, News API, Football API)
- [Docker](https://www.docker.com/products/docker-desktop) (for using Redis cache)

### Installation

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/ArPapageorgiou/DotNetProjects/tree/master/ProJects_CleanArchitecture_ADO_EF_ASP.NET/AggregateApi

2. **Restore the dependencies:**
   
   ```bash
   dotnet restore

3. **Install Docker:**
   Install Docker from https://www.docker.com/products/docker-desktop and start Redis. Ensure Docker is installed and running on your system. Then start a redis container using the following command:
   
   ```bash
   docker run --name my-redis -d redis

### Configuration

   Configure the external API keys in 'appsettings.json':
```json
   {
  "ApiSettings": {
    "WeatherBitApiKey": "your_weatherbit_api_key",
    "WeatherBitUrl": "https://api.weatherbit.io/v2.0/current",
    "FootballAPIApiKey": "your_footballapi_api_key",
    "FootballAPIUrl": "https://v3.football.api-sports.io/standings",
    "FootballAPIHost": "v3.football.api-sports.io",
    "NewsApiKey": "your_news_api_key",
    "NewsApiUrl": "https://newsapi.org/v2/everything"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft.AspNetCore": "Information"
    }
  },
  "Redis": {
    "Configuration": "localhost:6379",
    "InstanceName": "SampleInstance"
  },
  "AllowedHosts": "*"
}
```

## API Endpoints

### Aggregated Data Endpoint

- **URL:** `/api/aggregateData`
- **Method:** GET
- **Description:** Retrieves aggregated data from external APIs.

#### Request Parameters:

- **temperature** (string, optional): Parameter for sorting weather data by temperature. Use `temperature` to sort weather data by temperature.
- **ascending** (boolean, optional): Sort order for weather. Default is `true` for ascending order.
- **newsKeyword** (string, required): Keyword for news search. Must be provided to retrieve news data.
- **NewsAPI** does not require any parameters and is set to return standings for football teams participating in the Greek Super League for the current year.

#### Examples:

- **Basic News Search:**

   ```http
   GET /api/aggregateData?newsKeyword=technology

- **Sort Weather Data by Temperature - Ascending:**

   ```http
   GET /api/aggregateData?newsKeyword=technology&temperature=temperature&ascending=true
- 
  **Sort Weather Data by Temperature - Descending:**

   ```http
   GET /api/aggregateData?newsKeyword=technology&temperature=temperature&ascending=false

- **News Search with Sorting by Date - Descending:**

   ```http
   GET /api/aggregateData?newsKeyword=technology&ascending=false

- **Combined Query - News Keyword, Sorting Weather by Temperature, and Ascending Order:**

   ```http
   GET /api/aggregateData?newsKeyword=bitcoin&temperature=temperature&ascending=true

#### Example response
```json
{
  "newsApiResponse": {
    "status": "ok",
    "totalResults": 12345,
    "articles": [
      {
        "author": "Jacob Woodward",
        "title": "EA FC 24 Euro 2024 update: When can you play?",
        "description": "Just as the regular season of football has wound down...",
        "url": "https://readwrite.com/ea-fc-24-euro-2024-update-when-can-you-play/",
        "urlToImage": "https://readwrite.com/wp-content/uploads/2024/06/ea-fc-24-euro-2024.jpg",
        "publishedAt": "2024-06-05T12:37:19Z",
        "content": "Just as the regular season of football has wound down, the Euros has reared its glorious head...",
        "source": {
          "id": null,
          "name": "ReadWrite"
        }
      }
    ]
  },
  "weatherData": [
    {
      "data": [
        {
          "wind_cdir": "NNE",
          "rh": 41,
          "pod": "n",
          "lon": 23.71622,
          "pres": 1005.5,
          "timezone": "Europe/Athens",
          "ob_time": "2024-07-05 22:42",
          "country_code": "GR",
          "clouds": 0,
          "vis": 16,
          "wind_spd": 1.03,
          "gust": 1.03,
          "wind_cdir_full": "north-northeast",
          "app_temp": 24.6,
          "state_code": "ESYE31",
          "ts": 1720219370,
          "h_angle": -90,
          "dewpt": 10.9,
          "weather": {
            "icon": "c01n",
            "code": 800,
            "description": "Clear sky"
          },
          "uv": 0,
          "aqi": 54,
          "station": "AU777",
          "sources": [
            "analysis",
            "AU777",
            "radar",
            "satellite"
          ],
          "wind_dir": 32,
          "elev_angle": -28.87,
          "datetime": "2024-07-05:22",
          "precip": 0,
          "ghi": 0,
          "dni": 0,
          "dhi": 0,
          "solar_rad": 0,
          "city_name": "Athens",
          "sunrise": "03:08",
          "sunset": "17:51",
          "temp": 25,
          "lat": 37.97945,
          "slp": 1013.5
        }
      ]
    }
  ],
  "apiResponse": {
    "get": "standings",
    "parameters": {
      "league": "39",
      "season": "2019"
    },
    "errors": [],
    "results": 1,
    "paging": {
      "current": 1,
      "total": 1
    },
    "response": [
      {
        "league": {
          "id": 39,
          "name": "Premier League",
          "country": "England",
          "logo": "https://media.api-sports.io/football/leagues/2.png",
          "flag": "https://media.api-sports.io/flags/gb.svg",
          "season": 2019,
          "standings": [
            [
              {
                "rank": 1,
                "team": {
                  "id": 40,
                  "name": "Liverpool",
                  "logo": "https://media.api-sports.io/football/teams/40.png"
                },
                "points": 70,
                "goalsDiff": 41,
                "group": "Premier League",
                "form": "WWWWW",
                "status": "same",
                "description": "Promotion - Champions League (Group Stage)",
                "all": {
                  "played": 24,
                  "win": 23,
                  "draw": 1,
                  "lose": 0,
                  "goals": {
                    "for": 56,
                    "against": 15
                  }
                },
                "home": {
                  "played": 12,
                  "win": 12,
                  "draw": 0,
                  "lose": 0,
                  "goals": {
                    "for": 31,
                    "against": 9
                  }
                },
                "away": {
                  "played": 12,
                  "win": 11,
                  "draw": 1,
                  "lose": 0,
                  "goals": {
                    "for": 25,
                    "against": 6
                  }
                },
                "update": "2020-01-29T00:00:00+00:00"
              }
            ]
          ]
        }
      }
    ]
  }
}
```

### Statistics Endpoint
- **URL:** /api/aggregate/statistics
- **Method:** GET
- **Description:** Retrieves request statistics for each external API and groups them in performance buckets.

#### Example Response
```json
[
  {
    "ApiName": "WeatherBit",
    "TotalRequests": 150,
    "FastRequests": 100,
    "AverageRequests": 30,
    "SlowRequests": 20,
    "FastAverageTime": 80.5,
    "AverageAverageTime": 150.0,
    "SlowAverageTime": 250.75
  },
  {
    "ApiName": "NewsAPI",
    "TotalRequests": 200,
    "FastRequests": 180,
    "AverageRequests": 15,
    "SlowRequests": 5,
    "FastAverageTime": 70.1,
    "AverageAverageTime": 175.5,
    "SlowAverageTime": 210.3
  },
  {
    "ApiName": "FootballAPI",
    "TotalRequests": 100,
    "FastRequests": 90,
    "AverageRequests": 5,
    "SlowRequests": 5,
    "FastAverageTime": 85.0,
    "AverageAverageTime": 160.2,
    "SlowAverageTime": 230.4
  }
]

```

## Error Handling

### Polly for Resilience

To enhance resilience, the application leverages **Polly** for handling transient failures in external API calls:

- **Retry Policy**: Failed HTTP requests are automatically retried using exponential backoff (with delays of 2, 4, and 8 seconds).
- **Circuit Breaker Policy**: After 3 consecutive failures, the application temporarily halts requests to the failing API for 30 seconds to prevent overloading.

### Default Object Return

In cases where external API calls fail, the application gracefully returns default responses to ensure smooth functionality. For example:

- **NewsService**: If the News API is unavailable, the service will return a set of default articles rather than breaking the user experience.

### Exception Handling

All HTTP requests are wrapped in `try-catch` blocks to handle any unexpected exceptions that Polly may not capture. This ensures that even unhandled errors are caught and managed, maintaining application stability.

## Testing

The application undergoes thorough testing to ensure reliability and correctness.

### Testing Tools

- **NUnit**: This unit testing framework is employed for automated testing of the project's components. NUnit tests ensure that individual units of the application function correctly and adhere to expected behavior.

### Automated Tests

Automated tests written with NUnit are integrated into the development workflow to catch issues early and verify that code changes do not introduce regressions.

## Architecture

The application follows the principles of **Clean Architecture**, promoting separation of concerns and facilitating maintainability and testability. The architecture is structured into the following layers:

- **Controllers**: Handle HTTP requests, responses, and route them to the appropriate services.
- **Services**: Contain the core business logic and handle interactions with external APIs.
- **Repositories**: Manage data access, storage, and caching operations.
- **Models**: Define the data structures used across the application.

#### Dependency Injection

The application adheres to the **SOLID** principles by leveraging **Dependency Injection** to promote loose coupling and enhance testability.


## Performance and Optimization

### Asynchronous Operations

The service leverages `async`/`await` for asynchronous operations, ensuring that external API calls and other I/O-bound tasks do not block the main thread. This approach improves performance and responsiveness by allowing concurrent operations.

### Caching

Redis is used for caching frequently accessed data. Caching reduces the load on external APIs and speeds up response times for end-users by storing and reusing previously fetched data.

### Retry and Circuit Breaker Policies

Polly is used to implement retry and circuit breaker policies for handling transient faults and improving resilience:

- **Retry Policy**: Automatically retries failed HTTP requests using exponential backoff with increasing delays.
- **Circuit Breaker Policy**: Temporarily halts requests to a failing API after multiple consecutive failures to prevent overloading and to allow the API to recover.

### Logging

The application utilizes `ILogger` for comprehensive logging:

- **API Requests and Responses**: Logs details of requests to and responses from external APIs to assist with debugging and performance monitoring.
- **Errors and Exceptions**: Captures and logs errors or exceptions encountered during API interactions to provide insight into issues and failures.



