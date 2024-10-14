

class Program
{
    static void Main()
    {
        bool continuar = true;
        string senha = "12345";
        List<string> catalogoTitulos = new List<string>();
        List<int> quantidadelivro = new List<int>();
        List<string> emprestimoTitulos = new List<string>();
        List<int> quantidadeEmprestada = new List<int>();
       

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine($"{DateTime.Now}");
            Console.WriteLine($"----- BIBLIOTECA -----");

            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Usuário");
            Console.WriteLine("2 - Administrador");
            Console.WriteLine("3 - Sair");

            if (!int.TryParse(Console.ReadLine(), out int opcao))
            {
                Console.WriteLine("Valor inválido! Tente novamente.");
                Thread.Sleep(1500);
                continue;
            }

            switch (opcao)
            {
                case 1:
                    MenuUsuario(ref catalogoTitulos, quantidadelivro, emprestimoTitulos, quantidadeEmprestada);
                    break;

                case 2:
                    MenuAdministrador(ref catalogoTitulos, ref quantidadelivro, senha);
                    break;

                case 3:
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }

    static void MenuUsuario(ref List<string> catalogoTitulos, List<int> quantidadelivro, List<string> emprestimoTitulos, List<int> quantidadeEmprestada)
    {
        while (true)
        { int emprestimo = 0;
            Console.Clear();
            Console.WriteLine("Menu Usuário:");
            Console.WriteLine("1 - Consultar Catálogo");
            Console.WriteLine("2 - Pegar Livro");
            Console.WriteLine("3 - Devolver Livro");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out int opcaoUsuario))
            {
                Console.WriteLine("Valor inválido! Tente novamente.");
                Thread.Sleep(1500);
                continue;
            }

            switch (opcaoUsuario)
            {
                case 1:
                    Console.WriteLine("Catálogo de Livros:");
                    for (int i = 0; i < catalogoTitulos.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {catalogoTitulos[i]} (Quantidade: {quantidadelivro[i]})");
                    }
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 2:
                    EmprestarLivro(ref catalogoTitulos, ref quantidadelivro, ref emprestimoTitulos, ref emprestimo, ref quantidadeEmprestada);
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }

    static void MenuAdministrador(ref List<string> catalogoTitulos, ref List<int> quantidadelivro, string senha)
    {
        int tentativas = 0;

        while (tentativas < 3)
        {
            Console.Clear();
            Console.Write("Digite a senha: ");
            string tsenha = Console.ReadLine();

            if (tsenha != senha)
            {
                Console.WriteLine("Erro! Senha digitada não confere.");
                tentativas++;
                Thread.Sleep(1500);
                continue;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu Administrador:");
                Console.WriteLine("1 - Cadastrar Livro");
                Console.WriteLine("2 - Consultar Catálogo");
                Console.WriteLine("3 - Sair");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out int opcaoAdmin))
                {
                    Console.WriteLine("Valor inválido! Tente novamente.");
                    Thread.Sleep(1500);
                    continue;
                }

                switch (opcaoAdmin)
                {
                    case 1:
                        CadastrarLivro(ref catalogoTitulos, ref quantidadelivro);
                        break;

                    case 2:
                        Console.WriteLine("Catálogo de Livros:");
                        for (int i = 0; i < catalogoTitulos.Count; i++)
                        {
                            Console.WriteLine($"{catalogoTitulos[i]} (Quantidade: {quantidadelivro[i]})");
                        }
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 3:
                        return;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }

        Console.WriteLine("Número máximo de tentativas atingido.");
        Thread.Sleep(1500);
    }

    static void CadastrarLivro(ref List<string> catalogoTitulos, ref List<int> quantidadelivro)
    {
        Console.Write("Título: ");
        string titulo = Console.ReadLine();

        Console.Write("Autor: ");
        string autor = Console.ReadLine();

        Console.Write("Gênero: ");
        string genero = Console.ReadLine();

        Console.Write("Quantidade: ");
        if (int.TryParse(Console.ReadLine(), out int quantidade) && quantidade > 0)
        {
            catalogoTitulos.Add($"{titulo} - {autor} - ({genero})");
            quantidadelivro.Add(quantidade);
            Console.WriteLine("Livro cadastrado com sucesso.");
        }
        else
        {
            Console.WriteLine("Quantidade inválida. O livro não foi cadastrado.");
        }
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

static void EmprestarLivro(ref List<string> catalogoTitulos, ref List<int> quantidadelivro, ref List<string> emprestimoTitulos, ref int emprestimo, ref List<int> quantidadeEmprestada)
{
    while (true) // Loop para permitir várias tentativas de empréstimo
    {
        if (emprestimo < 4) // Limite de empréstimos
        {
            for (int i = 0; i < catalogoTitulos.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {catalogoTitulos[i]} (Quantidade: {quantidadelivro[i]})");
            }

            Console.WriteLine("Qual o número do livro deseja pegar emprestado?");
            if (!int.TryParse(Console.ReadLine(), out int escolhalivro) || escolhalivro < 1 || escolhalivro > catalogoTitulos.Count)
            {
                Console.WriteLine("Opção Inválida. Tente Novamente!");
                Thread.Sleep(1500); // Adiciona um pequeno delay para o usuário ler a mensagem
                continue; // Volta para o início do loop
            }

            // Lógica para pegar o livro emprestado
            if (quantidadelivro[escolhalivro - 1] > 0)
            {
                
                   // Verifica se o livro já foi emprestado
                int index = emprestimoTitulos.IndexOf(catalogoTitulos[escolhalivro - 1]);
                
                if (index != -1) // Livro já emprestado
                {
                    quantidadeEmprestada[index]++; // Incrementa a quantidade emprestada
                }
                else // Livro não emprestado
                {
                    quantidadelivro[escolhalivro - 1]--; // Reduz a quantidade na biblioteca
                    
                    emprestimoTitulos.Add(catalogoTitulos[escolhalivro - 1]);
                    quantidadeEmprestada.Add(1); // Adiciona novo empréstimo
                }
            }
            else
            {
                Console.WriteLine("Desculpe, este livro não está disponível no momento.");
            }
             Console.WriteLine("Livros emprestados:");
            for (int i = 0; i < emprestimoTitulos.Count; i++)
            {
                Console.WriteLine($"Você pegou: {i + 1} - {emprestimoTitulos[i]} (Quantidade: {quantidadeEmprestada[i]})");
            }
        }
        else
        {
            Console.WriteLine("Você já atingiu o limite de 4 livros emprestados.");
            break; // Sai do loop se o limite for atingido
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
        break; // Sai do loop após uma tentativa válida
    }
}

}