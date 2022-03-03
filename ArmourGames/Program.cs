using System;
using System.Globalization;
using System.Threading;


namespace ArmourGames
{
    class Program
    {
        enum mainMenu {Login = 1, Cadastro = 2, Loja = 3, Sair = 0, Bomb = 7355608};//painel de opções principal.
        enum usrMenu {Cliente = 1, Dev = 2, Sair = 0};//painel de opções do Usuario tanto de login como de cadastro.
        enum devPanel {GerirJogos = 1, AcessarLoja = 2, ChecarTransacoes = 3, SacarSaldo = 4, GerirConta = 5, ToString = 6, Logout = 0};//painel de opções do Desenvolvedor.
        enum clientPanel {VerBiblioteca = 1, AcessarLoja = 2, ChecarTransacoes = 3, AdicionarFundos = 4, GerirConta = 5, ToString = 6, Logout = 0};//painel de opçoes do Cliente.
        enum gestaoConta { AlterarNome = 1, AlterarLogin = 2, AlterarSenha = 3, ExcluirConta = 4, Sair = 0};//Opções de gestão do Usuario
        enum gestãoJogo { AlterarNome = 1, AlterarDescricao = 2, AlterarValor = 3, ExcluirJogo = 5};//Opções de gestão de Jogos
        enum gestaoJogoMenu { SelecionarJogo = 1, AdicionarNovoJogo = 2, Sair = 0}// Opções de gestão geral de Jogos
        enum updateGame { AlterarNome = 1, AlterarDescricao = 2, AlterarCategoria = 3, AlterarPreco = 4, Sair = 0}// Opções para alterar informações dos gamest
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
                Console.WriteLine("| Opção 2 - Cadastre-se|"); //Menu principal da aplicação
                Console.WriteLine("| Opção 0 - Sair       |"); //Menu principal da aplicação.
                Console.WriteLine("|======================|"); //Menu principal da aplicação.
                Console.Write("Escolha: ");

                int op = int.Parse(Console.ReadLine()); //Escolha do Cliente
                opMain = (mainMenu)op;                  //Escolha do Cliente

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
                    case mainMenu.Bomb:
                        Console.Clear();
                        Console.WriteLine(loja.ToString());
                        Console.Write("-> Pressione Enter para sair: ");
                        Console.ReadLine();
                        break;
                    case mainMenu.Sair:
                        Console.Clear();
                        Console.WriteLine("Fechando");
                        Thread.Sleep(2000);
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
                usrMenu esc = (usrMenu) 20;
                do {
                    if(esc != usrMenu.Sair)
                    {
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

                                switch (esc)
                                {
                                    case usrMenu.Dev:
                                        Dev dev = new Dev(nome, login, senha);
                                        esc = usrMenu.Sair;
                                        loja.adicionarDev(dev);
                                        DevPanel(dev);
                                        break;
                                    case usrMenu.Cliente:
                                        Cliente cliente = new Cliente(nome, login, senha);
                                        loja.adicionarCliente(cliente);
                                        esc = usrMenu.Sair;
                                        ClientPanel(cliente);
                                        break;
                                }
                                if(esc != usrMenu.Sair)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Usuário cadastrado com sucesso");
                                    Thread.Sleep(2000);
                                }
                                
                            }
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
                
