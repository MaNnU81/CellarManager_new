namespace CellarManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storage = new JsonStorage();
            var logic = new BusinessLogic(storage);
            var ui = new Tui(logic);
            ui.Start();
        }
    }
}
