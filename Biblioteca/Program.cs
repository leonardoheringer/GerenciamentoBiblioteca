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
       catalogoTitulos.Add("{Harry Potter} - {J. K. Rowling} - ({Fantasia})");
            quantidadelivro.Add(5);
            catalogoTitulos.Add("{Pequeno Principe} - {Antoine} - ({Aventura})");
            quantidadelivro.Add(5);

        while (continuar)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
             
            Console.Clear();
            Console.WriteLine($"{DateTime.Now}");
            Console.WriteLine($"----- BIBLIOTECA -----");

            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Usuário");
            Console.WriteLine("2 - Administrador");
            Console.WriteLine("3 - Sair");
            Console.ResetColor();

            if (!int.TryParse(Console.ReadLine(), out int opcao))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Valor inválido! Tente novamente.");
                Thread.Sleep(1500);
                Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Thread.Sleep(1500);
                    Console.ResetColor();
                    break;
            }
        }
    }

    static void MenuUsuario(ref List<string> catalogoTitulos, List<int> quantidadelivro, List<string> emprestimoTitulos, List<int> quantidadeEmprestada)
    {
        while (true)
        { int emprestimo = 0;
        Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Menu Usuário:");
            Console.WriteLine("1 - Consultar Catálogo");
            Console.WriteLine("2 - Pegar Livro");
            Console.WriteLine("3 - Devolver Livro");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha uma opção: ");
            Console.ResetColor();

            if (!int.TryParse(Console.ReadLine(), out int opcaoUsuario))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Valor inválido! Tente novamente.");
                Thread.Sleep(1500);
                Console.ResetColor();
                continue;
            }

            switch (opcaoUsuario)
            {
                case 1:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Catálogo de Livros:");

                    for (int i = 0; i < catalogoTitulos.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {catalogoTitulos[i]} (Quantidade: {quantidadelivro[i]})");
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.ResetColor();
                    break;

                case 2:
                    EmprestarLivro(ref catalogoTitulos, ref quantidadelivro, ref emprestimoTitulos, ref emprestimo, ref quantidadeEmprestada);
                    break;

case 3:
DevolverLivro(ref catalogoTitulos, ref  quantidadelivro, ref  emprestimoTitulos, ref  quantidadeEmprestada);
break;
                case 4:
                    return;

                default:
                Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Thread.Sleep(1500);
                    Console.ResetColor();
                    break;
            }
        }
    }

    static void MenuAdministrador(ref List<string> catalogoTitulos, ref List<int> quantidadelivro, string senha)
    {
        int tentativas = 0;

        while (tentativas < 3)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Write("-----LOGIN USUARIO----- ");
            Console.Write("\nDigite a senha: ");
            Console.ResetColor();
            string tsenha = Console.ReadLine();

            if (tsenha != senha)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Erro! Senha digitada não confere.");
                tentativas++;
                Thread.Sleep(1500);
                Console.ResetColor();
                continue;
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("Menu Administrador:");
                Console.WriteLine("1 - Cadastrar Livro");
                Console.WriteLine("2 - Consultar Catálogo");
                Console.WriteLine("3 - Sair");
                Console.Write("Escolha uma opção: ");
                Console.ResetColor();

                if (!int.TryParse(Console.ReadLine(), out int opcaoAdmin))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Valor inválido! Tente novamente.");
                    Thread.Sleep(1500);
                    Console.ResetColor();
                    continue;
                }

                switch (opcaoAdmin)
                {
                    case 1:
                        CadastrarLivro(ref catalogoTitulos, ref quantidadelivro);
                        break;

                    case 2:
                     Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Catálogo de Livros:");
                        for (int i = 0; i < catalogoTitulos.Count; i++)
                        {
                            Console.WriteLine($"{catalogoTitulos[i]} (Quantidade: {quantidadelivro[i]})");
                        }
                          Console.ResetColor();
                        
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                          Console.ResetColor();
                        break;

                    case 3:
                        return;

                    default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        Thread.Sleep(1500);
                          Console.ResetColor();
                        break;
                }
            }
        }
Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("Número máximo de tentativas atingido.");
        Thread.Sleep(1500);
          Console.ResetColor();
    }

    static void CadastrarLivro(ref List<string> catalogoTitulos, ref List<int> quantidadelivro)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
        Console.Write("Título: ");
        string titulo = Console.ReadLine();

        Console.Write("Autor: ");
        string autor = Console.ReadLine();

        Console.Write("Gênero: ");
        string genero = Console.ReadLine();

        Console.Write("Quantidade: ");
          Console.ResetColor();
        if (int.TryParse(Console.ReadLine(), out int quantidade) && quantidade > 0)
        {
            catalogoTitulos.Add($"{titulo} - {autor} - ({genero})");
            quantidadelivro.Add(quantidade);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Livro cadastrado com sucesso.");
              Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Quantidade inválida. O livro não foi cadastrado.");
              Console.ResetColor();
        }
        Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
          Console.ResetColor();
    }

