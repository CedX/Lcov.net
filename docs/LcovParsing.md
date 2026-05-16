# LCOV Parsing
The `Report.Parse()` static method parses a [LCOV](https://github.com/linux-test-project/lcov) coverage report provided as string,
and creates a `Report` instance giving detailed information about this coverage report:

```cs
using Belin.Lcov;
using System.IO;
using System.Text.Json;

try {
  var report = Report.Parse(File.ReadAllText("/path/to/lcov.info"));
  Console.WriteLine($"The coverage report contains {report.SourceFiles.Count} source files:");
  Console.WriteLine(JsonSerializer.Serialize(report, new JsonSerializerOptions { WriteIndented = true }));
}
catch (FormatException e) {
  Console.Error.WriteLine(e.Message);
}
```

> [!NOTE]
> A `FormatException` is thrown if any error occurred while parsing the coverage report.  
> You can also use the convenient `Report.TryParse()` method to avoid the exception handling.

Converting the `Report` instance to [JSON](https://www.json.org) format will return a structure like this:

```json
{
  "TestName": "Example",
  "SourceFiles": [
    {
      "Path": "/home/CedX/Lcov.net/Fixture.cs",
      "Branches": {
        "Found": 0,
        "Hit": 0,
        "Data": []
      },
      "Functions": {
        "Found": 1,
        "Hit": 1,
        "Data": [
          {"FunctionName": "main", "LineNumber": 4, "ExecutionCount": 2}
        ]
      },
      "Lines": {
        "Found": 2,
        "Hit": 2,
        "Data": [
          {"LineNumber": 6, "ExecutionCount": 2, "Checksum": "PF4Rz2r7RTliO9u6bZ7h6g"},
          {"LineNumber": 9, "ExecutionCount": 2, "Checksum": "y7GE3Y4FyXCeXcrtqgSVzw"}
        ]
      }
    }
  ]
}
```
