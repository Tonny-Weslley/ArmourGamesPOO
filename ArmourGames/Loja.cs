using System.Collections;

namespace ArmourGames
{
    class Loja
    {
        //propriedades
        ArrayList cliente, dev, jogo, movi, categoria;

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
        // (Star) -> Método Especial
        public void IniciarLoja()
        {
            Categoria action = new Categoria("Ação", "Jogos que desafiam a velocidade e reflexo do jogador");
            Categoria casual = new Categoria("Casual", "Jogos Casuais são jogos mais simples e acessiveis.");
            Categoria simulation = new Categoria("Simulação", "Jogos que imitam uma realidade.");
            Categoria rpg = new Categoria("RPG", "Jogos onde o jogador interpreta um personagem com motivações e desafios.");
            Categoria race = new Categoria("Corrida", "Jogos onde carros disputam para ver qual o mais rapido.");
            Dev naughyDog = new Dev("NaughyDog", "NG", "dev123");
            Dev rockstar = new Dev("Rockstar", "RS", "dev456");
            Dev origin = new Dev("Origin", "OG", "dev789");
            Jogo thelastofus = new Jogo("The Last of Us", "Ellie e Joel entram em uma jornada em busca do laboratorio dos vaga-lumes, porém com muitos infectados no camianho", naughyDog, action, 99.50);
            Jogo uncharted = new Jogo("Uncharted: The Nathan Drake Collection", "Nesse pacote, podemos encontrar os títulos: UNCHARTED: Drake’s Fortune, UNCHARTED 2: Among Thieves e UNCHARTED 3: Drake’s Deception.", naughyDog, action, 79.90);
            Jogo crashTB = new Jogo("Crash, the Bandicoot 4", "4° título da serie da raposa e seu arqui-rival, dr cortex", naughyDog, casual, 30.88);
        }
    }
}