                devPanel esdv = (devPanel) 20;
                do
                {
                    if(esdv != devPanel.Logout)
                    {
                        Console.Clear();
                        Console.WriteLine($"Olá, {dev.getNome()}    Saldo: {dev.getSaldo().ToString("C", CultureInfo.CurrentCulture)}");
                        Console.WriteLine("|======Painel de Desenvolvedor======|"); //Painel de Desenvolvedor
                        Console.WriteLine("| 1 - Gerir Seus Jogos              |"); //Painel de Desenvolvedor
                        Console.WriteLine("| 2 - Ver Loja                      |"); //Painel de Desenvolvedor
                        Console.WriteLine("| 3 - Checar Transações             |"); //Painel de Desenvolvedor
                        Console.WriteLine("| 4 - Sacar Saldo                   |"); //Painel de Desenvolvedor
                        Console.WriteLine("| 5 - Gerir Conta                   |"); //Painel de Desenvolvedor
                        Console.WriteLine("| 6 - ToString                      |"); //Painel de Desenvolvedor
                        Console.WriteLine("| 0 - LogOut                        |"); //Painel de Desenvolvedor
                        Console.WriteLine("|===================================|"); //Painel de Desenvolvedor
                        Console.Write("Escolha:");

                        int es = int.Parse(Console.ReadLine());
                        esdv = (devPanel)es;

                        if ((int)esdv > 6)
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
                                    GerirJogos(dev);
                                    break;
                                case devPanel.AcessarLoja:
                                    VerLojaDev();
                                    break;
                                case devPanel.ChecarTransacoes:
                                    Console.Clear();
                                    Console.WriteLine("|=== Transações ===|");
                                    foreach (Movi movi in dev.getMovimentacoes())
                                    {
                                        Console.WriteLine($"{movi.getDescricao()} : {movi.getValor().ToString("C", CultureInfo.CurrentCulture)}");
                                    }
                                    Console.WriteLine("Clique Enter Para voltar:");
                                    Console.ReadLine();
                                    break;
                                case devPanel.SacarSaldo:
                                    double valor;
                                    Console.WriteLine("|==== Sacar Saldo ====|");
                                    Console.Write("-> Digite o valor desejado: ");
                                    valor = double.Parse(Console.ReadLine());
                                    if(dev.getSaldo() >= valor)
                                    {
                                        loja.sacarSaldo(dev, valor);
                                        Console.Clear();
                                        Console.WriteLine($"Você acabou de sacar {valor.ToString("C", CultureInfo.CurrentCulture)}");
                                        Thread.Sleep(2000);
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("O seu saldo não corresponde ao valor solicitado!!!");
                                        Thread.Sleep(2000);
                                        break;
                                    }
                                case devPanel.GerirConta:
                                    GerirContadev(dev, ref esdv);
                                    break;
                                case devPanel.ToString:
                                    Console.Clear();
                                    Console.WriteLine(dev.ToString());
                                    Console.Write("Pressione enter para sair");
                                    Console.ReadLine();
                                    break;
                            }
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
                        Console.WriteLine("| 6 - ToString                |"); //Painel de Desenvolvedor
                        Console.WriteLine("| 0 - LogOut                  |"); //Painel de Cliente
                        Console.WriteLine("|=============================|"); //Painel de Cliente
                        Console.Write("Escolha:");

                        int es = int.Parse(Console.ReadLine());  //Escolha do cliente
                        escl = (clientPanel)es;                  //Escolha do cliente

                        if ((int)escl > 6)
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
                                case clientPanel.AcessarLoja:
                                    AcessarLoja(client);
                                    break;
                                case clientPanel.ChecarTransacoes:
                                    Console.Clear();
                                    Console.WriteLine("|=== Transações ===|");
                                    foreach (Movi movi in client.getMovimentacoes())
                                    {
                                        Console.WriteLine($"{movi.getDescricao()} : {movi.getValor().ToString("C", CultureInfo.CurrentCulture)}");
                                    }
                                    Console.WriteLine("Clique Enter Para voltar:");
                                    Console.ReadLine();
                                    break;
                                case clientPanel.GerirConta:
                                    GerirConta(client, ref escl);
                                    break;
                                case clientPanel.ToString:
                                    Console.Clear();
                                    Console.WriteLine(client.ToString());
                                    Console.Write("Pressione enter para sair");
                                    Console.ReadLine();
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
                    Console.WriteLine("-> Pressione Enter para voltar:");
                    Console.ReadLine();
                }
                else
                {
                    int count = 1;
                    foreach (Jogo jogo in cliente.getBiblioteca())
                    {
                        Console.WriteLine($"{count} - {jogo.getNome()} -    {jogo.getCategoria().getNome()}");
                    }
                    Console.WriteLine("-> Pressione Enter para voltar:");
                    Console.ReadLine();
                }
                
            }
            void GerirJogos(Dev dev)
            {
                gestaoJogoMenu sljg = (gestaoJogoMenu) 20;
                do
                {
                    Console.Clear();
                    Console.WriteLine($"|=========================Biblioteca de {dev.getNome()}=====================|");
                    Console.WriteLine($"|   Index    |      Nome       |    N° de Jogadores |   Valor   |   Renda   |");
                    if (dev.getBiblioteca().Count == 0)
                    {
                        Console.WriteLine("(Sua Biblioteca está Vazia)");
                        Console.WriteLine("-> Pressione Enter para voltar:");
                        Console.ReadLine();
                    }
                    else
                    {
                        int count = 0;
                        foreach (Jogo jogo in dev.getBiblioteca())
                        {
                            Console.WriteLine($"|{count + 1} - {jogo.getNome()} - {jogo.getNumUser()} - {jogo.getValor().ToString("C", CultureInfo.CurrentCulture)} - {jogo.getFaturamento().ToString("C", CultureInfo.CurrentCulture)}|");
                            count++;
                        }
                    }
                    Console.WriteLine("Selecione uma opção: 1 - Selecionar jogo | 2 - Adicionar Jogo | 0 - Voltar ao Menu");
                    Console.Write("Selecionar: ");
                    int es = int.Parse(Console.ReadLine());
                    sljg = (gestaoJogoMenu)es;

                    if((int)sljg > 3)
                    {
                        Console.Clear();
                        Console.WriteLine("!!!Operação Inválida!!!");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        switch (sljg)
                        {
                            case gestaoJogoMenu.AdicionarNovoJogo:
                                string nome, desc;
                                Categoria cat;
                                double valor;
                                Console.Clear();
                                Console.WriteLine("|==== Criação de Jogo ====|");
                                Console.Write("Qual o nome do jogo: ");
                                nome = Console.ReadLine();
                                Console.Write("Descreva seu jogo: ");
                                desc = Console.ReadLine();
                                Console.Write("Quanto Custa o seu jogo: ");
                                valor = double.Parse(Console.ReadLine());
                                Console.WriteLine("Escolha uma categoria para o seu jogo:");
                                int index = 0;
                                foreach(Categoria categoria in loja.getCataegoria())
                                {
                                    Console.WriteLine($"{index + 1} - {categoria.getNome()}");
                                    index++;
                                }
                                int i = int.Parse(Console.ReadLine());
                                cat = loja.getEspecificCat(i-1);

                                Jogo j = new Jogo(nome, desc, dev, cat, valor);

                                Console.Clear();
                                Console.WriteLine("====Novo Jogo====");
                                Console.WriteLine($"Nome:\n{j.getNome()}");
                                Console.WriteLine($"Descrição:\n{j.getDescricao()}");
                                Console.WriteLine($"Desenvolvedora:\n{j.getDev().getNome()}");
                                Console.WriteLine($"Categoria:\n{j.getCategoria().getNome()}");
                                Console.WriteLine($"Valor: {j.getValor().ToString("C", CultureInfo.CurrentCulture)}");
                                Console.Write("-> Confirmar publicação \n 1 - sim\n 2 - não\nEscolha: ");
                                int confirma = int.Parse(Console.ReadLine());
                                if(confirma == 1)
                                {
                                    loja.adicionarJogo(dev, j);
                                    Console.Clear();
                                    Console.WriteLine("Jogo Postado com Sucesso");
                                    Thread.Sleep(2000);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Abortando operação");
                                    Thread.Sleep(2000);
                                }

                                break;
                            case gestaoJogoMenu.SelecionarJogo:
                                Console.Write("Qual o indice do jogo que você quer selecionar: ");
                                int indice = int.Parse(Console.ReadLine());
                                if (indice > dev.getBiblioteca().Count)
                                {
                                    Console.Clear();
                                    Console.WriteLine("!!!Indice Inexistente!!!");
                                    Thread.Sleep(2000);
                                }
                                else
                                {
                                    updateGame  slup;
                                    do
                                    {
                                        Jogo jogo = dev.getEspecificJogo(indice - 1);
                                        //resgatando o indice do jogo na biblioteca;
                                        int indiB = loja.getEspecificJogoIndice(jogo);
                                        Console.Clear();
                                        Console.WriteLine($"|===Editando Preferencias do Jogo {jogo.getNome()}===|");
                                        Console.WriteLine("| 1 - Alterar Nome do Jogo          |");
                                        Console.WriteLine("| 2 - Alterar Descrição             |");
                                        Console.WriteLine("| 3 - Alterar Categoria             |");
                                        Console.WriteLine("| 4 - Alterar preço                 |");
                                        Console.WriteLine("| 0 - Sair                          |");
                                        Console.WriteLine("|===================================|");
                                        Console.Write("Escolha: ");

                                        int esc = int.Parse(Console.ReadLine());
                                        slup = (updateGame)esc;


                                        switch (slup){
                                            case updateGame.AlterarNome:
                                                string senha, newnome;
                                                Console.WriteLine("|==== Alterando Nome ====|");
                                                Console.Write("-> Confime sua senha: ");
                                                senha = Console.ReadLine();
                                                if (senha == dev.getSenha())
                                                {
                                                    Console.Write("-> Novo nome: ");
                                                    newnome = Console.ReadLine();
                                                    dev.getBiblioteca()[indice - 1].AlterarNome(newnome);
                                                    loja.getJogo()[indiB].AlterarNome(newnome);
                                                    Console.Clear();
                                                    Console.WriteLine($"Nome alterado para {newnome}");
                                                    Thread.Sleep(2000);
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Senha Incorreta");
                                                    Thread.Sleep(2000);
                                                }
                                                break;
                                            case updateGame.AlterarDescricao:
                                                string descricao;
                                                Console.WriteLine("|==== Alterando descrição ====|");
                                                Console.Write("-> Confime sua senha: ");
                                                senha = Console.ReadLine();
                                                if (senha == dev.getSenha())
                                                {
                                                    Console.Write("-> Nova descrição: ");
                                                    descricao = Console.ReadLine();
                                                    dev.getBiblioteca()[indice - 1].AlterarDesc(descricao);
                                                    loja.getJogo()[indiB].AlterarDesc(descricao);
                                                    Console.Clear();
                                                    Console.WriteLine($"Descrição alterada para: {descricao}");
                                                    Thread.Sleep(2000);
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Senha Incorreta");
                                                    Thread.Sleep(2000);
                                                }
                                                break;
                                            case updateGame.AlterarPreco:
                                                double preco;
                                                Console.WriteLine("|==== Alterando preço ====|");
                                                Console.Write("-> Confime sua senha: ");
                                                senha = Console.ReadLine();
                                                if (senha == dev.getSenha())
                                                {
                                                    Console.Write("-> Novo Preço: ");
                                                    preco = double.Parse(Console.ReadLine());
                                                    dev.getBiblioteca()[indice - 1].AlterarPreco(preco);
                                                    loja.getJogo()[indiB].AlterarPreco(preco);
                                                    Console.Clear();
                                                    Console.WriteLine($"Preço alterado para {preco.ToString("C", CultureInfo.CurrentCulture)}");
                                                    Thread.Sleep(2000);
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Senha Incorreta");
                                                    Thread.Sleep(2000);
                                                }
                                                break;
                                            case updateGame.AlterarCategoria:
                                                Categoria newcategoria;
                                                Console.WriteLine("|==== Alterando Categoria ====|");
                                                Console.Write("-> Confime sua senha: ");
                                                senha = Console.ReadLine();
                                                if (senha == dev.getSenha())
                                                {
                                                    Console.WriteLine("Escolha uma nova categoria para o seu jogo:");
                                                    index = 0;
                                                    foreach (Categoria categoria in loja.getCataegoria())
                                                    {
                                                        Console.WriteLine($"{index + 1} - {categoria.getNome()}");
                                                    }
                                                    Console.Write("Escolha: ");
                                                    int ind = int.Parse(Console.ReadLine());
                                                    newcategoria = loja.getEspecificCat(ind - 1);
                                                    dev.getBiblioteca()[indice - 1].AlterarCategoria(newcategoria);
                                                    loja.getJogo()[indiB].AlterarCategoria(newcategoria);
                                                    Console.Clear();
                                                    Console.WriteLine($"Categoria alterada para {newcategoria.getNome()}");
                                                    Thread.Sleep(2000);
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Senha Incorreta");
                                                    Thread.Sleep(2000);
                                                }
                                                break;
                                        }

                                    } while (slup != updateGame.Sair);
                                    

                                }
                                

                                break;
                        }
                    }

                } while (sljg != gestaoJogoMenu.Sair);
                

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
            void GerirContadev(Dev dev, ref devPanel scl)
            {

                gestaoConta slg = (gestaoConta)20;
                do
                {
                    if (slg != gestaoConta.Sair)
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
                                    if (senha == dev.getSenha())
                                    {
                                        Console.Write("-> Digite seu novo nome: ");
                                        nome = Console.ReadLine();
                                        dev.AlterarNome(nome);
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
                                    if (senha == dev.getSenha())
                                    {
                                        Console.Write("-> Digite seu novo nome de usuário: ");
                                        login = Console.ReadLine();
                                        dev.AlterarLogin(login);
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
                                    if (senha == dev.getSenha())
                                    {
                                        Console.Write("-> Digite sua nova senha: ");
                                        senha = Console.ReadLine();
                                        dev.AlterarSenha(senha);
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
                                    if (senha == dev.getSenha())
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
                                                            if(dev.getBiblioteca().Count > 0)
                                                            {
                                                                Console.WriteLine("Você Possui Jogos a Venda, Contate o Administrador da plataforma");
                                                                Thread.Sleep(2000);
                                                                esx = 0;
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("Apagando dos Registros :(");
                                                                loja.excluirDev(dev);
                                                                slg = gestaoConta.Sair;
                                                                scl = devPanel.Logout;
                                                                esx = 0;
                                                                Thread.Sleep(2000);
                                                                break;
                                                            }
                                                            
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
            void VerLojaDev()
            {
                int indice;
                do
                {
                    Console.Clear();
                    Console.WriteLine("|      Index       |    Nome    |   Valor   |");
                    int index = 0;
                    foreach (Jogo jogo in loja.getJogo())
                    {
                        Console.WriteLine($"{index + 1} - {jogo.getNome()} - {jogo.getValor().ToString("C", CultureInfo.CurrentCulture)}");
                        index++;
                    }
                    Console.Write("Escola um jogo para ispecionar (0 - para voltar ao menu de desenvolvedor): ");
                    indice = int.Parse(Console.ReadLine());
                    if(indice > loja.getJogo().Count || indice <= 0 )
                    {
                        if(indice != 0)
                        {
                            Console.Clear();
                            Console.WriteLine("!!!Indice Inexistente!!!");
                            Thread.Sleep(2000);
                        }
                        
                    }
                    else
                    {
                        Jogo jogo = loja.getEspecificJogo(indice - 1);
                        Console.Clear();
                        Console.WriteLine($"|      Nome       |    N° de Jogadores |   Valor   |   Desenvolvedor   |");
                        Console.WriteLine($"|{jogo.getNome()} - {jogo.getNumUser()} - {jogo.getValor().ToString("C", CultureInfo.CurrentCulture)} - {jogo.getDev().getNome()}|");
                        Console.WriteLine("Pressione Enter Para voltar");
                        Console.ReadLine();
                    }
                } while (indice != 0);
                
            }
            void AcessarLoja(Cliente cliente)
            {
                int indice;
                do
                {
                    Console.Clear();
                    Console.WriteLine("|      Index       |    Nome    |    Categoria   |   Valor   |");
                    int index = 0;
                    foreach (Jogo jogo in loja.getJogo())
                    {
                        Console.WriteLine($"{index + 1} - {jogo.getNome()} - {jogo.getCategoria().getNome()} - {jogo.getValor().ToString("C", CultureInfo.CurrentCulture)}");
                        index++;
                    }
                    Console.Write("Escola um jogo para ispecionar (0 - para voltar ao menu de Cliente): ");
                    indice = int.Parse(Console.ReadLine());

                    if (indice > loja.getJogo().Count || indice <= 0)
                    {
                        if (indice != 0)
                        {
                            Console.Clear();
                            Console.WriteLine("!!!Indice Inexistente!!!");
                            Thread.Sleep(2000);
                        }
                    }
                    else
                    {
                        int op = 20;
                        do
                        {
                            if(op != 0)
                            {
                                Console.Clear();
                                Jogo jogo = loja.getEspecificJogo(indice - 1);
                                Console.WriteLine($"|      Nome       |    N° de Jogadores |   Valor   |   Desenvolvedor   |");
                                Console.WriteLine($"|{jogo.getNome()} - {jogo.getNumUser()} - {jogo.getValor().ToString("C", CultureInfo.CurrentCulture)} - {jogo.getDev().getNome()}|");
                                Console.WriteLine("Selecione uma opção:\n1 - Comprar\n0 - voltar");
                                Console.Write("Selecione: ");
                                op = int.Parse(Console.ReadLine());
                                if (op != 1 && op != 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("!!!Opção Inválida!!!");
                                    Thread.Sleep(2000);
                                }
                                else
                                {
                                    if (op != 0)
                                    {
                                        if (cliente.getSaldo() < jogo.getValor())
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Saldo insuficiente, adicione fundos a sua carteira");
                                            Thread.Sleep(2000);
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("|=== Compra de Jogo ===|");
                                            Console.WriteLine($"Saldo atual: {cliente.getSaldo().ToString("C", CultureInfo.CurrentCulture)}");
                                            Console.WriteLine($"Valor do jogo: {jogo.getValor().ToString("C", CultureInfo.CurrentCulture)}");
                                            Console.WriteLine($"Saldo restante: {(cliente.getSaldo() - jogo.getValor()).ToString("C", CultureInfo.CurrentCulture)}");
                                            Console.Write("-> Confirmar compra: \n 1 - sim\n 2 - não\nEscolha: ");
                                            int confirma = int.Parse(Console.ReadLine());
                                            if (confirma == 1)
                                            {
                                                loja.ComprarJogo(cliente, jogo);
                                                Console.Clear();
                                                Console.WriteLine("Jogo Adicionado a sua Biblioteca");
                                                Thread.Sleep(2000);
                                                op = 0;
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Abortando Operação");
                                                Thread.Sleep(2000);
                                            }
                                        }
                                    }
                                }
                            }
                            
                        } while (op != 0);
                        

                    }

                } while (indice != 0);
            }
        }
    }
}
