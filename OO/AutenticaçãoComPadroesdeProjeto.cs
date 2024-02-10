public static class AutenticaçãoComPadroesdeProjeto
{
    //FRONT END
    public static void Executar()
    {
        Console.WriteLine("Autenticar usuário");
        Console.WriteLine("Digite o CPF:");
        var cpf = Console.ReadLine();
        Console.WriteLine("Digite a senha:");
        var senha = Console.ReadLine();

        if (string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(senha))
        {
            Console.WriteLine("CPF ou Senha não pode ser vazio");
            return;
        }

        var resultado = new AutenticarComandoHandler().Handle(
            new AutenticarComando
            {
                CPF = cpf,
                Senha = senha
            });

        Console.WriteLine(resultado);

    }

    //COMMAND PATTERN
    public record AutenticarComando
    {
        public string CPF { get; init; }
        public string Senha { get; init; }
    }

    //ENTITY PATTERN
    public class Usuario
    {
        public virtual string Nome { get; init; }
        public string CPF { get; init; }
        public string Senha { get; init; }
        public virtual bool Autenticado { get; init; } = true;

    }

    //COMMAND HANDLER PATTERN
    public class AutenticarComandoHandler
    {
        UsuarioRepositorio _repositorio;
        public AutenticarComandoHandler()
        {
            _repositorio = new UsuarioRepositorio();
        }
        public string Handle(AutenticarComando comando)
        {
            var usuario = _repositorio.Autenticar(comando.CPF, comando.Senha);

            return usuario.Autenticado ? "Usuário autenticado" : "Usuário não autenticado";
        }
    }

    //NULL OBJECT PATTERN
    public class UsuárioNãoEncontrato : Usuario
    {
        public override string Nome => "Usuário não encontrado";
        public override bool Autenticado => false;

    }

    //REPOSITORY PATTERN
    public class UsuarioRepositorio
    {
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>
        {
            new Usuario { Nome = "Administrador", CPF = "00578522195", Senha = "admin" },
            new Usuario { Nome = "Usuário", CPF = "04621948253", Senha = "123456" },
            new Usuario { Nome = "Usuário 2", CPF = "01093604190", Senha = "123123" }
        };
        public Usuario Autenticar(string cpf, string senha)
        {
            return Usuarios.FirstOrDefault(u => u.CPF == cpf && u.Senha == senha) ?? new UsuárioNãoEncontrato();
        }
    }
}