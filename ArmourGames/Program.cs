using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArmourGames
{
    class Program
    {
        enum mainMenu {Login = 1, Cadastro = 2, Loja = 3, Sair = 0};//painel de opções principal.
        enum usrMenu {Cliente = 1, Dev = 2, Sair = 0};//painel de opções do Usuario tanto de login como de cadastro.
        static void Main(string[] args)
        {
            Loja loja = new Loja(); //instância do objeto Loja.
            loja.IniciarLoja(); // Inicialização do objeto loja que adiciona alguns jogos e desenvolvedores.
            mainMenu opMain; //Variavel enum do menu principal.
            do
            {
                Console.Clear();//limpa a exibição do console
                Console.WriteLine("Bem Vindo a Armour Games");
                Console.WriteLine("|=========MENU=========|"); //Menu principal da aplicação.
                Console.WriteLine("| Opção 1 - Login      |"); //Menu principal da aplicação.
                Console.WriteLine("| Opção 2 - Cadastre-se|"); //Menu principal da aplicação.
                Console.WriteLine("| Opção 3 - Ver Loja   |"); //Menu principal da aplicação.
                Console.WriteLine("| Opção 0 - Sair       |"); //Menu principal da aplicação.
                Console.WriteLine("|======================|"); //Menu principal da aplicação.
                Console.Write("Escolha: ");

                int op = int.Parse(Console.ReadLine()); //Escolha do usuario
                opMain = (mainMenu)op;                  //Escolha do usuario

                switch (opMain)//switch do menu principal
                {
                    case mainMenu.Login: //Opção de Login
                        Login();
                        break;

                    case mainMenu.Cadastro: //Opção de Cadastro
                        Console.Clear();
                        Cadastrar();
                        break;

                    case mainMenu.Loja:
                        foreach(Jogo jogo in loja.getJogo())
                        {
                            Console.WriteLine(jogo.getNome());
                        }
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção Invalida");
                        Thread.Sleep(2000);
                        break;
                }
                   
            } while (opMain != mainMenu.Sair);

            //Métodos da aplicação
            void Cadastrar()
            {
                usrMenu esc;
                do {
                    Console.WriteLine("|==========Tela de Cadastro==========|"); //Menu de Cadastro
                    Console.WriteLine("| 1 - Cadastro Como Cliente          |"); //Menu de Cadastro
                    Console.WriteLine("| 2 - Cadastro Como Desenvolvedor    |"); //Menu de Cadastro
                    Console.WriteLine("| 0 - Voltar Para o Menu Principal   |"); //Menu de Cadastro
                    Console.WriteLine("|====================================|"); //Menu de Cadastro
                    Console.Write("Escolha:");

                    int es = int.Parse(Console.ReadLine());
                    esc = (usrMenu)es;

                    if (esc != usrMenu.Cliente && esc != usrMenu.Dev)
                    {
                        Console.WriteLine("!!!Opção Inválida!!!");
                    }
                    else
                    {
                        string nome = null, login = null, senha = null;
                        if (esc == usrMenu.Dev || esc == usrMenu.Cliente)
                        {
                            Console.WriteLine("|========== Tela de Cadastro ==========|");
                            Console.Write("-> Digite seu nome: ");
                            nome = Console.ReadLine();
                            Console.Write("-> Digite seu nome de usuário: ");
                            login = Console.ReadLine();
                            Console.Write("-> Digite uma senha: ");
                            senha = Console.ReadLine();
                        }

                        switch (esc)
                        {
                            case usrMenu.Dev:
                                Dev dev = new Dev(nome, login, senha);
                                loja.adicionarDev(dev);
                                break;
                            case usrMenu.Cliente:
                                Cliente cliente = new Cliente(nome, login, senha);
                                loja.adicionarCliente(cliente);
                                break;
                        }

                        Console.Clear();
                        Console.WriteLine("Usuário cadastrado com sucesso");
                        Thread.Sleep(2000);
                    }

                } while (esc != usrMenu.Sair);

            }
            ArrayList Login()
            {
                Console.Clear();
                usrMenu esl;

                do
                {
                    ArrayList r = new ArrayList(); // Array que vai ser retornado ao fim da operação.
                    Console.WriteLine("|==========Tela de Login==========|"); //Menu de Login
                    Console.WriteLine("| 1 - Login Como Cliente          |"); //Menu de Login
                    Console.WriteLine("| 2 - Login Como Desenvolvedor    |"); //Menu de Login
                    Console.WriteLine("| 0 - Voltar Para o Menu Principal|"); //Menu de Login
                    Console.WriteLine("|=================================|"); //Menu de Login
                    Console.Write("Escolha:");

                    int es = int.Parse(Console.ReadLine());
                    esl = (usrMenu)es;

                    if(esl != usrMenu.Cliente && esl != usrMenu.Dev && esl != usrMenu.Sair)
                    {
                        Console.Clear();
                        Console.WriteLine("!!!Opção Inválida!!!");
                        Thread.Sleep(2000);
                        return Login();
                    }
                    else
                    {

                        string login = null, senha = null;
                        //resgatando login e senha
                        if (esl == usrMenu.Cliente || esl == usrMenu.Dev)
                        {
                            Console.Clear();
                            Console.WriteLine("|========== Tela de Login ==========|");
                            Console.Write("-> Digite seu Nome se Usuário: ");
                            login = Console.ReadLine();
                            Console.Write("-> Digite sua Senha: ");
                            senha = Console.ReadLine();
                        }
                        

                        switch (esl)
                        {
                            case usrMenu.Cliente:
                                foreach(Cliente cliente in loja.getCliente())
                                {
                                    if(cliente.getLogin() == login && cliente.getSenha() == senha)
                                    {
                                        r.Add(true);
                                        r.Add(0);
                                        r.Add(cliente);
                                        return r;
                                    }
                                }

                                r.Add(false);
                                return r;
                            case usrMenu.Dev:
                                foreach (Dev dev in loja.getDev())
                                {
                                    if (dev.getLogin() == login && dev.getSenha() == senha)
                                    {
                                        r.Add(true);
                                        r.Add(1);
                                        r.Add(dev);
                                        return r;
                                    }
                                }

                                r.Add(false);
                                return r;
                            case usrMenu.Sair:
                               
                                r.Add(false);
                                return r;
                        }
                        r.Add(false);
                        return r;
                    }



                } while (esl != usrMenu.Sair);
            }
            void DevPanel(Dev dev)
            {
                Console.WriteLine($"Olá, {dev.getNome()}    Saldo:R${dev.getSaldo()}");
                Console.WriteLine("|======Painel de Desenvolvedor======|"); //Menu de Login
                Console.WriteLine("| 1 - Login Como Cliente          |"); //Menu de Login
                Console.WriteLine("| 2 - Login Como Desenvolvedor    |"); //Menu de Login
                Console.WriteLine("| 0 - Voltar Para o Menu Principal|"); //Menu de Login
                Console.WriteLine("|=================================|"); //Menu de Login
                Console.Write("Escolha:");
            }
        }
    }
}
