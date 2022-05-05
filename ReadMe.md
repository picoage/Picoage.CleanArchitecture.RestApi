# Project Layers

![alt text](https://miro.medium.com/max/300/1*Q5RC5Rv9_8d1-KigHhjm-A.png)

- Project is layered according to clean Architecture
- It’s got core, infrastructure and presentation layer

# Testing responsibility of individual layers

- Core layer should have unit tests
- Infrastructure layer should have integration tests
- Presentation layer should have acceptance tests

# Testing framework

- Xunit

# Acceptance Tests

- In-memory test server is used

# Patterns

- Behaviour patterns: Meditor and CQRS patterns used
- Option Pattern is used for reading Config values from appsettings

# Steps to create template locally
Reset-Templates

Get list of template:
dotnet new --list

Add template.json file

Create template
dotnet new --install C:\temp\template\Picoage.CleanArchitecture.RestApi\

Install template on local machine
dotnet new Picoage.CleanArchitecture.RestApi -o TestProject

#Note: SourceName should be same as project name

# Nuget Command 
nuget.exe pack .\Picoage.CleanArchitecture.RestApi.nuspec -OutputDirectory nuget

# Reference
Youtube: https://www.youtube.com/watch?v=GDNcxU0_OuE
         https://www.youtube.com/watch?v=2hpNFrY_faI  

GitHub: https://aka.ms/netcore-templates
