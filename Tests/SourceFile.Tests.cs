namespace Belin.Lcov;

/// <summary>
/// Tests the features of the <see cref="SourceFile"/> class.
/// </summary>
[TestClass]
public class SourceFileTests {

	[TestMethod]
	public void TestToString() {
		var sourceFile = new SourceFile(path: "");
		sourceFile.ToString().ShouldBe("SF:\nend_of_record");

		sourceFile = SourceFile.WithCoverage("/home/CedX/Lcov.net/program.cs");
		sourceFile.ToString().ShouldBe($"SF:/home/CedX/Lcov.net/program.cs\n{sourceFile.Functions}\n{sourceFile.Branches}\n{sourceFile.Lines}\nend_of_record");
	}
}
