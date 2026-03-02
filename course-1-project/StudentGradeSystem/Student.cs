namespace StudentGradeSystem;

/// <summary>
/// Represents a student with a name, ID, and a collection of grades.
/// Demonstrates: class design, encapsulation, List&lt;T&gt;, foreach loop, methods.
/// </summary>
public class Student
{
    // ── Properties ──────────────────────────────────────────────────────
    public int Id { get; }
    public string Name { get; }
    private List<double> Grades { get; } = new();

    // ── Constructor ─────────────────────────────────────────────────────
    public Student(int id, string name)
    {
        Id = id;
        Name = name;
    }

    // ── Methods ─────────────────────────────────────────────────────────

    /// <summary>Adds a validated grade (0-100) to the student's record.</summary>
    public void AddGrade(double grade)
    {
        if (!GradeUtils.IsValidGrade(grade))
            throw new ArgumentOutOfRangeException(nameof(grade), "Grade must be between 0 and 100.");

        Grades.Add(grade);
    }

    /// <summary>Returns a read-only copy of all grades.</summary>
    public IReadOnlyList<double> GetGrades() => Grades.AsReadOnly();

    /// <summary>
    /// Calculates the arithmetic mean of all grades.
    /// Uses a <c>foreach</c> loop to iterate over the collection.
    /// </summary>
    public double GetAverage()
    {
        if (Grades.Count == 0)
            return 0.0;

        double sum = 0;
        foreach (double g in Grades)   // foreach loop (rubric requirement)
        {
            sum += g;
        }
        return sum / Grades.Count;
    }

    /// <summary>Maps the average grade to a letter grade via <see cref="GradeUtils"/>.</summary>
    public string GetLetterGrade() => GradeUtils.ToLetterGrade(GetAverage());

    /// <summary>Returns the number of recorded grades.</summary>
    public int GradeCount => Grades.Count;

    // ── Display ─────────────────────────────────────────────────────────
    public override string ToString()
    {
        string grades = Grades.Count > 0 ? string.Join(", ", Grades) : "No grades yet";
        return $"[{Id}] {Name}  |  Grades: {grades}  |  Avg: {GetAverage():F1}  |  Letter: {GetLetterGrade()}";
    }
}
