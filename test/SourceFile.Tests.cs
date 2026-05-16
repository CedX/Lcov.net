namespace Belin.Lcov;

using System.ComponentModel;

/// <summary>
/// Tests the features of the <see cref="SourceFile"/> class.
/// </summary>
[TestClass]
public sealed class SourceFileTests {

	[TestMethod, DisplayName("ToString")]
	public void TestToString() {
		var sourceFile = new SourceFile(path: "");
		AreEqual("SF:\nend_of_record", sourceFile.ToString());

		sourceFile = new SourceFile("/home/CedX/Lcov.net/program.cs") { Branches = new(), Functions = new(), Lines = new() };
		AreEqual($"SF:/home/CedX/Lcov.net/program.cs\n{sourceFile.Functions}\n{sourceFile.Branches}\n{sourceFile.Lines}\nend_of_record", sourceFile.ToString());
	}
}
