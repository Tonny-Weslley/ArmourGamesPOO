using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmourGames
{

    // A Classe User é uma generalização.
    abstract class User
    {
        // definindo as propriedades do Objeto
        string nome, login, senha;
        List<Jogo> biblioteca = new List<Jogo>();
        List<Movi> movimentacoes = new List<Movi>();
        double saldo;
        //========================

        //getters
        public string getNome()
        {
            return this.nome;
        }
        public string getLogin()
        {
            return this.login;
        }
        public string getSenha()
        {
            return this.senha;
        }
        public List<Jogo> getBiblioteca()
        {
            return this.biblioteca;
        }
        public List<Movi> getMovimentacoes()
        {
            return this.movimentacoes;
        }
        public double getSaldo()
        {
            return this.saldo;
        }
        //setters
        protected void setNome(string nome)
        {
            this.nome = nome;
        }
        protected void setLogin(string login)
        {
            this.login = login;
        }
        protected void setSenha(string senha)
        {
            this.senha = senha;
        }
        protected void setBiblioteca(List<Jogo> biblioteca)
        {
            this.biblioteca = biblioteca;
        }
        protected void setMovimentacoes(List<Movi> movimentacoes)
        {
            this.movimentacoes = movimentacoes;
        }
        protected void setSaldo(double saldo)
        {
            this.saldo = saldo;
        }

        public void AlterarNome(string nome)
        {
            this.setNome(nome);
        }
        public void AlterarLogin(string login)
        {
            this.setLogin(login);
        }
        public void AlterarSenha(string senha)
        {
            this.setSenha(senha);
        }
        public void AdicionarMovimentacao(Movi movimentacao)
        {
            this.getMovimentacoes().Add(movimentacao);
        }
        public override string ToString()
        {
            string jogos = "";
            if(this.biblioteca.Count() != 0)
            {
                foreach (Jogo j in this.biblioteca)
                {
                    jogos = jogos + "\n\t" + j.getNome();
                }

            }
            else
            {
                jogos = "biblioteca vazia";
            }
            return "Nome: " + this.getNome() + "\nLogin: " + this.getLogin() + "\nSenha: " + this.getSenha() + "\nPossui os seguintes jogos" + jogos + "\ne seu saldo é de: " + this.getSaldo();
        }
    }
}
