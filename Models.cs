using System;

// ---------------------------------------------------------------
// Models.cs - the "data shapes" used across the program
// ---------------------------------------------------------------

// Grade categories (byte is enough since we only have 4 of them)
enum gradeCategory : byte
{
    Fail,
    Pass,
    Merit,
    Distinction
}

// A struct to bundle one student's info together for display
struct studentRecord
{
    public string Name;
    public int Grade;
    public gradeCategory Category;
}

// Small helper that turns a number grade into a category
static class GradeHelper
{
    public const int MinGrade = 0;
    public const int MaxGrade = 100;

    public static gradeCategory GetCategory(int Grade)
    {
        if (Grade >= 80) return gradeCategory.Distinction;
        if (Grade >= 65) return gradeCategory.Merit;
        if (Grade >= 50) return gradeCategory.Pass;
        return gradeCategory.Fail;
    }
}
