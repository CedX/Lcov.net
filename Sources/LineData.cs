namespace Belin.Lcov;

/// <summary>
/// Provides details for line coverage.
/// </summary>
/// <param name="LineNumber">The line number.</param>
/// <param name="ExecutionCount">The execution count.</param>
/// <param name="Checksum">The data checksum.</param>
public sealed record LineData(int LineNumber = 0, int ExecutionCount = 0, string Checksum = "") {

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <returns>The string representation of this object.</returns>
	public override string ToString() {
		var value = $"{Tokens.LineData}:{LineNumber},{ExecutionCount}";
		return string.IsNullOrWhiteSpace(Checksum) ? value : $"{value},{Checksum}";
	}
}
