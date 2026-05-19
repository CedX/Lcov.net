namespace Belin.Lcov;

using System.ComponentModel;

/// <summary>
/// Tests the features of the <see cref="BranchData"/> class.
/// </summary>
[TestClass]
public sealed class BranchDataTests {

	[TestMethod, DisplayName("ToString")]
	public void TestToString() {
		AreEqual("BRDA:0,0,0,-", new BranchData().ToString());
		AreEqual("BRDA:127,3,2,1", new BranchData { BlockNumber = 3, BranchNumber = 2, LineNumber = 127, Taken = 1 }.ToString());
	}
}
