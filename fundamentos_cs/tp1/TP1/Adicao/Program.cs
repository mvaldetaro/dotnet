using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adicao
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Essa aplicação calcula a adição de dois números!");

            Console.WriteLine("Digite o primeiro número");
            var n1 = Console.ReadLine();
            Console.WriteLine("Digite o segundo número");
            var n2 = Console.ReadLine();

            int num1Val = Int32.Parse(n1);
            int num2Val = Int32.Parse(n2);

            Console.Write($"O resultado da adição dos números {n1} e {n2} é: ");
            Console.WriteLine(num1Val + num2Val);

            Console.WriteLine("Pressione qualquer tecla para encerrar.");
            Console.ReadKey();
        }
    }
}
