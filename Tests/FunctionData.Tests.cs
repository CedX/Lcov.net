namespace Belin.Lcov;

using System.ComponentModel;

/// <summary>
/// Tests the features of the <see cref="FunctionData"/> class.
/// </summary>
[TestClass]
public sealed class FunctionDataTests {

	[TestMethod, DisplayName("ToString")]
	public void TestToString() {
		var data = new FunctionData { ExecutionCount = 3, FunctionName = "main", LineNumber = 127 };
		AreEqual("FN:0,\nFNDA:0,", new FunctionData().ToString());
		AreEqual("FN:127,main\nFNDA:3,main", data.ToString());
	}
}
