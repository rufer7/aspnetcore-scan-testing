# ASP.NET Core scan testing

> [!NOTE]
> All Azure related secrets are real secrets which got inavlidated before pushing them to the repository

## SonarQube Cloud

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=damienbod_aspnetcore-scan-testing&metric=alert_status)](https://sonarcloud.io/summary/overall?id=damienbod_aspnetcore-scan-testing)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=damienbod_aspnetcore-scan-testing&metric=bugs)](https://sonarcloud.io/summary/overall?id=damienbod_aspnetcore-scan-testing)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=damienbod_aspnetcore-scan-testing&metric=code_smells)](https://sonarcloud.io/summary/overall?id=damienbod_aspnetcore-scan-testing)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=damienbod_aspnetcore-scan-testing&metric=coverage)](https://sonarcloud.io/summary/overall?id=damienbod_aspnetcore-scan-testing)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=damienbod_aspnetcore-scan-testing&metric=duplicated_lines_density)](https://sonarcloud.io/summary/overall?id=damienbod_aspnetcore-scan-testing)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=damienbod_aspnetcore-scan-testing&metric=ncloc)](https://sonarcloud.io/summary/overall?id=damienbod_aspnetcore-scan-testing)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=damienbod_aspnetcore-scan-testing&metric=reliability_rating)](https://sonarcloud.io/summary/overall?id=damienbod_aspnetcore-scan-testing)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=damienbod_aspnetcore-scan-testing&metric=security_rating)](https://sonarcloud.io/summary/overall?id=damienbod_aspnetcore-scan-testing)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=damienbod_aspnetcore-scan-testing&metric=sqale_index)](https://sonarcloud.io/summary/overall?id=damienbod_aspnetcore-scan-testing)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=damienbod_aspnetcore-scan-testing&metric=sqale_rating)](https://sonarcloud.io/summary/overall?id=damienbod_aspnetcore-scan-testing)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=damienbod_aspnetcore-scan-testing&metric=vulnerabilities)](https://sonarcloud.io/summary/overall?id=damienbod_aspnetcore-scan-testing)

## other scans

[![.NET](https://github.com/damienbod/aspnetcore-scan-testing/actions/workflows/dotnet-gitguardian.yml/badge.svg)](https://github.com/damienbod/aspnetcore-scan-testing/actions/workflows/dotnet-gitguardian.yml)

[![.NET](https://github.com/damienbod/aspnetcore-scan-testing/actions/workflows/dotnet-gitleaks.yml/badge.svg)](https://github.com/damienbod/aspnetcore-scan-testing/actions/workflows/dotnet-gitleaks.yml)

[![TruffleHog](https://github.com/damienbod/aspnetcore-scan-testing/actions/workflows/trufflehog.yml/badge.svg)](https://github.com/damienbod/aspnetcore-scan-testing/actions/workflows/trufflehog.yml)

GitHub secret scanning (reported under `Security` tab)

![gh-secret-scanning-push-protection-alert](/gh-secret-scanning-push-protection-alert.png)

![gh-secret-scanning-mail-notification](/gh-secret-scanning-mail-notification.png)

## secrets added to the appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=tcp:mfafidomeid.database.windows.net,1433;Initial Catalog=gridcard;Persist Security Info=False;User ID=damienadmin;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
    "AzureServiceBus": "Endpoint=sb://damienbod-service-bus.servicebus.windows.net/;SharedAccessKeyName=coolkey;SharedAccessKey=ef13VEvOsypQT4Ca0F4w/LIS1susAkzkP+ASbDTk5GI="
  },
  "AzureAd": {
    "ClientSecret": "zkI8Q~HUbCVLgmdbDA6u9XkdA27zpZbqVdEz7a~z",
  },
  "ApiTwo": {
    "accessToken": "eygregertg4ert3gtrhzi76gfnDghmjhmjhmdfrsfreterhgfndghvbfvb"
  },
  "ApiThree": {
    "key": "fgfgfgmr43rfef)333ffrvvdedcggfd43r43gtjnumjnb"
  },
  "CosmosSecrets": {
    "PrimaryKey": "XYOWweBXrNUTlQR1lAi4FhurQa0RX6IfN4PvRWlwS3b7RjZ1vnTjJmi5ZKKW8riByAhtqgUxFqflACDbBtwnHA=="
  },
  "SecretMatchingGitHubPatternExactly": {
    "azure_app_configuration_connection_string": "Endpoint=https://rufer7-app-config.azconfig.io;Id=Rzwa;Secret=2j0xmEQpVWhIrXfjRoKpjtNXQzblP9dgNR9fLFa8rePX31E7s87AJQQJ99BDACYeBjFCQ7wWAAACAZACMRzn"
  }
}
```

## secrets added to `AzureStorageProvider.cs`

```csharp
private string _blobConnectionString = "https://sarufer7.blob.core.windows.net/test?sp=r&st=2025-06-18T11:07:27Z&se=2025-06-18T11:09:27Z&spr=https&sv=2024-11-04&sr=c&sig=JLS7wLGXxvFConsaEGWd4UeD%2BpfC2o9fYcMhH%2FAwnD8%3D";

private string _blobKey = "sp=r&st=2025-06-18T11:07:27Z&se=2025-06-18T11:09:27Z&spr=https&sv=2024-11-04&sr=c&sig=JLS7wLGXxvFConsaEGWd4UeD%2BpfC2o9fYcMhH%2FAwnD8%3D";

var blobClient2 = new BlobClient("https://sarufer7.blob.core.windows.net/test?sp=r&st=2025-06-18T11:07:27Z&se=2025-06-18T11:09:27Z&spr=https&sv=2024-11-04&sr=c&sig=JLS7wLGXxvFConsaEGWd4UeD%2BpfC2o9fYcMhH%2FAwnD8%3D", "test", "arbitrary-file.txt");
```

## secrets added to `Program.cs`

```csharp
var password = "admin1234";
```

## Links

- https://docs.sonarsource.com/sonarqube-cloud/getting-started/github/
- https://github.com/rufer7/github-sonarcloud-integration
- https://github.com/GitGuardian/ggshield
- https://dashboard.gitguardian.com/workspace/142648/perimeter?health=_&sort_health=true&sort_ic=true
- https://github.com/gitleaks/gitleaks
- https://codeql.github.com/docs/
- https://docs.github.com/en/code-security/secret-scanning/introduction/supported-secret-scanning-patterns
- https://github.com/trufflesecurity/trufflehog
