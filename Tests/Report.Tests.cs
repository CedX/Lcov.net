namespace Belin.Lcov;

using System.ComponentModel;

/// <summary>
/// Tests the features of the <see cref="Report"/> class.
/// </summary>
[TestClass]
public sealed class ReportTests {

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
		Assert.AreEqual("Example", report.TestName);

		Assert.HasCount(3, report.SourceFiles);
		Assert.AreEqual("/home/CedX/Lcov.net/Fixture.cs", report.SourceFiles[0].Path);
		Assert.AreEqual("/home/CedX/Lcov.net/Func1.cs", report.SourceFiles[1].Path);
		Assert.AreEqual("/home/CedX/Lcov.net/Func2.cs", report.SourceFiles[2].Path);

		var branches = report.SourceFiles[1].Branches!;
		Assert.AreEqual(4, branches.Found);
		Assert.AreEqual(4, branches.Hit);
		Assert.HasCount(4, branches.Data);
		Assert.AreEqual(8, branches.Data[0].LineNumber);

		var functions = report.SourceFiles[1].Functions!;
		Assert.AreEqual(1, functions.Found);
		Assert.AreEqual(1, functions.Hit);
		Assert.HasCount(1, functions.Data);
		Assert.AreEqual("func1", functions.Data[0].FunctionName);

		var lines = report.SourceFiles[1].Lines!;
		Assert.AreEqual(9, lines.Found);
		Assert.AreEqual(9, lines.Hit);
		Assert.HasCount(9, lines.Data);
		Assert.AreEqual("5kX7OTfHFcjnS98fjeVqNA", lines.Data[0].Checksum);

		Assert.Throws<FormatException>(() => Report.Parse("ZZ"));
		Assert.Throws<FormatException>(() => Report.Parse("TN:Example"));
	}

	[TestMethod, DisplayName("ToString")]
	public void TestToString() {
		var sourceFile = new SourceFile(path: "");
		Assert.AreEqual("", new Report("").ToString());
		Assert.AreEqual($"TN:LcovTest\n{sourceFile}", new Report("LcovTest", [sourceFile]).ToString());
	}

	[TestMethod]
	public void TryParse() {
		Assert.IsTrue(Report.TryParse(coverage, out var report));
		Assert.IsNotNull(report);
		Assert.IsFalse(Report.TryParse("TN:Example", out report));
		Assert.IsNull(report);
	}
}
