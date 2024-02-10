public static class AutenticaçãoSimples
{
    public static void Executar()
    {
        var Valido = false;
        string cpf=string.Empty, senha=string.Empty;
        while (!Valido)
        {
            Console.WriteLine("Autenticar usuário");
            Console.WriteLine("Digite o CPF:");
            cpf = Console.ReadLine();
            Console.WriteLine("Digite a senha:");
            senha = Console.ReadLine();

            if (!string.IsNullOrEmpty(cpf) && !string.IsNullOrEmpty(senha))
                Valido = true;
            else
            {
                Console.WriteLine("CPF ou Senha não pode ser vazio");
                Console.WriteLine("Digite [ENTER] para reiniciar");
                Console.ReadKey();
                Console.Clear();
            }

        }

        //MOCK = MIMICO
        var usuarios = new Dictionary<string, string>
        {
            { "00578522195", "admin" },
            { "04621948253", "123456" },
            { "01093604190", "123123" }
        };      

        foreach (var usuario in usuarios)
        {
            if (usuario.Key == cpf && usuario.Value == senha)
            {
                Console.WriteLine("Usuário autenticado");
                return;
            }
        }

        Console.WriteLine("Usuário não autenticado");
    }
}