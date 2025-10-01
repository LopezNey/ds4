internal class Program
{
    class ClaseBase()
    {
        public void test()
        {

        }
        public void masTests()
        {

        }
    }

    class ClaseHijo : ClaseBase
    {
        public new void masTests()
        {

        }
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Corrio la aplicacion");
    }
}