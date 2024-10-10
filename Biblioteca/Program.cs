using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        int ordem = 0;
        bool continuar = true;
        string senha = "12345";
        List<string> catalogoTitulos = new List<string>();
        List<int> quantidadelivro = new List<int>();

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
                    MenuUsuario(ref catalogoTitulos, ordem, quantidadelivro);
                    break;

                case 2:
                    MenuAdministrador(ref catalogoTitulos, senha);
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

    static void MenuUsuario(ref List<string> catalogoTitulos, int ordem, List <int> quantidadelivro)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Usuário:");
            Console.WriteLine("1 - Consultar Catálogo");
             Console.WriteLine("2. Pegar Livro");
            Console.WriteLine("3. Devolver Livro");
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
                    foreach (string livro in catalogoTitulos)
                    {
                        Console.WriteLine(livro);
                    }
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                    case 2:
                    Console.WriteLine("Qual Livro deseja:");
                    foreach(string livro in catalogoTitulos )
                    {
                        Console.WriteLine($"{ordem + 1} - "+(livro));
                        ordem++;
                    }
                    Console.WriteLine("Digite o numero do livro que deseja");
                    
                     if (!int.TryParse(Console.ReadLine(), out int escolha))
        {
            Console.WriteLine("Escolha Invalida");
        }
        catalogoTitulos.RemoveAt(escolha - 1);
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

    static void MenuAdministrador(ref List<string> catalogoTitulos, string senha)
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
                        CadastrarLivro(ref catalogoTitulos ,quantidadelivro);
                        break;

                    case 2:
                        Console.WriteLine("Catálogo de Livros:");
                        foreach (string livro in catalogoTitulos)
                        {
                            Console.WriteLine(livro);
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

    static void CadastrarLivro(ref List<string> catalogoTitulos, List<int> quantidadelivro)
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
            catalogoTitulos.Add($"{titulo} - {autor} - ({genero}) ");
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
}

