using StudentGradeSystem;

// ═══════════════════════════════════════════════════════════════════════════
//  Student Grade Management System — Program Entry Point
//  Demonstrates: while loop, switch statement, private static methods,
//                console I/O, input validation.
// ═══════════════════════════════════════════════════════════════════════════

GradeManagerService manager = new();

// Seed two demo students so the app isn't empty on first run
SeedDemoData(manager);

bool running = true;

while (running)   // while loop (rubric requirement)
{
    PrintMenu();
    string? choice = Console.ReadLine()?.Trim();

    switch (choice)   // switch statement (rubric requirement)
    {
        case "1":
            HandleAddStudent(manager);
            break;
        case "2":
            HandleAddGrade(manager);
            break;
        case "3":
            HandleViewStudent(manager);
            break;
        case "4":
            HandleViewAll(manager);
            break;
        case "5":
            running = false;
            Console.WriteLine("\nGoodbye!\n");
            break;
        default:
            Console.WriteLine("\n  ⚠ Invalid option. Please enter 1-5.\n");
            break;
    }
}

// ── Private helper methods (rubric requirement: methods) ────────────────

static void PrintMenu()
{
    Console.WriteLine("╔═══════════════════════════════════════════╗");
    Console.WriteLine("║   Student Grade Management System        ║");
    Console.WriteLine("╠═══════════════════════════════════════════╣");
    Console.WriteLine("║  1. Add Student                          ║");
    Console.WriteLine("║  2. Add Grade                            ║");
    Console.WriteLine("║  3. View Student Details                 ║");
    Console.WriteLine("║  4. View All Students                    ║");
    Console.WriteLine("║  5. Exit                                 ║");
    Console.WriteLine("╚═══════════════════════════════════════════╝");
    Console.Write("  Select an option: ");
}

static void HandleAddStudent(GradeManagerService mgr)
{
    Console.Write("\n  Enter student name: ");
    string? name = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("  ⚠ Name cannot be empty.\n");
        return;
    }

    Student student = mgr.AddStudent(name);
    Console.WriteLine($"  ✓ Added: {student}\n");
}

static void HandleAddGrade(GradeManagerService mgr)
{
    Console.Write("\n  Enter student ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("  ⚠ Invalid ID.\n");
        return;
    }

    Console.Write("  Enter grade (0-100): ");
    if (!double.TryParse(Console.ReadLine(), out double grade))
    {
        Console.WriteLine("  ⚠ Invalid grade.\n");
        return;
    }

    if (!GradeUtils.IsValidGrade(grade))
    {
        Console.WriteLine("  ⚠ Grade must be between 0 and 100.\n");
        return;
    }

    if (mgr.AddGrade(id, grade))
    {
        Student? student = mgr.FindStudent(id);
        Console.WriteLine($"  ✓ Grade {grade} added to {student!.Name}. Average: {student.GetAverage():F1} ({student.GetLetterGrade()})\n");
    }
    else
    {
        Console.WriteLine($"  ⚠ Student with ID {id} not found.\n");
    }
}

static void HandleViewStudent(GradeManagerService mgr)
{
    Console.Write("\n  Enter student ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("  ⚠ Invalid ID.\n");
        return;
    }

    Student? student = mgr.FindStudent(id);
    if (student is null)
    {
        Console.WriteLine($"  ⚠ Student with ID {id} not found.\n");
        return;
    }

    Console.WriteLine($"\n  {student}\n");
}

static void HandleViewAll(GradeManagerService mgr)
{
    var students = mgr.GetAllStudents();

    if (students.Count == 0)
    {
        Console.WriteLine("\n  No students enrolled yet.\n");
        return;
    }

    Console.WriteLine($"\n  {"ID",-5} {"Name",-20} {"Grades",-25} {"Avg",-8} {"Letter",-6}");
    Console.WriteLine("  " + new string('─', 65));

    foreach (Student s in students)   // foreach loop (rubric requirement)
    {
        string grades = s.GradeCount > 0
            ? string.Join(", ", s.GetGrades())
            : "—";
        Console.WriteLine($"  {s.Id,-5} {s.Name,-20} {grades,-25} {s.GetAverage(),-8:F1} {s.GetLetterGrade(),-6}");
    }
    Console.WriteLine();
}

static void SeedDemoData(GradeManagerService mgr)
{
    var alice = mgr.AddStudent("Alice Johnson");
    alice.AddGrade(92);
    alice.AddGrade(85);
    alice.AddGrade(88);

    var bob = mgr.AddStudent("Bob Smith");
    bob.AddGrade(76);
    bob.AddGrade(68);
    bob.AddGrade(72);
}
