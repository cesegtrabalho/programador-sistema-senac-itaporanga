internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    private static void Questao01()
    {
        string nome;
        Console.WriteLine("Informe o seu nome");
        nome = Console.ReadLine();
        Console.WriteLine($"Olá {nome}! Seja bem-vindo ao DotNet!!!");
    }

    private static void Questao02()
    {
        int idade;
        Console.WriteLine("Informe a sua idade");
        idade = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Você tem {idade} anos.")
    }

    private static void Questao3()
    {
        string cidade;
        Console.WriteLine("Informe a cidade que você mora");
        cidade = Console.ReadLine();
        Console.WriteLine($"Você mora em {cidade}");
    }

    private static void Questao4()
    {
        decimal altura;
        Console.WriteLine("Informe a altura");
        altura = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine($"A altura informada foi de {altura} metros");
    }

    private static void Questao5()
    {
        decimal peso;
        Console.WriteLine("Informe seu peso");
        peso = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine($"Seu peso é {peso} quilos.");
    }

    private static void Questao6()
    {
        string nome;
        Console.WriteLine("Informe o seu nome completo");
        nome = Console.ReadLine();
        Console.WriteLine($"Seu nome completo é {nome}");
    }

    private static void Questao7()
    {
        string serieAno;
        Console.WriteLine("Informe qual a sua série/ano");
        serieAno = Console.ReadLine();
        Console.WriteLine($"A sua série/ano é {serieAno}");
    }   
}