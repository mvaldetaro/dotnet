using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiverRegister
{
    /// <summary>
    /// Classe que representa a pessoa
    /// </summary>
    public class User
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public DateTime dtAniversario { get; set; }


        public User(string strNome, string strSobrenome, DateTime datAniversario)
        {
            nome = strNome;
            sobrenome = strSobrenome;
            dtAniversario = datAniversario;
        }
    }

    public class RepoUsers
    {
        private static List<User> lista = new List<User>();

        private static List<User> BuildList()
        {
            return lista;
        }

        public static void addUsers()
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
                lista.Add(newUser);
                Console.WriteLine("Dados adicionados com sucesso!");
                Console.WriteLine("Pressione ENTER para continuar");
            }
            else
            {
                addUsers();
            }
        }

        public static void findUsers()
        {
            int index;
            List<User> filterList = new List<User>();

            List<User> users = BuildList();

            if (lista.Count == 0)
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

                var result = from user in users where user.nome.Contains(query) orderby user.nome select user;

                int i = 0;

                foreach (User user in result)
                {
                    Console.WriteLine($"[{i}] {user.nome} {user.sobrenome}");
                    filterList.Add(user);
                    i++;
                }

                index = Int32.Parse(Console.ReadLine());

                Console.WriteLine($"Nome Completo: {filterList[index].nome} {filterList[index].sobrenome}");
                Console.WriteLine("Data de Aniversário: {0}", filterList[index].dtAniversario);

                int dia = filterList[index].dtAniversario.Day;
                int mes = filterList[index].dtAniversario.Month;
                int total = Calculator.diasRestantesAniversario(dia, mes);

                Console.WriteLine($"Faltam {total} dias para esse aniversário.");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Pressione ENTER para retornar ao menu");
            }
        }
    }

    public class Calculator
    {
        public static int diasRestantesAniversario(int dia, int mes)
        {
            int anoAtual = DateTime.Today.Year;

            var dataInicial = DateTime.Today;
            var dataFinal = $"{dia}/{mes}/{anoAtual}";

            return (DateTime.Parse(dataFinal).Subtract(dataInicial)).Days;
        }
    }
}
