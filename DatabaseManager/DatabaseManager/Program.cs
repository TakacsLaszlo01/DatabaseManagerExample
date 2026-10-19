using DatabaseLib;
namespace DatabaseManager;
internal class Program
{
    static void Main(string[] args)
    {
        PerformerManager manager = new();
        foreach (Performer performer in manager.ListAll())
        {
            Console.WriteLine(performer.Name);
        }
    }
}
