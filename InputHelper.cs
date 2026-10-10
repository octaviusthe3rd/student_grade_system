using System;

// ---------------------------------------------------------------
// InputHelper.cs - reads input from the console and keeps asking until
// the input is valid.
// This way the rest of the program never sees junk.
// ---------------------------------------------------------------

static class InputHelper
{
    // Asks for a non-empty name
    public static string ReadName(string Prompt)
    {
        while (true)
        {
            Console.Write(Prompt);
            string Input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(Input))
            {
                return Input.Trim();
            }

            Console.WriteLine("Name entry cannot be empty, try again.");
        }
    }

    // Asks for a whole number between 0 and 100
    public static int ReadGrade(string Prompt)
    {
        while (true)
        {
            Console.Write(Prompt);
            string Input = Console.ReadLine();

            if (!int.TryParse(Input, out int Grade))
            {
                Console.WriteLine("Please enter a whole number.");
                continue;
            }

            if (Grade < GradeHelper.MinGrade || Grade > GradeHelper.MaxGrade)
            {
                Console.WriteLine($"Grade must be between {GradeHelper.MinGrade} and {GradeHelper.MaxGrade}.");
                continue;
            }

            return Grade;
        }
    }
}
