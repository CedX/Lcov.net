using Belin.Lcov;

// Formats coverage data as LCOV report.
var functions = new FunctionCoverage { Found = 1, Hit = 1 };
var lines = new LineCoverage { Found = 2, Hit = 2, Data = new LineData[] {
	new() { LineNumber = 6, ExecutionCount = 2, Checksum = "PF4Rz2r7RTliO9u6bZ7h6g" },
	new() { LineNumber = 7, ExecutionCount = 2, Checksum = "yGMB6FhEEAd8OyASe3Ni1w" }
}};

var sourceFile = new SourceFile("/home/CedX/Lcov.net/Fixture.cs") { Functions = functions, Lines = lines};
var report = new Report("Example", [sourceFile]);
Console.WriteLine(report);
