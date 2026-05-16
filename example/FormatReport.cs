using Belin.Lcov;

// Formats coverage data as LCOV report.
var lineData = new[] {
	new LineData { LineNumber = 6, ExecutionCount = 2, Checksum = "PF4Rz2r7RTliO9u6bZ7h6g" },
	new LineData { LineNumber = 7, ExecutionCount = 2, Checksum = "yGMB6FhEEAd8OyASe3Ni1w" }
};

var sourceFile = new SourceFile("/home/cedx/Lcov.net/fixture.cs") {
	Functions = new FunctionCoverage { Found = 1, Hit = 1 },
	Lines = new LineCoverage { Found = 2, Hit = 2, Data = lineData }
};

var report = new Report("Example", [sourceFile]);
Console.WriteLine(report);
