# Course 1 Project — Student Grade Management System

> **Microsoft Back-End Developer Professional Certificate**  
> Coursera · Course 1 Assignment  

---

## Quick Start

```bash
cd StudentGradeSystem
dotnet build
dotnet run
```

The app launches with two pre-seeded students (Alice & Bob) so you can explore immediately.

---

## Project Structure

```
course-1-project/
├── REQUIREMENTS_AND_DESIGN.md    ← Requirements (Section 1) & Design (Section 2)
├── README.md                     ← This file
└── StudentGradeSystem/
    ├── StudentGradeSystem.csproj ← .NET 8.0 console project
    ├── Program.cs                ← Entry point — menu loop, switch, static methods
    ├── Student.cs                ← Model — properties, foreach, encapsulation
    ├── GradeManagerService.cs    ← Service — for loop, find/add logic
    └── GradeUtils.cs             ← Static helpers — if-else, validation
```

---

## Features

| Feature              | Description                                          |
| -------------------- | ---------------------------------------------------- |
| Add Student          | Enter a name → auto-assigned sequential ID           |
| Add Grade            | Enter student ID + grade (0-100) → validated & stored |
| View Student         | Look up by ID → see all grades, average, letter grade |
| View All Students    | Formatted table of every student's summary           |
| Input Validation     | Non-numeric and out-of-range inputs handled gracefully |
| Demo Data            | Two students with grades seeded on startup           |

---

## Rubric Checklist

- [x] **Requirements document** — `REQUIREMENTS_AND_DESIGN.md` Section 1
- [x] **Design outline** — `REQUIREMENTS_AND_DESIGN.md` Section 2 (Mermaid diagrams)
- [x] **Control structures** — `if-else` (GradeUtils), `switch` (Program menu)
- [x] **Loops** — `while` (menu loop), `for` (FindStudent), `foreach` (GetAverage, ViewAll)
- [x] **Methods** — static helpers, parameterised methods, methods with return values
- [x] **Classes & encapsulation** — `Student`, `GradeManagerService`, `GradeUtils`

---

## Tech Stack

- **Language:** C# 12
- **Framework:** .NET 8.0
- **Dependencies:** None (standard library only)

---

*Paul Namalomba — March 2026*
