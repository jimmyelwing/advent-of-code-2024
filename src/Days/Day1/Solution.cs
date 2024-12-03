using advent_of_code_2024.Utils;

namespace advent_of_code_2024.Days.Day1;

public class Solution
{
    public void Solve()
    {
        var data = FileReader.ReadFileForDay(1, false);

        List<int> leftLocationIds = [];
        List<int> rightLocationIds = [];
        
        foreach (var ids in data.Select(locationId => locationId.Split(' ', StringSplitOptions.RemoveEmptyEntries)))
        {
            leftLocationIds.Add(int.Parse(ids[0]));
            rightLocationIds.Add(int.Parse(ids[1]));
        }

        leftLocationIds.Sort();
        rightLocationIds.Sort();
        
        Console.WriteLine("--- Day One ---");
        Console.WriteLine();
        AnswerPartOne(leftLocationIds, rightLocationIds);
        AnswerPartTwo(leftLocationIds, rightLocationIds);
        Console.WriteLine();
        Console.WriteLine("---------------");
    }
    
    private static void AnswerPartOne(List<int> leftLocationIds, List<int> rightLocationIds)
    {
        var distance = leftLocationIds.Select((t, i) => Math.Abs(t - rightLocationIds[i])).Sum();
        Console.WriteLine($"Answer to part one: {distance}");
    }
    
    private void AnswerPartTwo(List<int> leftLocationIds, List<int> rightLocationIds)
    {
        var distance = (from locationId in leftLocationIds
            let id = locationId
            let matches = rightLocationIds.Count(x => x == id)
            select locationId * matches).Sum();

        Console.WriteLine($"Answer to part two: {distance}");
    }
}