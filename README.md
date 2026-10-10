# Student Grade Management System

A console-based C# application for managing student records and grades.

## Features

- Add a student along with their grade (0-100)
- Display all students with their grade and grade category
- Search for a student by name
- Calculate the average class grade
- Find the highest and lowest grades (using `Max()` and `Min()`)
- Update an existing student's grade
- Error handling for missing students, duplicate names, invalid grades and empty data

## Grade Categories

| Grade | Category |
|-------|----------|
| 80 - 100 | Distinction |
| 65 - 79 | Merit |
| 50 - 64 | Pass |
| 0 - 49 | Fail |

## How to Run

Requires the [.NET SDK](https://dotnet.microsoft.com/download).

```
    git clone https://github.com/octaviusthe3rd/student_grade_system.git
    cd student_grade_system
    dotnet run
```

## Error Handling

| Situation | Exception |
|-----------|-----------|
| Searching for or updating a student that doesn't exist | `KeyNotFoundException` |
| Adding a student that already exists | `ArgumentException` |
| Grade outside of range 0-100 | `ArgumentOutOfRangeException` |
| Average/highest/lowest with no students | `InvalidOperationException` |
| Non-numeric grade input | Handled by `int.TryParse` in `InputHelper` |

Student names are not case sensitive, hence "bob" and "Bob" are the same student.