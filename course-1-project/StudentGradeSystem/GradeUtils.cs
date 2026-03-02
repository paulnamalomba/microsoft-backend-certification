namespace StudentGradeSystem;

/// <summary>
/// Static utility class for grade-related helpers.
/// Demonstrates: static methods, if-else branching, input validation.
/// </summary>
public static class GradeUtils
{
    /// <summary>
    /// Converts a numeric average (0-100) to a letter grade.
    /// Uses an if-else chain (rubric requirement: control structures).
    /// </summary>
    public static string ToLetterGrade(double average)
    {
        if (average >= 90)
            return "A";
        else if (average >= 80)
            return "B";
        else if (average >= 70)
            return "C";
        else if (average >= 60)
            return "D";
        else
            return "F";
    }

    /// <summary>Validates that a grade falls within the 0-100 range.</summary>
    public static bool IsValidGrade(double grade) => grade >= 0 && grade <= 100;
}
