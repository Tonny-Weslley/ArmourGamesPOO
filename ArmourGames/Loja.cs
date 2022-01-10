using System.Collections.Generic;

namespace ArmourGames
{
    class Loja
    {
        //propriedades
        List<Cliente> cliente = new List<Cliente>();
        List<Dev> dev = new List<Dev>();
        List<Jogo> jogo = new List<Jogo>();
        List<Categoria> categoria = new List<Categoria>();

        //getters
        public List<Cliente> getCliente()
        {
            return this.cliente;
        }
        public List<Dev> getDev()
        {
            return this.dev;
        }
        public List<Jogo> getJogo()
        {
            return this.jogo;
        }
        public List<Categoria> getCataegoria()
        {
            return this.categoria;
        }
        

        //setters
        private void setCLiente(List<Cliente> cliente)
        {
            this.cliente = cliente;
        }
        private void setDev(List<Dev> dev)
        {
            this.dev = dev;
        }
        private void setJogo(List<Jogo> jogo)
        {
            this.jogo = jogo;
        }

        private void setCategoria(List<Categoria> categoria)
        {
            this.categoria = categoria;
        }

        //Mêtodos

        public void adicionarCliente(Cliente cliente)
        {
            this.cliente.Add(cliente);
        }

        public void adicionarDev(Dev dev)
        {
            this.dev.Add(dev);
        }

        public void adicionarJogo(Dev dev, Jogo jogo)
        {
            this.jogo.Add(jogo);
            dev.adicionarJogo(jogo);
        }
        public void adicionarCategoria(Categoria categoria)
        {
            this.categoria.Add(categoria);
        }
        public void adicionarFundos(Cliente cliente, double valor)
        {
            cliente.AdicionarFundos(valor);
            Movi movimentacao = new Movi(valor, 1, "+ Adição de Fundos");
            cliente.AdicionarMovimentacao(movimentacao);
        }

