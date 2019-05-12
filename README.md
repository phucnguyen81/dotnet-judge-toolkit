# Description

Example C# project that wraps the judge0 REST API.
The api is for running code from various programming languages
(java, python, c#,...)
The api is at:
https://api.judge0.com/

# Setup

Build with commands from Visual Studio 2017

Dlls are for .NET 4.5

# Plan

## Convert to .NET project

- convert the project to .NET project (DONE)
- extract Core project, which contains the models (DONE)
- extract Demo project, which is an Console App showing code usage (DONE)
- extract Test project, which contains unit tests (DONE)
- extract SysTest project, which contains system tests

## Unit tests for the models (convert to/from json)
## Error handling for making REST calls
## Integration tests
## Have the raw json string returned
In case the model is outdated, at least the json string can be retrieved.
## Use the API version for the SDK version
## See how to use datetime format info
Date and time formats.
ISO 8601 standard is used.
Example: 2016-09-11T10:19:35Z
## GetSubmission call does not work yet (server not implemented?)
TODO try using pure REST calls.
## Get all submissions is forbidden
The request from GetAllSubmissions function returns 'Forbidden'.
Check if the function is not available for the judge0 site.

# DONE
## Create json schema for the API
Get the schema example from ~/prj/LexisNexis/socio

## Make json schema for the API
See https://api.judge0.com/

## Generate models from the schema
Use the script genmodels.ps1, which calls quicktype command.
For the web app, see https://app.quicktype.io/

## Create functions for each API function
- Authenticate (DONE)
- Authorize (DONE)
- Submit (DONE)
- Get one submission (DONE)
- Get all submission (DONE)
- List languages (DONE)
- System Info (DONE)
- System Config (DONE)
- Health Check (DONE)
## Compilation Dependency
Make a base.dll from all code, use it to compile and run all main-code
