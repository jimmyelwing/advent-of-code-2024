using advent_of_code_2024.Interfaces;
using advent_of_code_2024.Utils;

namespace Day2;

public class Solution : ISolution
{
    public void Solve()
    { 
        var reports  = FileReader.ReadFileForDay(2, false);

        var safeReportsPartOne = 0;
        var safeReportsPartTwo = 0;
        
        foreach (var levels in reports.Select(report =>
                     report.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()))
        {
            if(IsSafe(levels))
                safeReportsPartOne++;

            if (IsSafe(levels) || CanBeMadeSafe(levels))
                safeReportsPartTwo++;
        }
        
        Console.WriteLine($"Part one: {safeReportsPartOne}");
        Console.WriteLine($"Part two: {safeReportsPartTwo}");
    }
    
    private static bool IsSafe(List<int> levels)
    {
        var increasing = false;
        var decreasing = false;

        for (int i = 1; i < levels.Count; i++)
        {
            var diff = levels[i] - levels[i - 1];

            if (IsIdentical(diff)) 
                return false;
            
            if (DifferByMoreThanThree(diff)) 
                return false;

            if (IsIncreasing(diff))
                increasing = true;

            if (IsDecreasing(diff))
                decreasing = true;

            if (increasing && decreasing)
                return false;
        }

        return true;
    }
    
    private static bool CanBeMadeSafe(List<int> levels)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            var modifiedLevels = new List<int>(levels);
            modifiedLevels.RemoveAt(i);

            if (IsSafe(modifiedLevels))
                return true;
        }
        
        return false;
    }


    private static bool IsDecreasing(int diff) => diff < 0;

    private static bool IsIncreasing(int diff) => diff > 0;

    private static bool DifferByMoreThanThree(int diff) => Math.Abs(diff) > 3;

    private static bool IsIdentical(int diff) => Math.Abs(diff) == 0;
}