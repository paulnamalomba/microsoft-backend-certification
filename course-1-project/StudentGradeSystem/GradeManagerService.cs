namespace StudentGradeSystem;

/// <summary>
/// Service layer that manages the collection of students.
/// Demonstrates: List&lt;T&gt;, for loop, encapsulation, LINQ-free search.
/// </summary>
public class GradeManagerService
{
    private readonly List<Student> _students = new();
    private int _nextId = 1;

    // ── Add ─────────────────────────────────────────────────────────────

    /// <summary>Creates a new student and adds them to the roster.</summary>
    public Student AddStudent(string name)
    {
        var student = new Student(_nextId++, name);
        _students.Add(student);
        return student;
    }

    // ── Find ────────────────────────────────────────────────────────────

    /// <summary>
    /// Finds a student by ID using a <c>for</c> loop (rubric requirement).
    /// Returns <c>null</c> if not found.
    /// </summary>
    public Student? FindStudent(int id)
    {
        for (int i = 0; i < _students.Count; i++)   // for loop (rubric requirement)
        {
            if (_students[i].Id == id)
                return _students[i];
        }
        return null;
    }

    // ── Grade Operations ────────────────────────────────────────────────

    /// <summary>Adds a grade to the student identified by <paramref name="studentId"/>.</summary>
    public bool AddGrade(int studentId, double grade)
    {
        Student? student = FindStudent(studentId);
        if (student is null)
            return false;

        student.AddGrade(grade);
        return true;
    }

    // ── Query ───────────────────────────────────────────────────────────

    /// <summary>Returns all students as a read-only list.</summary>
    public IReadOnlyList<Student> GetAllStudents() => _students.AsReadOnly();

    /// <summary>Returns the total number of enrolled students.</summary>
    public int StudentCount => _students.Count;
}
