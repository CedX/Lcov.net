namespace Belin.Lcov;

using System.ComponentModel;

/// <summary>
/// Tests the features of the <see cref="LineCoverage"/> class.
/// </summary>
[TestClass]
public sealed class LineCoverageTests {

	[TestMethod, DisplayName("ToString")]
	public void TestToString() {
		var data = new LineData { ExecutionCount = 3, LineNumber = 127 };
		AreEqual("LF:0\nLH:0", new LineCoverage().ToString());
		AreEqual($"{data}\nLF:23\nLH:11", new LineCoverage { Data = [data], Found = 23, Hit = 11 }.ToString());
	}
}