static void EmprestarLivro(ref List<string> catalogoTitulos, ref List<int> quantidadelivro, ref List<string> emprestimoTitulos, ref int emprestimo, ref List<int> quantidadeEmprestada)
{
    while (true) // Loop para permitir várias tentativas de empréstimo
    {
        if (emprestimo < 4) // Limite de empréstimos
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < catalogoTitulos.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {catalogoTitulos[i]} (Quantidade: {quantidadelivro[i]})");
            }
              Console.ResetColor();
  Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Qual o número do livro deseja pegar emprestado?");
            if (!int.TryParse(Console.ReadLine(), out int escolhalivro) || escolhalivro < 1 || escolhalivro > catalogoTitulos.Count)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Opção Inválida. Tente Novamente!");
                Thread.Sleep(1500); 
                  Console.ResetColor(); // Adiciona um pequeno delay para o usuário ler a mensagem
                continue; // Volta para o início do loop
            }

            // Lógica para pegar o livro emprestado
            if (quantidadelivro[escolhalivro - 1] > 0)
            {
                
                   // Verifica se o livro já foi emprestado
                int index = emprestimoTitulos.IndexOf(catalogoTitulos[escolhalivro - 1]);
                
                if (index != -1) // Livro já emprestado
                {
                     quantidadelivro[escolhalivro - 1]--;
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
                Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Desculpe, este livro não está disponível no momento.");
                  Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
             Console.WriteLine("Livros emprestados:");
            for (int i = 0; i < emprestimoTitulos.Count; i++)
            {
                
                Console.WriteLine($"Você pegou: {i + 1} - {emprestimoTitulos[i]} (Quantidade: {quantidadeEmprestada[i]})");
                 
            }
             Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Você já atingiu o limite de 4 livros emprestados.");
              Console.ResetColor();
            break; // Sai do loop se o limite for atingido
        }
Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
          Console.ResetColor();
        break; // Sai do loop após uma tentativa válida
    }
}
static void DevolverLivro(ref List<string> catalogoTitulos, ref List<int> quantidadelivro, ref List<string> emprestimoTitulos, ref List<int> quantidadeEmprestada)
{
    if (emprestimoTitulos.Count == 0)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("Você não possui livros emprestados.");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
          Console.ResetColor();
        return;
    }
Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
    Console.WriteLine("Livros emprestados:");
      Console.ResetColor();
    for (int i = 0; i < emprestimoTitulos.Count; i++)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine($"{i + 1} - {emprestimoTitulos[i]} (Quantidade: {quantidadeEmprestada[i]})");
    }
Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
    Console.WriteLine("Qual o número do livro que você deseja devolver?");
      Console.ResetColor();
    if (!int.TryParse(Console.ReadLine(), out int escolhaDevolucao) || escolhaDevolucao < 1 || escolhaDevolucao > emprestimoTitulos.Count)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("Opção inválida. Tente novamente.");
        Thread.Sleep(1500);
          Console.ResetColor();
        return;
    }

    // Lógica para devolver o livro
    int index = escolhaDevolucao - 1;
    string tituloDevolvido = emprestimoTitulos[index];

    // Aumenta a quantidade na biblioteca
    int catalogoIndex = catalogoTitulos.IndexOf(tituloDevolvido);
    quantidadelivro[catalogoIndex]++;
    
    // Reduz a quantidade emprestada
    quantidadeEmprestada[index]--;

    if (quantidadeEmprestada[index] == 0)
    {
        // Se a quantidade emprestada chegou a zero, remove o livro da lista de emprestados
        emprestimoTitulos.RemoveAt(index);
        quantidadeEmprestada.RemoveAt(index);
    }
Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
    Console.WriteLine($"Você devolveu o livro: {tituloDevolvido} com sucesso.");
    Console.WriteLine("Pressione qualquer tecla para continuar...");
    Console.ReadKey();
      Console.ResetColor();
}

}