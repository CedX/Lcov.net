namespace Belin.Lcov;

using System.ComponentModel;

/// <summary>
/// Tests the features of the <see cref="BranchCoverage"/> class.
/// </summary>
[TestClass]
public sealed class BranchCoverageTests {

	[TestMethod, DisplayName("ToString")]
	public void TestToString() {
		var data = new BranchData { BlockNumber = 3, BranchNumber = 2, LineNumber = 127, Taken = 1 };
		AreEqual("BRF:0\nBRH:0", new BranchCoverage().ToString());
		AreEqual($"{data}\nBRF:23\nBRH:11", new BranchCoverage { Data = [data], Found = 23, Hit = 11 }.ToString());
	}
}
