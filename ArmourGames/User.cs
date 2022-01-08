using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmourGames
{
    abstract class User
    {
        // definindo as propriedades do Objeto
        int id; // primary key
        int[] biblioteca; //array com ID dos jogos
        string nomeUsuario, senha;
        double saldo;

        //Setters
        private void setId(int id)
        {
            if (id > 0) { this.id = id; }
        }
        private void setBiblioteca(int[] biblioteca)
        {
            this.biblioteca = biblioteca;
        }
        private void setNomeUsuario(string nomeUsuario)
        {
            if(nomeUsuario.Length != 0) { this.nomeUsuario = nomeUsuario; }
        }
        private void setSenha(string senha)
        {
            if(senha.Length != 0) { this.senha = senha; }
        }
        private void setSaldo(double saldo)
        {
            if (saldo > 0) { this.saldo = saldo; }
        }
        
        //Getters
        public int getId()
        {
            return this.id;
        }
        public int[] getBiblioteca()
        {
            return this.biblioteca;
        }
        public string getNomeUsuario()
        {
            return this.nomeUsuario;
        }
        public string getSenha()
        {
            return this.senha;
        }
        public double getSaldo()
        {
            return this.saldo;
        }

        //Métodos
        public void AlterarNome(string nome)
        {
            if (nome.Length != 0) { this.setNomeUsuario(nome); }
        }
        public void AlterarSenha(string senha)
        {
            if ((senha.Length != 0)) { this.senha = senha; }
        }
        public double checarSaldo()
        {
            return this.getSaldo(); 
        }
    }
}
