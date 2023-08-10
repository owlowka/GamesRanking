using System.Runtime.CompilerServices;

namespace GamesRanking.UserCommunication;

public static class PrintingExtensions
{
    public static void PrintList<T>(this IEnumerable<T> items)
    {
        foreach (T item in items)
        {
            Console.WriteLine(item);
        }
    }
    public static void PrintItem<T>(this T item)
    {
        Console.WriteLine(item);
    }

    public static void PrintMethodName([CallerMemberName] string name = null)
    {
        Console.WriteLine();
        Console.WriteLine(name);
    }
}
