# LCOV Reports for .NET
Parse and format [LCOV](https://github.com/linux-test-project/lcov) coverage reports,
in [C#](https://learn.microsoft.com/en-us/dotnet/csharp).
	
## Quick start
Install the latest version of **LCOV Reports for .NET** with [NuGet](https://www.nuget.org) package manager:

```shell
dotnet package add Belin.Lcov
```

For detailed instructions, see the [installation guide](Installation.md).

## Usage
This library provides a set of [C#](https://learn.microsoft.com/en-us/dotnet/csharp) classes representing
a [LCOV](https://github.com/linux-test-project/lcov) coverage report and its data.  
The `Report` class, the main one, provides the parsing and formatting features.  

For more details, please refer to the following pages:

- [Parse coverage data from a LCOV file](LcovParsing.md)
- [Format coverage data to the LCOV format](LcovFormatting.md)
