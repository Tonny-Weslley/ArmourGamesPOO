using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmourGames
{
    public class Jogo : IComparable , IJogo
    {
        //propriedades do objeto
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Dev Dev { get; set; }
        public Categoria Categoria { get; set; }
        public double Valor { get; set; }
        public double Faturamento { get; set; }
        public int NumUser { get; set; }
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

        public Jogo()
        {

        }

        //getters
        public string getNome()
        {
            return this.Nome;
        }
        public string getDescricao()
        {
            return this.Descricao;
        }
        public Dev getDev()
        {
            return this.Dev;
        }
        public Categoria getCategoria()
        {
            return this.Categoria;
        }
        public double getValor()
        {
            return this.Valor;
        }
        public double getFaturamento()
        {
            return this.Faturamento;
        }
        public int getNumUser()
        {
            return this.NumUser;
        }
        //setters
        private void setNome(string nome)
        {
            this.Nome = nome;
        }
        private void setDescricao(string descricao)
        {
            this.Descricao = descricao;
        }
        private void setDev(Dev dev)
        {
            this.Dev = dev;
        }
        private void setCategoria(Categoria categoria)
        {
            this.Categoria = categoria;
        }
        private void setValor(double valor)
        {
            this.Valor = valor;
        }
        private void setFaturamento(double faturamento)
        {
            this.Faturamento = faturamento;
        }
        private void setNumUser(int numUser)
        {
            this.NumUser = numUser;
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
            return this.getNome() +"\n"+ this.getDescricao() +"\n"+ this.getCategoria() + "\n";
        }

        public int CompareTo(object obj)
        {
            Jogo x = this;
            Jogo y = (Jogo)obj;
            if (x.getNome() == y.getNome()) return 0;
            if (x.getNome().CompareTo(y.getNome()) == -1) return -1;
            if (x.getNome().CompareTo(y.getNome()) == 1) return 1;
            return 0;
        }
    }
}
