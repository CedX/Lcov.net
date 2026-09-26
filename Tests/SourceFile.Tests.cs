namespace Belin.Lcov;

/// <summary>
/// Tests the features of the <see cref="SourceFile"/> class.
/// </summary>
[TestClass]
public sealed class SourceFileTests {

	[TestMethod]
	public void TestToString() {
		var sourceFile = new SourceFile(path: "");
		Assert.AreEqual("SF:\nend_of_record", sourceFile.ToString());

		sourceFile = SourceFile.WithCoverage("/home/CedX/Lcov.net/program.cs");
		Assert.AreEqual($"SF:/home/CedX/Lcov.net/program.cs\n{sourceFile.Functions}\n{sourceFile.Branches}\n{sourceFile.Lines}\nend_of_record", sourceFile.ToString());
	}
}
