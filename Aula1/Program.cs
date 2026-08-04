internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Bem-Vindo ao seu primeiro programa");
        Console.WriteLine("Me informe seu nome");
        string nome = Console.ReadLine();
        Console.Clear();
        Console.WriteLine($"Bem-Vindo {nome}, é um prazer conhecer você. Vamos aprender muito a partir de agora!");
    }
}