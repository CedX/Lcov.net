namespace Belin.Lcov;

/// <summary>
/// Provides details for branch coverage.
/// </summary>
/// <param name="LineNumber">The line number.</param>
/// <param name="BlockNumber">The block number.</param>
/// <param name="BranchNumber">The branch number.</param>
/// <param name="Taken">A number indicating how often this branch was taken.</param>
public sealed record BranchData(int LineNumber = 0, int BlockNumber = 0, int BranchNumber = 0, int Taken = 0) {

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <returns>The string representation of this object.</returns>
	public override string ToString() {
		var value = $"{Tokens.BranchData}:{LineNumber},{BlockNumber},{BranchNumber}";
		return Taken > 0 ? $"{value},{Taken}" : $"{value},-";
	}
}
