using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmourGames
{
    class Program
    {
        enum mainOP {Login = 1, Cadastro = 2, Loja = 3, Sair = 4};//painel de opções principal.
        enum clientOP {Biblioteca = 1 }//painel de opções do cliente.
        static void Main(string[] args)
        {

            Loja loja = new Loja();

            mainOP opMain;
            do
            {
                Console.WriteLine("Bem Vindo a Armour Games");
                Console.WriteLine("========MENU========\n" +
                    "1 - Login\n" +
                    "2 - Cadastre-se\n" +
                    "3 - Loja\n" +
                    "4 - Sair\n" +
                    "Opção:");
                int op = int.Parse(Console.ReadLine());
                opMain = (mainOP)op;
                
                switch (opMain)
                {
                    case mainOP.Login:
                        break;
                    case mainOP.Cadastro:
                        break;
                    case mainOP.Loja:
                        break;
                    default:
                        Console.WriteLine("Opção Invalida");
                        break;
                }
                   
            } while (opMain != mainOP.Sair);

        }
    }
}
