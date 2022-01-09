using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmourGames
{
    class Program
    {
        enum mainMenu {Login = 1, Cadastro = 2, Loja = 3, Sair = 4};//painel de opções principal.
        enum cadMenu {Cliente = 1, Dev = 2};//painel de opções do cliente.
        static void Main(string[] args)
        {

            Loja loja = new Loja();
            loja.IniciarLoja();

            
            mainMenu opMain;
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
                opMain = (mainMenu)op;
                
                switch (opMain)
                {
                    case mainMenu.Login:
                        break;
                    case mainMenu.Cadastro:
                        Console.WriteLine("Como você gostaria de se cadastrar ?\n1 - Player\n2 - Desenvolvedor de Jogos\nEscolha:");
                        int es = int.Parse(Console.ReadLine());
                        cadMenu esc = (cadMenu)es;

                        if (esc != cadMenu.Cliente && esc != cadMenu.Dev)
                        {
                            Console.WriteLine("Opção inexistente, redirecionando para o menu principal.");
                        }else{
                            string nome, login, senha;

                            Console.WriteLine("Digite seu nome: ");
                            nome = Console.ReadLine();
                            Console.WriteLine("Digite seu nome de usuário (você vai precisar dele para fazer login): ");
                            login = Console.ReadLine();
                            Console.WriteLine("Digite uma senha: ");
                            senha = Console.ReadLine();

                            if(esc == cadMenu.Cliente)
                            {
                                Cliente cl = new Cliente(nome, login, senha);
                                loja.adicionarCliente(cl);
                            }else
                            {
                                Dev dv = new Dev(nome, login, senha);
                                loja.adicionarDev(dv); 
                            }
                            Console.WriteLine("Novo Usuário cadastrado com sucesso.");
                        }



                        break;
                    case mainMenu.Loja:
                        foreach(Jogo jogo in loja.getJogo())
                        {
                            Console.WriteLine(jogo.getNome());
                        }
                        break;
                    default:
                        Console.WriteLine("Opção Invalida");
                        break;
                }
                   
            } while (opMain != mainMenu.Sair);

        }
    }
}
