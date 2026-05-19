namespace Belin.Lcov;

/// <summary>
/// Provides the coverage data of branches.
/// </summary>
public sealed class BranchCoverage {

	/// <summary>
	/// The coverage data.
	/// </summary>
	public IList<BranchData> Data { get; set; } = [];

	/// <summary>
	/// The number of branches found.
	/// </summary>
	public int Found { get; set => field = Math.Max(0, value); }

	/// <summary>
	/// The number of branches hit.
	/// </summary>
	public int Hit { get; set => field = Math.Max(0, value); }

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <returns>The string representation of this object.</returns>
	public override string ToString() => string.Join('\n', [
		.. Data.Select(item => item.ToString()),
		$"{Tokens.BranchesFound}:{Found}",
		$"{Tokens.BranchesHit}:{Hit}"
	]);
}
