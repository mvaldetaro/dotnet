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
                        RepoUsers.findUsers();
                        break;
                    case 2:
                        RepoUsers.addUsers();
                        break;
                    case 3:
                        exitApp();
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
            while (option != 0);
        }

        private static void exitApp()
        {
            Console.WriteLine();
            Console.WriteLine("Mas já vai embora? \nPressione qualquer tecla para encerrar a aplicação.");
            Console.ReadKey();
            Environment.Exit(0);
        }
        
    }
}
