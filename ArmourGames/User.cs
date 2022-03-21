
using System;
using System.Collections.Generic;
using System.Linq;


namespace ArmourGames
{

    // A Classe User é uma generalização.
    public abstract class User : IComparable, IUser
    {
        // definindo as propriedades do Objeto
        public string Nome { get; set; }
        public string Login{ get; set; }
        public string Senha { get; set; }
        List<Jogo> Biblioteca { get; set; } = new List<Jogo>();
        List<Movi> Movimentacoes { get; set; } = new List<Movi>();
        public double Saldo { get; set; }
        //========================

        public void AlterarNome(string nome)
        {
            this.Nome = nome;
        }
        public void AlterarLogin(string login)
        {
            this.Login = login;
        }
        public void AlterarSenha(string senha)
        {
            this.Senha = senha;
        }
        public void AdicionarMovimentacao(Movi movimentacao)
        {
            this.Movimentacoes.Add(movimentacao);
        }
        public void AdicionarJogo(Jogo jogo)
        {
            this.Biblioteca.Add(jogo);
        }
        public Jogo getEspecificJogo(int i)
        {
            return this.Biblioteca[i];
        }
        public List<Movi> retornarMovis()
        {
            return this.Movimentacoes;
        }

        public List<Jogo> retornarBiblioteca()
        {
            return this.Biblioteca;
        }

        public override string ToString()
        {
            string jogos = "";
            if(this.Biblioteca.Count() != 0)
            {
                foreach (Jogo j in this.Biblioteca)
                {
                    jogos = jogos + "\n\t" + j.getNome();
                }

            }
            else
            {
                jogos = "biblioteca vazia";
            }
            return "Nome: " + this.Nome + "\nLogin: " + this.Login + "\nSenha: " + this.Senha + "\nPossui os seguintes jogos" + jogos + "\ne seu saldo é de: " + this.Saldo;
        }

        public int CompareTo(object obj)
        {
            User x = this;
            User y = (User)obj;
            if (x.Nome == y.Nome) return 0;
            if (x.Nome.CompareTo(y.Nome) == -1) return -1;
            if (x.Nome.CompareTo(y.Nome) == 1) return 1;
            return 0;
        }
    }
}
