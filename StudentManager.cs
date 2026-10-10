using System;
using System.Collections.Generic;
using System.Linq;

// ---------------------------------------------------------------
// StudentManager.cs - conatins the Dictionary and all the all applicaton 'behaviour'
// ---------------------------------------------------------------

class StudentManager
{
    // Creating a private dictionary ignoring the case of text entries 
    private Dictionary<string, int> Students =
        new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

    public int Count
    {
        get { return Students.Count; }
    }


    public void AddStudent(string Name, int Grade)
    {
        ValidateGrade(Grade);

        if (Students.ContainsKey(Name))
        {
            throw new ArgumentException($"'{Name}' already exists. Use the update option instead.");
        }

        Students.Add(Name, Grade);
    }


    public void UpdateGrade(string Name, int Grade)
    {
        ValidateGrade(Grade);

        if (!Students.ContainsKey(Name))
        {
            throw new KeyNotFoundException($"Student '{Name}' does not exist.");
        }

        Students[Name] = Grade;
    }


    public int GetGrade(string Name)
    {
        if (!Students.TryGetValue(Name, out int Grade))
        {
            throw new KeyNotFoundException($"Student '{Name}' was not found.");
        }

        return Grade;
    }


    public List<studentRecord> GetAllStudents()
    {
        List<studentRecord> Records = new List<studentRecord>();

        foreach (KeyValuePair<string, int> Pair in Students)
        {
            studentRecord Record = new studentRecord();
            Record.Name = Pair.Key;
            Record.Grade = Pair.Value;
            Record.Category = GradeHelper.GetCategory(Pair.Value);
            Records.Add(Record);
        }

        return Records;
    }


    public double GetAverage()
    {
        EnsureNotEmpty();
        return Students.Values.Average();
    }


    public int GetHighest()
    {
        EnsureNotEmpty();
        return Students.Values.Max();
    }

    public int GetLowest()
    {
        EnsureNotEmpty();
        return Students.Values.Min();
    }

    // Private helpers

    private void ValidateGrade(int Grade)
    {
        if (Grade < GradeHelper.MinGrade || Grade > GradeHelper.MaxGrade)
        {
            throw new ArgumentOutOfRangeException(
                nameof(Grade),
                $"Grade must be between {GradeHelper.MinGrade} and {GradeHelper.MaxGrade}.");
        }
    }

    private void EnsureNotEmpty()
    {
        if (Students.Count == 0)
        {
            throw new InvalidOperationException("There are no students yet.");
        }
    }
}
