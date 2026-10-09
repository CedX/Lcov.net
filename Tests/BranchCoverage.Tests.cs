namespace Belin.Lcov;

/// <summary>
/// Tests the features of the <see cref="BranchCoverage"/> class.
/// </summary>
[TestClass]
public class BranchCoverageTests {

	[TestMethod]
	public void TestToString() {
		new BranchCoverage().ToString().ShouldBe("BRF:0\nBRH:0");
		var data = new BranchData { BlockNumber = 3, BranchNumber = 2, LineNumber = 127, Taken = 1 };
		new BranchCoverage { Data = [data], Found = 23, Hit = 11 }.ToString().ShouldBe($"{data}\nBRF:23\nBRH:11");
	}
}

/// <summary>
/// Tests the features of the <see cref="BranchData"/> class.
/// </summary>
[TestClass]
public class BranchDataTests {

	[TestMethod]
	public void TestToString() {
		new BranchData().ToString().ShouldBe("BRDA:0,0,0,-");
		new BranchData { BlockNumber = 3, BranchNumber = 2, LineNumber = 127, Taken = 1 }.ToString().ShouldBe("BRDA:127,3,2,1");
	}
}
