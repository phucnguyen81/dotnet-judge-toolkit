# Description

Example C# project that wraps the judge0 REST API (https://api.judge0.com/).
The api is for running code from various programming languages (Java, Python,
C#,...)

# Setup

Install .NET SDK 2.2

Build all projects:
```
$ dotnet build
```

Run test projects:
```
$ dotnet test
```

Run demo:
```
$ dotnet run --project Demo
```

# Tasks

## Create unit tests for all models

## Add error handling for making REST calls

## Have the raw json string returned
In case the model is outdated, at least the json string can be retrieved.

## Proper system tests

- Verity results of Functions calls
- Error handling

## See how to use datetime format info
Date and time formats.
ISO 8601 standard is used.
Example: 2016-09-11T10:19:35Z

## Get all submissions is forbidden
The request from GetAllSubmissions function returns 'Forbidden'.
Check if the function is not available for the judge0 site.
