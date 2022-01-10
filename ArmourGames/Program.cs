using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
        enum devPanel {GerirJogos = 1, AcessarLoja = 2, ChecarTransacoes = 3, SacarSaldo = 4, GerirConta = 5, Logout = 0};//painel de opções do Desenvolvedor.
        enum clientPanel {VerBiblioteca = 1, AcessarLoja = 2, ChecarTransacoes = 3, AdicionarFundos = 4, GerirConta = 5, Logout = 0};//painel de opçoes do Cliente.
        enum gestaoConta { AlterarNome = 1, AlterarLogin = 2, AlterarSenha = 3, ExcluirConta = 4, Sair = 0};//Opções de gestão do Usuario
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

                int op = int.Parse(Console.ReadLine()); //Escolha do Dev
                opMain = (mainMenu)op;                  //Escolha do Dev

                switch (opMain)//switch do menu principal
                {
                    case mainMenu.Login: //Opção de Login
                        bool pass = false;
                        int t = 0;
                        Object usuario = Login(ref pass, ref t);
                        if (pass)
                        {
                            pass = false;
                            switch (t)
                            {
                                case 0:
                                    ClientPanel((Cliente)usuario);
                                    break;
                                case 1:
                                    DevPanel((Dev)usuario);
                                    break;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("!!!Operação Mal Sucedida!!!");
                            Thread.Sleep(2000);
                        }
                        break;

                    case mainMenu.Cadastro: //Opção de Cadastro
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
                    Console.Clear();
                    Console.WriteLine("|==========Tela de Cadastro==========|"); //Menu de Cadastro
                    Console.WriteLine("| 1 - Cadastro Como Cliente          |"); //Menu de Cadastro
                    Console.WriteLine("| 2 - Cadastro Como Desenvolvedor    |"); //Menu de Cadastro
                    Console.WriteLine("| 0 - Voltar Para o Menu Principal   |"); //Menu de Cadastro
                    Console.WriteLine("|====================================|"); //Menu de Cadastro
                    Console.Write("Escolha:");

                    int es = int.Parse(Console.ReadLine());
                    esc = (usrMenu)es;

                    if ((int)esc > 3)
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

                        Console.Clear();
                        Console.WriteLine("Usuário cadastrado com sucesso");
                        Thread.Sleep(2000);
                        switch (esc)
                        {
                            case usrMenu.Dev:
                                Dev dev = new Dev(nome, login, senha);
                                loja.adicionarDev(dev);
                                DevPanel(dev);
                                break;
                            case usrMenu.Cliente:
                                Cliente cliente = new Cliente(nome, login, senha);
                                loja.adicionarCliente(cliente);
                                ClientPanel(cliente);
                                break;
                        }
                    }

                } while (esc != usrMenu.Sair);

            }
            Object Login(ref bool pass, ref int t)
            {
                Console.Clear();
                usrMenu esl;

                do
                {
                    Console.WriteLine("|==========Tela de Login==========|"); //Menu de Login
                    Console.WriteLine("| 1 - Login Como Cliente          |"); //Menu de Login
                    Console.WriteLine("| 2 - Login Como Desenvolvedor    |"); //Menu de Login
                    Console.WriteLine("| 0 - Voltar Para o Menu Principal|"); //Menu de Login
                    Console.WriteLine("|=================================|"); //Menu de Login
                    Console.Write("Escolha:");

                    int es = int.Parse(Console.ReadLine());
                    esl = (usrMenu)es;

                    if((int)esl > 3)
                    {
                        Console.Clear();
                        Console.WriteLine("!!!Opção Inválida!!!");
                        Thread.Sleep(2000);
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
                                        pass = true;
                                        t = 0;
                                        return cliente;
                                    }
                                }
                                return null;
                            case usrMenu.Dev:
                                foreach (Dev dev in loja.getDev())
                                {
                                    if (dev.getLogin() == login && dev.getSenha() == senha)
                                    {
                                        pass = true;
                                        t = 1;
                                        return dev;
                                    }
                                }
                                return null;
                            case usrMenu.Sair:
                                return null; ;
                        }
                        return null;
                    }
                    return null;


                } while (esl != usrMenu.Sair);
            }
            void DevPanel(Dev dev)
            {
                
                devPanel esdv;
                do
                {
                    Console.Clear();
                    Console.WriteLine($"Olá, {dev.getNome()}    Saldo:R${dev.getSaldo()}");
                    Console.WriteLine("|======Painel de Desenvolvedor======|"); //Painel de Desenvolvedor
                    Console.WriteLine("| 1 - Gerir Seus Jogos              |"); //Painel de Desenvolvedor
                    Console.WriteLine("| 2 - Checar Transações             |"); //Painel de Desenvolvedor
                    Console.WriteLine("| 3 - Sacar Saldo                   |"); //Painel de Desenvolvedor
                    Console.WriteLine("| 4 - Gerir Conta                   |"); //Painel de Desenvolvedor
                    Console.WriteLine("| 0 - LogOut                        |"); //Painel de Desenvolvedor
                    Console.WriteLine("|===================================|"); //Painel de Desenvolvedor
                    Console.Write("Escolha:");

                    int es = int.Parse(Console.ReadLine());
                    esdv = (devPanel)es;

                    if ((int)esdv > 5 )
                    {
                        Console.Clear();
                        Console.WriteLine("!!!Opção Inválida!!!");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        switch (esdv)
                        {
                            case devPanel.GerirJogos:
                                break;
                        }
                    }


                } while (esdv != devPanel.Logout);
            }
            void ClientPanel(Cliente client)
            {
                clientPanel escl = (clientPanel) 20;
                do
                {
                    if(escl != clientPanel.Logout)
                    {
                        Console.Clear();//limpa a exibição do console
                        Console.WriteLine($"Olá, {client.getNome()}    Saldo: {client.getSaldo().ToString("C", CultureInfo.CurrentCulture)}");
                        Console.WriteLine("|======Painel de Cliente======|"); //Painel de Cliente
                        Console.WriteLine("| 1 - Abrir Biblioteca        |"); //Painel de Cliente
                        Console.WriteLine("| 2 - Acessar Loja            |"); //Painel de Cliente
                        Console.WriteLine("| 3 - Checar Transações       |"); //Painel de Cliente
                        Console.WriteLine("| 4 - Adicionar Fundos        |"); //Painel de Cliente
                        Console.WriteLine("| 5 - Gerir Conta             |"); //Painel de Cliente
                        Console.WriteLine("| 0 - LogOut                  |"); //Painel de Cliente
                        Console.WriteLine("|=============================|"); //Painel de Cliente
                        Console.Write("Escolha:");

                        int es = int.Parse(Console.ReadLine());  //Escolha do cliente
                        escl = (clientPanel)es;                  //Escolha do cliente

                        if ((int)escl > 5)
                        {
                            Console.Clear();
                            Console.WriteLine("!!!Opção Inválida!!!");
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            switch (escl)
                            {
                                case clientPanel.VerBiblioteca:
                                    BibliotecaCl(client);
                                    break;
                                case clientPanel.AdicionarFundos:
                                    Console.Clear();
                                    double valor;
                                    Console.WriteLine("|==== Adicionando Fundos ====|");
                                    Console.Write("-> Digite o valor desejado: ");
                                    valor = double.Parse(Console.ReadLine());
                                    loja.adicionarFundos(client, valor);
                                    Console.Clear();
                                    Console.WriteLine($"{valor.ToString("C", CultureInfo.CurrentCulture)} Adicionados ao seu saldo");
                                    Thread.Sleep(2000);
                                    break;
                                case clientPanel.GerirConta:
                                    GerirConta(client, ref escl);
                                    break;
                            }
                        }
                    }
                    

                } while (escl != clientPanel.Logout);
            }
            void BibliotecaCl(Cliente cliente)
            {
                Console.Clear();
                Console.WriteLine($"|====Biblioteca de {cliente.getNome()} ====|");
                if(cliente.getBiblioteca().Count == 0)
                {
                    Console.WriteLine("(Sua Biblioteca está Vazia)");
                }
                else
                {
                    int count = 1;
                    foreach (Jogo jogo in cliente.getBiblioteca())
                    {
                        Console.WriteLine($"{count} - {jogo.getNome()} -    {jogo.getCategoria().getNome()}");
                    }
                    Console.WriteLine("-> Pressione Enter tecla para voltar:");
                    Console.ReadLine();
                }
                
            }
            void BibliotecaDev(Dev dev)
            {
                Console.WriteLine($"|====Biblioteca de {dev.getNome()}|");
                if (dev.getBiblioteca().Count == 0)
                {
                    Console.WriteLine("(Sua Biblioteca está Vazia)");
                }
                else
                {
                    int count = 1;
                    foreach (Jogo jogo in dev.getBiblioteca())
                    {
                        Console.WriteLine($"{count} - {jogo.getNome()}");
                    }
                }

            }
            void GerirConta(Cliente cliente, ref clientPanel scl)
            {
                
                gestaoConta slg = (gestaoConta) 20;
                do
                {
                    if(slg != gestaoConta.Sair)
                    {
                        Console.Clear();
                        Console.WriteLine("|=======Gestão de Conta=======|"); //Gestão de Conta
                        Console.WriteLine("| 1 - Alterar Nome            |"); //Gestão de Conta
                        Console.WriteLine("| 2 - Alterar Nome de Usuário |"); //Gestão de Conta
                        Console.WriteLine("| 3 - Alterar Senha           |"); //Gestão de Conta
                        Console.WriteLine("| 4 - Excluir Conta           |"); //Gestão de Conta
                        Console.WriteLine("| 0 - Sair                    |"); //Gestão de Conta
                        Console.WriteLine("|=============================|"); //Gestão de Conta
                        Console.Write("Escolha:");

                        int es = int.Parse(Console.ReadLine());
                        slg = (gestaoConta)es;

                        if ((int)slg > 4)
                        {
                            Console.Clear();
                            Console.WriteLine("!!!Opção Inválida!!!");
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            Console.Clear();
                            switch (slg)
                            {
                                case gestaoConta.AlterarNome:
                                    string senha, nome, login;
                                    Console.Clear();
                                    Console.WriteLine("|==== Alterando Nome ====|");
                                    Console.Write("-> Confime sua senha: ");
                                    senha = Console.ReadLine();
                                    if (senha == cliente.getSenha())
                                    {
                                        Console.Write("-> Digite seu novo nome: ");
                                        nome = Console.ReadLine();
                                        cliente.AlterarNome(nome);
                                        Console.Clear();
                                        Console.WriteLine($"Seu nome foi alterado para {nome}");
                                        Thread.Sleep(2000);
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Senha Incorreta");
                                        Thread.Sleep(2000);
                                        break;
                                    }
                                    break;
                                case gestaoConta.AlterarLogin:
                                    Console.Clear();
                                    Console.WriteLine("|==== Alterando Nome de Usuário ====|");
                                    Console.Write("-> Confime sua senha: ");
                                    senha = Console.ReadLine();
                                    if (senha == cliente.getSenha())
                                    {
                                        Console.Write("-> Digite seu novo nome de usuário: ");
                                        login = Console.ReadLine();
                                        cliente.AlterarLogin(login);
                                        Console.Clear();
                                        Console.WriteLine($"Seu nome foi alterado para {login}");
                                        Thread.Sleep(2000);
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Senha Incorreta");
                                        Thread.Sleep(2000);
                                        break;
                                    }
                                    break;
                                case gestaoConta.AlterarSenha:
                                    Console.Clear();
                                    Console.WriteLine("|==== Alterando Senha ====|");
                                    Console.Write("-> Confime sua antiga senha: ");
                                    senha = Console.ReadLine();
                                    if (senha == cliente.getSenha())
                                    {
                                        Console.Write("-> Digite sua nova senha: ");
                                        senha = Console.ReadLine();
                                        cliente.AlterarSenha(senha);
                                        Console.Clear();
                                        Console.WriteLine($"Seu nome foi alterado para {senha}");
                                        Thread.Sleep(2000);
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Senha Incorreta");
                                        Thread.Sleep(2000);
                                        break;
                                    }
                                    break;
                                case gestaoConta.ExcluirConta:
                                    Console.Clear();
                                    Console.WriteLine("|==== Excluindo Conta ====|");
                                    Console.Write("-> Confime sua senha: ");
                                    senha = Console.ReadLine();
                                    if (senha == cliente.getSenha())
                                    {
                                        int esx = 20;
                                        do
                                        {
                                            if (esx != 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Tenha ciencia que ao excluir a sua conta, está apagando todos os jogos da sua biblioteca e todo o seu processo em nuvem!");
                                                Console.Write("Está certo disso?\n1 - Sim\n2 - Não\nEscolha: ");
                                                esx = int.Parse(Console.ReadLine());
                                                if (esx == 1 || esx == 2)
                                                {
                                                    switch (esx)
                                                    {
                                                        case 1:
                                                            Console.Clear();
                                                            Console.WriteLine("Apagando dos Registros :(");
                                                            loja.excluirCLiente(cliente);
                                                            slg = gestaoConta.Sair;
                                                            scl = clientPanel.Logout;
                                                            esx = 0;
                                                            Thread.Sleep(2000);
                                                            break;
                                                        case 2:
                                                            Console.Clear();
                                                            Console.WriteLine("Abortando a Operação");
                                                            break;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("!!!Opção Inválida!!!");
                                                    Thread.Sleep(2000);
                                                }
                                            }


                                        } while (esx != 0);
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Senha Incorreta");
                                        Thread.Sleep(2000);
                                        break;
                                    }
                                    break;

                            }
                        }
                    }
                    

                } while (slg != gestaoConta.Sair);
            }
        }
    }
}
