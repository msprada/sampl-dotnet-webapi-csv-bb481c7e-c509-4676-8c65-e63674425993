# Shared Web Class Library

- within this lib we will implement components which can be used for each of the .Net Web API
- following features are included:
    - Authentication
    - Middleware
        - Correlation ID

## Authentication

- Authentication will be done via Azure Entra ID but this can be changed in the aftermath
- feature can be used as follows

```csharp
#Program.cs
using Shared.Web.Authentication;
...
builder.Services.AddFDGAuthentication(builder.Configuration);
```
- important is that oAuthProviderOptions has to be used in the appsettings.Development for local and as env var in production
- check the appsettings.Development.Template.json 
