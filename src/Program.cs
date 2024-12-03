using advent_of_code_2024.Interfaces;

var solutions = new ISolution[]
{
    new Day1.Solution(),
    new Day2.Solution()
};

foreach (var solution in solutions)
{
    solution.Solve();
}