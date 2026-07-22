namespace Belin.Lcov;

using System.ComponentModel;

/// <summary>
/// Tests the features of the <see cref="LineData"/> class.
/// </summary>
[TestClass]
public sealed class LineDataTests {

	[TestMethod, DisplayName("ToString")]
	public void TestToString() {
		var data = new LineData { Checksum = "ed076287532e86365e841e92bfc50d8c", ExecutionCount = 3, LineNumber = 127 };
		AreEqual("DA:0,0", new LineData().ToString());
		AreEqual("DA:127,3,ed076287532e86365e841e92bfc50d8c", data.ToString());
	}
}
