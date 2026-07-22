namespace Belin.Lcov;

/// <summary>
/// Provides details for function coverage.
/// </summary>
public sealed record FunctionData {

	/// <summary>
	/// The execution count.
	/// </summary>
	public int ExecutionCount { get; init; }

	/// <summary>
	/// The function name.
	/// </summary>
	public string FunctionName { get; init; } = "";

	/// <summary>
	/// The line number of the function start.
	/// </summary>
	public int LineNumber { get; init; }

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <returns>The string representation of this object.</returns>
	public override string ToString() => string.Join('\n', [
		$"{Tokens.FunctionName}:{LineNumber},{FunctionName}",
		$"{Tokens.FunctionData}:{ExecutionCount},{FunctionName}"
	]);
}