        public void sacarSaldo(Dev dev, double valor)
        {
            int indexDev = this.getDev().IndexOf(dev);
            this.getDev()[indexDev].adicionarSaldo(valor);
            Movi movimentacao = new Movi(valor, 0, "- Saque de Saldo");
            this.getDev()[indexDev].AdicionarMovimentacao(movimentacao);

        }
        public void excluirCLiente(Cliente cliente)
        {
            this.getCliente().Remove(cliente);
        }
        public void excluirDev(Dev dev)
        {
            this.getDev().Remove(dev);
        }
        public Categoria getEspecificCat(int index)
        {
            Categoria cat = this.getCataegoria()[index];
            return cat;
        }
        public Jogo getEspecificJogo(int i)
        {
            return this.getJogo()[i];
        }
        public int getEspecificJogoIndice(Jogo jogo)
        {
            return this.getJogo().IndexOf(jogo);
        }
        public void ComprarJogo(Cliente cliente, Jogo jogo)
        {
            int indexCliente = this.getCliente().IndexOf(cliente);
            this.getCliente()[indexCliente].AdicionarJogo(jogo);
            int indexJogo = this.getEspecificJogoIndice(jogo);
            this.getJogo()[indexJogo].Compra();
            int indexDev = this.getDev().IndexOf(jogo.getDev());
            Movi movi = new Movi(jogo.getValor(), 3, $"+ Venda do Jogo {jogo.getNome()}");
            this.getDev()[indexDev].AdicionarMovimentacao(movi);
            this.getDev()[indexDev].adicionarSaldo(jogo.getValor());
        }
        // (Star) -> Método Especial
        public void IniciarLoja() //inicia o objeto Loja com alguns dados experimentais.
        {
            Categoria action = new Categoria("Ação", "Jogos que desafiam a velocidade e reflexo do jogador");
            Categoria casual = new Categoria("Casual", "Jogos Casuais são jogos mais simples e acessiveis.");
            Categoria simulation = new Categoria("Simulação", "Jogos que imitam uma realidade.");
            Categoria rpg = new Categoria("RPG", "Jogos onde o jogador interpreta um personagem com motivações e desafios.");
            Categoria race = new Categoria("Corrida", "Jogos onde carros disputam para ver qual o mais rapido.");
            Dev naughyDog = new Dev("NaughtyDog", "NG", "dev123");
            Dev rockstar = new Dev("Rockstar", "RS", "dev456");
            Dev ea = new Dev("Origin", "OG", "dev789");
            Jogo thelastofus = new Jogo("The Last of Us", "Ellie e Joel entram em uma jornada em busca do laboratorio dos vaga-lumes, porém com muitos infectados no camianho", naughyDog, action, 99.50);
            Jogo uncharted = new Jogo("Uncharted: The Nathan Drake Collection", "Nesse pacote, podemos encontrar os títulos: UNCHARTED: Drake’s Fortune, UNCHARTED 2: Among Thieves e UNCHARTED 3: Drake’s Deception.", naughyDog, action, 79.90);
            Jogo crashTB = new Jogo("Crash, the Bandicoot 4", "4° título da serie da raposa e seu arqui-rival, dr cortex", naughyDog, casual, 30.88);
            Jogo gtav = new Jogo("GTA - V", "5° título da serie GTA, nesse jogo, encarne 3 diferentes personagens e se divirta com outros player no modo online.", rockstar, rpg, 99.99);
            Jogo rdr2 = new Jogo("Red Dead Redemption", "O Faroeste voltou, e agora em mundo aberto e online", rockstar, rpg, 149.90);
            Jogo bully = new Jogo("Bully", "Mesmo sendo proibído em vários paises, Bully carrega uma legião de fãs e ainda é um dos jogos mais jogados da rockstar", rockstar, rpg, 99.99);
            Jogo ts4 = new Jogo("The Sims 4", "Jogue em um mundo seu, num jogo de simulação altamente imerssivo (e com dlcs muito caras).", ea, simulation, 120);
            Jogo nfsR = new Jogo("Need for Speed Rivals", "Jogo de carro, igual todos os outros Need for Speeds, corra de carro numa cidade, aposte racha e magicamente tenha seu carro consertado passando por um posto de gasolina", ea, race, 110);
            Jogo battlefield1 = new Jogo("Battlefield 1","Volte para os tempos de primeira guerra mundial, curta um multiplayer imersivo de time contra time e tente levar o seu a vitoria.", ea, action, 225.87);
            Cliente cl1 = new Cliente("João Teste", "jão", "123");
            Cliente cl2 = new Cliente("Maria Teste", "may", "123");
            Cliente cl3 = new Cliente("Joana Teste", "jojo", "123");

            this.adicionarCategoria(action);
            this.adicionarCategoria(casual);
            this.adicionarCategoria(simulation);
            this.adicionarCategoria(rpg);
            this.adicionarCategoria(race);

            this.adicionarDev(naughyDog);
            this.adicionarDev(rockstar);
            this.adicionarDev(ea);

            this.adicionarJogo(naughyDog, thelastofus);
            this.adicionarJogo(naughyDog, uncharted);
            this.adicionarJogo(naughyDog, crashTB);
            this.adicionarJogo(rockstar, gtav);
            this.adicionarJogo(rockstar, rdr2);
            this.adicionarJogo(rockstar, bully);
            this.adicionarJogo(ea, ts4);
            this.adicionarJogo(ea, nfsR);
            this.adicionarJogo(ea, battlefield1);

            cl1.AdicionarFundos(750);
            cl2.AdicionarFundos(900);
            cl3.AdicionarFundos(440);

            cl1.AdicionarJogo(battlefield1);
            cl1.AdicionarJogo(gtav);
            cl2.AdicionarJogo(ts4);
            cl2.AdicionarJogo(crashTB);
            cl3.AdicionarJogo(thelastofus);
            cl3.AdicionarJogo(uncharted);

            this.adicionarCliente(cl1);
            this.adicionarCliente(cl2);
            this.adicionarCliente(cl3);
        }
    }
}