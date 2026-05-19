namespace Belin.Lcov;

/// <summary>
/// Provides the list of tokens supported by the parser.
/// </summary>
public static class Tokens {

	/// <summary>
	/// The coverage data of a branch.
	/// </summary>
	public const string BranchData = "BRDA";

	/// <summary>
	/// The number of branches found.
	/// </summary>
	public const string BranchesFound = "BRF";

	/// <summary>
	/// The number of branches hit.
	/// </summary>
	public const string BranchesHit = "BRH";

	/// <summary>
	/// The end of a section.
	/// </summary>
	public const string EndOfRecord = "end_of_record";

	/// <summary>
	/// The coverage data of a function.
	/// </summary>
	public const string FunctionData = "FNDA";

	/// <summary>
	/// A function name.
	/// </summary>
	public const string FunctionName = "FN";

	/// <summary>
	/// The number of functions found.
	/// </summary>
	public const string FunctionsFound = "FNF";

	/// <summary>
	/// The number of functions hit.
	/// </summary>
	public const string FunctionsHit = "FNH";

	/// <summary>
	/// The coverage data of a line.
	/// </summary>
	public const string LineData = "DA";

	/// <summary>
	/// The number of lines found.
	/// </summary>
	public const string LinesFound = "LF";

	/// <summary>
	/// The number of lines hit.
	/// </summary>
	public const string LinesHit = "LH";

	/// <summary>
	/// The path to a source file.
	/// </summary>
	public const string SourceFile = "SF";

	/// <summary>
	/// A test name.
	/// </summary>
	public const string TestName = "TN";
}
