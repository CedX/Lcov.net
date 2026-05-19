namespace Belin.Lcov;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.RegularExpressions;

/// <summary>
/// Represents a trace file, that is a coverage report.
/// </summary>
/// <param name="testName">The test name.</param>
/// <param name="sourceFiles">The source file list.</param>
public partial class Report(string testName, IEnumerable<SourceFile>? sourceFiles = null) {

	/// <summary>
	/// Gets the regular expression used to split the lines.
	/// </summary>
	/// <returns>The regular expression used to split the lines.</returns>
	[GeneratedRegex(@"\r?\n")]
	private static partial Regex NewLinePattern();

	/// <summary>
	/// The source file list.
	/// </summary>
	public IList<SourceFile> SourceFiles { get; set; } = [.. sourceFiles ?? []];

	/// <summary>
	/// The test name.
	/// </summary>
	public string TestName { get; set; } = testName;

	/// <summary>
	/// Parses the specified coverage data in LCOV format.
	/// </summary>
	/// <param name="coverage">The coverage data.</param>
	/// <returns>The resulting coverage report.</returns>
	/// <exception cref="FormatException">A parsing error occurred.</exception>
	public static Report Parse(string coverage) {
		var offset = 0;
		var report = new Report("");
		var sourceFile = new SourceFile("") { Branches = new(), Functions = new(), Lines = new() };

		foreach (var line in NewLinePattern().Split(coverage)) {
			offset++;
			if (string.IsNullOrWhiteSpace(line)) continue;

			var parts = line.Trim().Split(':');
			if (parts.Length < 2 && parts[0] != Tokens.EndOfRecord) throw new FormatException($"Invalid token format at line #{offset}.");

			var data = string.Join(':', parts[1..]).Split(',');
			var token = parts[0];

			switch (token) {
				case Tokens.TestName:
					if (string.IsNullOrWhiteSpace(report.TestName)) report.TestName = data[0];
					break;

				case Tokens.BranchData:
					if (data.Length < 4) throw new FormatException($"Invalid branch data at line #{offset}.");
					sourceFile.Branches?.Data.Add(new() {
						BlockNumber = int.Parse(data[1], NumberStyles.None),
						BranchNumber = int.Parse(data[2], NumberStyles.None),
						LineNumber = int.Parse(data[0], NumberStyles.None),
						Taken = data[3] == "-" ? 0 : int.Parse(data[3], NumberStyles.None)
					});
					break;

				case Tokens.BranchesFound:
					sourceFile.Branches?.Found = int.Parse(data[0], NumberStyles.None);
					break;

				case Tokens.BranchesHit:
					sourceFile.Branches?.Hit = int.Parse(data[0], NumberStyles.None);
					break;

				case Tokens.FunctionData:
					if (data.Length < 2) throw new FormatException($"Invalid function data at line #{offset}.");
					if (sourceFile.Functions is not null) {
						var items = sourceFile.Functions.Data;
						for (var index = 0; index < items.Count; index++)
							if (items[index].FunctionName == data[1])
								items[index] = items[index] with { ExecutionCount = int.Parse(data[0], NumberStyles.None) };
					}
					break;

				case Tokens.FunctionName:
					if (data.Length < 2) throw new FormatException($"Invalid function name at line #{offset}.");
					sourceFile.Functions?.Data.Add(new() { FunctionName = data[1], LineNumber = int.Parse(data[0], NumberStyles.None) });
					break;

				case Tokens.FunctionsFound:
					sourceFile.Functions?.Found = int.Parse(data[0], NumberStyles.None);
					break;

				case Tokens.FunctionsHit:
					sourceFile.Functions?.Hit = int.Parse(data[0], NumberStyles.None);
					break;

				case Tokens.LineData:
					if (data.Length < 2) throw new FormatException($"Invalid line data at line #{offset}.");
					sourceFile.Lines?.Data.Add(new() {
						Checksum = data.Length >= 3 ? data[2] : "",
						ExecutionCount = int.Parse(data[1], NumberStyles.None),
						LineNumber = int.Parse(data[0], NumberStyles.None)
					});
					break;

				case Tokens.LinesFound:
					sourceFile.Lines?.Found = int.Parse(data[0], NumberStyles.None);
					break;

				case Tokens.LinesHit:
					sourceFile.Lines?.Hit = int.Parse(data[0], NumberStyles.None);
					break;

				case Tokens.SourceFile:
					sourceFile = new(data[0]) { Branches = new(), Functions = new(), Lines = new() };
					break;

				case Tokens.EndOfRecord:
					report.SourceFiles.Add(sourceFile);
					break;

				default:
					throw new FormatException($"Unknown token at line #{offset}.");
			}
		}

		return report.SourceFiles.Count > 0 ? report : throw new FormatException("The coverage data is empty or invalid.");
	}

	/// <summary>
	/// Parses the specified coverage data in LCOV format.
	/// </summary>
	/// <param name="coverage">The coverage data.</param>
	/// <param name="report">The resulting coverage report, or <see langword="null"/> if a parsing occurred.</param>
	/// <returns>Value indicating whether the parsing was successfull.</returns>
	public static bool TryParse(string coverage, [NotNullWhen(true)] out Report? report) {
		try {
			report = Parse(coverage);
			return true;
		}
		catch {
			report = null;
			return false;
		}
	}

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <returns>The string representation of this object.</returns>
	public override string ToString() => string.Join('\n', [
		.. string.IsNullOrWhiteSpace(TestName) ? Array.Empty<string>() : [$"{Tokens.TestName}:{TestName}"],
		.. SourceFiles.Select(item => item.ToString())
	]);
}
