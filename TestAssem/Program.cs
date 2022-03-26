using static System.Console;

namespace TestAssem
{
    public class Program
    {
        public static void Main(string[] args) { WriteLine("Executed from EP"); }

        public static string Print(string input) { return $"Executed from Print method - {input}"; } 
    }
}
