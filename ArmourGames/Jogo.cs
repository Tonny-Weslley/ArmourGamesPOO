using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmourGames
{
    class Jogo
    {
        //propriedades do objeto
        string nome, descricao;
        Dev dev;
        Categoria categoria;
        double valor, faturamento;
        int numUser;
        //========================

        //Construtor
        public Jogo(string nome, string descricao, Dev dev, Categoria categoria, double valor)
        {
            if (nome.Length != 0) { this.setNome(nome); };
            if (descricao.Length != 0) { this.setDescricao(descricao); };
            this.setDev(dev);
            this.setCategoria(categoria);
            this.setValor(valor);
            this.setNumUser(0);
            this.setFaturamento(0);
        }


        //getters
        public string getNome()
        {
            return this.nome;
        }
        public string getDescricao()
        {
            return this.descricao;
        }
        public Dev getDev()
        {
            return this.dev;
        }
        public Categoria getCategoria()
        {
            return this.categoria;
        }
        public double getValor()
        {
            return this.valor;
        }
        public double getFaturamento()
        {
            return this.faturamento;
        }
        public int getNumUser()
        {
            return this.numUser;
        }
        //setters
        private void setNome(string nome)
        {
            this.nome = nome;
        }
        private void setDescricao(string descricao)
        {
            this.descricao = descricao;
        }
        private void setDev(Dev dev)
        {
            this.dev = dev;
        }
        private void setCategoria(Categoria categoria)
        {
            this.categoria = categoria;
        }
        private void setValor(double valor)
        {
            this.valor = valor;
        }
        private void setFaturamento(double faturamento)
        {
            this.faturamento = faturamento;
        }
        private void setNumUser(int numUser)
        {
            this.numUser = numUser;
        }
        //========================

        public void AlterarNome(string nome)
        {
            this.setNome(nome);
        }
        public void AlterarDesc(string desc)
        {
            this.setDescricao(desc);
        }
        public void AlterarCategoria(Categoria cat)
        {
            this.setCategoria(cat);
        }
        public void AlterarPreco(double valor)
        {
            this.setValor(valor);
        }
        public void Compra()
        {
            this.setFaturamento(this.getFaturamento() + this.getValor());
            this.setNumUser(this.getNumUser() + 1);
        }
        public override string ToString()
        {
            return "A Implementar";
        }
    }
}
