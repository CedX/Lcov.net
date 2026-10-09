namespace Belin.Lcov;

/// <summary>
/// Tests the features of the <see cref="LineCoverage"/> class.
/// </summary>
[TestClass]
public class LineCoverageTests {

	[TestMethod]
	public void TestToString() {
		new LineCoverage().ToString().ShouldBe("LF:0\nLH:0");
		var data = new LineData { ExecutionCount = 3, LineNumber = 127 };
		new LineCoverage { Data = [data], Found = 23, Hit = 11 }.ToString().ShouldBe($"{data}\nLF:23\nLH:11");
	}
}

/// <summary>
/// Tests the features of the <see cref="LineData"/> class.
/// </summary>
[TestClass]
public class LineDataTests {

	[TestMethod]
	public void TestToString() {
		new LineData().ToString().ShouldBe("DA:0,0");
		var data = new LineData { Checksum = "ed076287532e86365e841e92bfc50d8c", ExecutionCount = 3, LineNumber = 127 };
		data.ToString().ShouldBe("DA:127,3,ed076287532e86365e841e92bfc50d8c");
	}
}
