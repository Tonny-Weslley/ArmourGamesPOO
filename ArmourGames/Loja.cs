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

    }
}