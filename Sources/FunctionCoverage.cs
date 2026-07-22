namespace Belin.Lcov;

/// <summary>
/// Provides the coverage data of functions.
/// </summary>
public sealed class FunctionCoverage {

	/// <summary>
	/// The coverage data.
	/// </summary>
	public IList<FunctionData> Data { get; set; } = [];

	/// <summary>
	/// The number of functions found.
	/// </summary>
	public int Found { get; set => field = Math.Max(0, value); }

	/// <summary>
	/// The number of functions hit.
	/// </summary>
	public int Hit { get; set => field = Math.Max(0, value); }

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <returns>The string representation of this object.</returns>
	public override string ToString() => string.Join('\n', [
		.. Data.Select(item => item.ToString()),
		$"{Tokens.FunctionsFound}:{Found}",
		$"{Tokens.FunctionsHit}:{Hit}"
	]);
}
