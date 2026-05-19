# LCOV Formatting
Each class provided by this library has a dedicated `ToString()` method returning
the corresponding data formatted as [LCOV](https://github.com/linux-test-project/lcov) string.
All you have to do is to create the adequate structure using these different classes, and to export the final result:

```cs
using Belin.Lcov;

var lineData = new[] {
  new LineData { LineNumber = 6, ExecutionCount = 2, Checksum = "PF4Rz2r7RTliO9u6bZ7h6g" },
  new LineData { LineNumber = 7, ExecutionCount = 2, Checksum = "yGMB6FhEEAd8OyASe3Ni1w" }
};

var sourceFile = new SourceFile("/home/CedX/Lcov.net/Fixture.cs") {
  Functions = new FunctionCoverage { Found = 1, Hit = 1 },
  Lines = new LineCoverage { Found = 2, Hit = 2, Data = lineData }
};

var report = new Report("Example", [sourceFile]);
Console.WriteLine(report);
```

The `Report.ToString()` method will return a [LCOV](https://github.com/linux-test-project/lcov) report formatted like this:

```lcov
TN:Example
SF:/home/CedX/Lcov.net/Fixture.cs
FNF:1
FNH:1
DA:6,2,PF4Rz2r7RTliO9u6bZ7h6g
DA:7,2,yGMB6FhEEAd8OyASe3Ni1w
LF:2
LH:2
end_of_record
```

> [!TIP]
> See the [source code](https://github.com/CedX/Lcov.net/tree/main/Sources) of this library
> for detailed information on the available classes.
