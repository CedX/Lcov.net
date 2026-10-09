namespace Belin.Lcov;

/// <summary>
/// Tests the features of the <see cref="FunctionCoverage"/> class.
/// </summary>
[TestClass]
public class FunctionCoverageTests {

	[TestMethod]
	public void TestToString() {
		new FunctionCoverage().ToString().ShouldBe("FNF:0\nFNH:0");
		var data = new FunctionData { ExecutionCount = 3, FunctionName = "main", LineNumber = 127 };
		new FunctionCoverage { Data = [data], Found = 23, Hit = 11 }.ToString().ShouldBe("FN:127,main\nFNDA:3,main\nFNF:23\nFNH:11");
	}
}

/// <summary>
/// Tests the features of the <see cref="FunctionData"/> class.
/// </summary>
[TestClass]
public class FunctionDataTests {

	[TestMethod]
	public void TestToString() {
		new FunctionData().ToString().ShouldBe("FN:0,\nFNDA:0,");
		var data = new FunctionData { ExecutionCount = 3, FunctionName = "main", LineNumber = 127 };
		data.ToString().ShouldBe("FN:127,main\nFNDA:3,main");
	}
}
