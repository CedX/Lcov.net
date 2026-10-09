namespace Belin.Lcov;

/// <summary>
/// Provides the coverage data of a source file.
/// </summary>
/// <param name="path">The path to the source file.</param>
public class SourceFile(string path) {

	/// <summary>
	/// The branch coverage.
	/// </summary>
	public BranchCoverage? Branches { get; set; }

	/// <summary>
	/// The function coverage.
	/// </summary>
	public FunctionCoverage? Functions { get; set; }

	/// <summary>
	/// The line coverage.
	/// </summary>
	public LineCoverage? Lines { get; set; }

	/// <summary>
	/// The path to the source file.
	/// </summary>
	public string Path { get; set; } = path;

	/// <summary>
	/// Creates a new instance with default coverage values.
	/// </summary>
	/// <param name="path">The path to the source file.</param>
	/// <returns>The newly created source file.</returns>
	public static SourceFile WithCoverage(string path) =>
		new(path) { Branches = new(), Functions = new(), Lines = new() };

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <returns>The string representation of this object.</returns>
	public override string ToString() {
		List<string> output = [$"{Tokens.SourceFile}:{Path}"];
		if (Functions is not null) output.Add(Functions.ToString());
		if (Branches is not null) output.Add(Branches.ToString());
		if (Lines is not null) output.Add(Lines.ToString());
		output.Add(Tokens.EndOfRecord);
		return string.Join('\n', output);
	}
}
