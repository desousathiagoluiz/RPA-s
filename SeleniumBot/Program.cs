using SeleniumBot;

class Program
{
    static void Main(string[] args)
    {
        // cria uma instancia da automação
        var web = new AutomationWeb();

        // executa o teste na web
        var text = web.TestWeb();

        // exibi o resultado no console
        Console.WriteLine(text);

        // fecha o navegador
        web.CloseBrowser();

        // mantem o console aberto
        Console.ReadLine();
    }
}