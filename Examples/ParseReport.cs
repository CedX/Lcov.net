using Belin.Lcov;
using System.IO;
using System.Text.Json;

// Parses a LCOV report to coverage data.
try {
	var report = Report.Parse(File.ReadAllText("/path/to/lcov.info"));
	Console.WriteLine($"The coverage report contains {report.SourceFiles.Count} source files:");
	Console.WriteLine(JsonSerializer.Serialize(report, new JsonSerializerOptions { WriteIndented = true }));
}
catch (FormatException e) {
	Console.Error.WriteLine(e.Message);
}
