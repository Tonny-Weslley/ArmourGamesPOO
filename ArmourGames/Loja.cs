using System.Collections;

namespace ArmourGames
{
    class Loja
    {
        //propriedades
        ArrayList cliente = new ArrayList(), dev = new ArrayList(), jogo = new ArrayList(), movi = new ArrayList(), categoria = new ArrayList();

        //getters
        public ArrayList getCLiente()
        {
            return this.cliente;
        }
        public ArrayList getDev()
        {
            return this.dev;
        }
        public ArrayList getJogo()
        {
            return this.jogo;
        }
        public ArrayList getMovi()
        {
            return this.movi;
        }
        public ArrayList getCataegoria()
        {
            return this.categoria;
        }
        

        //setters
        private void setCLiente(ArrayList cliente)
        {
            this.cliente = cliente;
        }
        private void setDev(ArrayList dev)
        {
            this.cliente = dev;
        }
        private void setJogo(ArrayList jogo)
        {
            this.cliente = jogo;
        }
        private void setMovi(ArrayList movi)
        {
            this.cliente = movi;
        }
        private void setCategoria(ArrayList categoria)
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
            this.cliente.Add(dev);
        }

        public void adicionarJogo(Jogo jogo)
        {
            this.jogo.Add(jogo);
        }
        public void adicionarCategoria(Categoria categoria)
        {
            this.categoria.Add(categoria);
        }



        // (Star) -> Método Especial
        public void IniciarLoja() //inicia o objeto Loja com alguns dados experimentais.
        {
            Categoria action = new Categoria("Ação", "Jogos que desafiam a velocidade e reflexo do jogador");
            Categoria casual = new Categoria("Casual", "Jogos Casuais são jogos mais simples e acessiveis.");
            Categoria simulation = new Categoria("Simulação", "Jogos que imitam uma realidade.");
            Categoria rpg = new Categoria("RPG", "Jogos onde o jogador interpreta um personagem com motivações e desafios.");
            Categoria race = new Categoria("Corrida", "Jogos onde carros disputam para ver qual o mais rapido.");
            Dev naughyDog = new Dev("NaughyDog", "NG", "dev123");
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

            this.adicionarCategoria(action);
            this.adicionarCategoria(casual);
            this.adicionarCategoria(simulation);
            this.adicionarCategoria(rpg);
            this.adicionarCategoria(race);

            this.adicionarDev(naughyDog);
            this.adicionarDev(rockstar);
            this.adicionarDev(ea);

            this.adicionarJogo(thelastofus);
            this.adicionarJogo(uncharted);
            this.adicionarJogo(crashTB);
            this.adicionarJogo(gtav);
            this.adicionarJogo(rdr2);
            this.adicionarJogo(bully);
            this.adicionarJogo(ts4);
            this.adicionarJogo(nfsR);
            this.adicionarJogo(battlefield1);


        }
    }
}