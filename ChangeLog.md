# Changelog

## Version [5.0.0](https://github.com/CedX/Lcov.net/compare/v4.0.0...v5.0.0)
- Breaking change: replaced the parameterized constructors of the data records by parameterless constructors.

## Version [4.0.0](https://github.com/CedX/Lcov.net/compare/v3.0.0...v4.0.0)
- Breaking change: changed the output of the `FunctionData.ToString()` method.
- Breaking change: removed the `asDefinition` parameter from the `FunctionData.ToString()` method.

## Version [3.0.0](https://github.com/CedX/Lcov.net/compare/v2.3.0...v3.0.0)
- Breaking change: raised the required target framework.
- Ported the [C#](https://learn.microsoft.com/en-us/dotnet/csharp) cmdlets to [PowerShell](https://learn.microsoft.com/en-us/powershell).

## Version [2.3.0](https://github.com/CedX/Lcov.net/compare/v2.2.0...v2.3.0)
- Added the `-Filter` parameter to the `ConvertFrom-Info` cmdlet.

## Version [2.2.0](https://github.com/CedX/Lcov.net/compare/v2.1.0...v2.2.0)
- Added the `-Recurse` parameter to the `ConvertFrom-Info` cmdlet.

## Version [2.1.0](https://github.com/CedX/Lcov.net/compare/v2.0.0...v2.1.0)
- Added [PowerShell](https://learn.microsoft.com/en-us/powershell) cmdlets.

## Version [2.0.0](https://github.com/CedX/Lcov.net/compare/v1.0.1...v2.0.0)
- Breaking change: removed the primary constructor from the `BranchCoverage`, `FunctionCoverage` and `LineCoverage` classes.
- Added support for [.NET](https://dotnet.microsoft.com/en-us) 10.

## Version [1.0.1](https://github.com/CedX/Lcov.net/compare/v1.0.0...v1.0.1)
- Included the debug symbols in the package published on [NuGet](https://www.nuget.org).

## Version 1.0.0
- Initial release.
