
namespace Menu1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DBChecker.InitialiseIfnotExists();
            Menu.ConsoleMenu1(args);
        }
    }
}
