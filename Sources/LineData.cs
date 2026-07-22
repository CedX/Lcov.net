namespace Belin.Lcov;

/// <summary>
/// Provides details for line coverage.
/// </summary>
public sealed record LineData {

	/// <summary>
	/// The data checksum.
	/// </summary>
	public string Checksum { get; init; } = "";

	/// <summary>
	/// The execution count.
	/// </summary>
	public int ExecutionCount { get; init; }

	/// <summary>
	/// The line number.
	/// </summary>
	public int LineNumber { get; init; }

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <returns>The string representation of this object.</returns>
	public override string ToString() {
		var value = $"{Tokens.LineData}:{LineNumber},{ExecutionCount}";
		return string.IsNullOrWhiteSpace(Checksum) ? value : $"{value},{Checksum}";
	}
}
