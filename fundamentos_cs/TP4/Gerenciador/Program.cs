using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NiverRegister;

namespace Gerenciador
{
    class Program
    {
        public static RepoUsers repositorio = new RepoUsers();

        static void Main()
        {
            int option;
            

            do
            {
                Console.WriteLine("Gerenciador de Aniversários");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Selecione uma das opções abaixo:");
                Console.WriteLine("[1] Pesquisar pessoas");
                Console.WriteLine("[2] Adicionar nova pessoa");
                Console.WriteLine("[3] Sair");

                option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Search();
                        break;
                    case 2:
                        Insert();
                        break;
                    case 3:
                        exit();
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
            while (option != 0);
        }

        private static void Search()
        {
            

            if (repositorio.Lista.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Gerenciador de Aniversários");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("----- Nenhuma pessoa cadastrada -----");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Pressione ENTER para retornar ao menu");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Gerenciador de Aniversários");
                Console.WriteLine("-------------------------------------");

                Console.WriteLine("Digite o nome, ou parte do nome, da pessoa que deseja encontrar:");
                var query = Console.ReadLine();

                Console.WriteLine("Selecione uma das opções abaixo para visualizar os dados de uma das pessoas encontradas:");

                List<User> filterList = repositorio.FindUsers(query);

                var index = Int32.Parse(Console.ReadLine());

                Console.WriteLine($"Nome Completo: {filterList[index].nome} {filterList[index].sobrenome}");
                Console.WriteLine("Data de Aniversário: {0}", filterList[index].dtAniversario);

                int total = Calculator.DiasRestantesAniversario(filterList[index].dtAniversario);

                Console.WriteLine($"Faltam {total} dias para esse aniversário.");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Pressione ENTER para retornar ao menu");
            }
        }

        private static void Insert()
        {
            Console.Clear();
            int confirm;
            Console.WriteLine("Gerenciador de Aniversários");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Digite o NOME da pessoa que deseja adicionar:");
            var name = Console.ReadLine();
            Console.WriteLine("Digite o SOBRENOME da pessoa que deseja adicionar:");
            var lastname = Console.ReadLine();
            Console.WriteLine("Digite a DATA DE NASCIMENTO no fomrato dd/MM/yyyy:");
            var birthday = Console.ReadLine();

            User newUser = new User(name, lastname, DateTime.Parse(birthday));

            Console.WriteLine("Os dados estão corretos?");
            Console.WriteLine($"Nome: {newUser.nome} {newUser.sobrenome}");
            Console.WriteLine($"Data de Aniversário: {newUser.dtAniversario}");
            Console.WriteLine("[1] Sim");
            Console.WriteLine("[2] Não");

            confirm = Int32.Parse(Console.ReadLine());

            if (confirm == 1)
            {
                repositorio.AddUsers(newUser);
                Console.WriteLine("Dados adicionados com sucesso!");
                Console.WriteLine("Pressione ENTER para continuar");
            }
        }

        private static void exit()
        {
            Console.WriteLine();
            Console.WriteLine("Mas já vai embora? \nPressione qualquer tecla para encerrar a aplicação.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
