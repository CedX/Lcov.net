namespace Belin.Lcov;

/// <summary>
/// Provides the coverage data of lines.
/// </summary>
public sealed class LineCoverage {

	/// <summary>
	/// The coverage data.
	/// </summary>
	public IList<LineData> Data { get; set; } = [];

	/// <summary>
	/// The number of lines found.
	/// </summary>
	public int Found { get; set => field = Math.Max(0, value); }

	/// <summary>
	/// The number of lines hit.
	/// </summary>
	public int Hit { get; set => field = Math.Max(0, value); }

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <returns>The string representation of this object.</returns>
	public override string ToString() => string.Join('\n', [
		.. Data.Select(item => item.ToString()),
		$"{Tokens.LinesFound}:{Found}",
		$"{Tokens.LinesHit}:{Hit}"
	]);
}
