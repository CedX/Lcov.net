namespace Belin.Lcov;

/// <summary>
/// Tests the features of the <see cref="Report"/> class.
/// </summary>
[TestClass]
public class ReportTests {

	/// <summary>
	/// The test fixture.
	/// </summary>
	private readonly string coverage;

	/// <summary>
	/// Creates a new test.
	/// </summary>
	public ReportTests() =>
		coverage = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Lcov.info"));

	[TestMethod]
	public void Parse() {
		var report = Report.Parse(coverage);

		// It should have a test name.
		report.TestName.ShouldBe("Example");

		// It should contain three source files.
		report.SourceFiles.Count.ShouldBe(3);
		report.SourceFiles[0].Path.ShouldBe("/home/CedX/Lcov.net/Fixture.cs");
		report.SourceFiles[1].Path.ShouldBe("/home/CedX/Lcov.net/Func1.cs");
		report.SourceFiles[2].Path.ShouldBe("/home/CedX/Lcov.net/Func2.cs");

		// It should have detailed branch coverage.
		var branches = report.SourceFiles[1].Branches!;
		branches.Found.ShouldBe(4);
		branches.Hit.ShouldBe(4);
		branches.Data.Count.ShouldBe(4);
		branches.Data[0].LineNumber.ShouldBe(8);

		// It should have detailed function coverage.
		var functions = report.SourceFiles[1].Functions!;
		functions.Found.ShouldBe(1);
		functions.Hit.ShouldBe(1);
		functions.Data.Count.ShouldBe(1);
		functions.Data[0].FunctionName.ShouldBe("func1");

		// It should have detailed line coverage.
		var lines = report.SourceFiles[1].Lines!;
		lines.Found.ShouldBe(9);
		lines.Hit.ShouldBe(9);
		lines.Data.Count.ShouldBe(9);
		lines.Data[0].Checksum.ShouldBe("5kX7OTfHFcjnS98fjeVqNA");

		// It should throw an exception if the input is invalid.
		Should.Throw<FormatException>(() => Report.Parse("ZZ"));

		// It should throw an exception if the report is empty.
		Should.Throw<FormatException>(() => Report.Parse("TN:Example"));
	}

	[TestMethod]
	public void TestToString() {
		var sourceFile = new SourceFile(path: "");
		new Report("").ToString().ShouldBe("");
		new Report("LcovTest", [sourceFile]).ToString().ShouldBe($"TN:LcovTest\n{sourceFile}");
	}

	[TestMethod]
	public void TryParse() {
		Report.TryParse(coverage, out var report).ShouldBeTrue();
		report.ShouldNotBeNull();
		Report.TryParse("TN:Example", out report).ShouldBeFalse();
		report.ShouldBeNull();
	}
}
