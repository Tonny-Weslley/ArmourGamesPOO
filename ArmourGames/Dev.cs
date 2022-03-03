using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmourGames
{
    class Dev: User, IDev
    {
        //construtor
        public Dev(string nome, string login, string senha)
        {
           if(nome.Length != 0) { this.setNome(nome);}
           if(login.Length != 0) { this.setLogin(login);}
           if (senha.Length != 0) { this.setSenha(senha);}
            this.setSaldo(0);

        }
        //métodos
        public void sacarSaldo(double valor)
        {
            this.setSaldo(this.getSaldo() - valor);
        }
        public void adicionarJogo(Jogo jogo)
        {
            this.getBiblioteca().Add(jogo);
        }
        public Jogo getEspecificJogo(int i)
        {
            return this.getBiblioteca()[i];
        }
        public void adicionarSaldo(double valor)
        {
            this.setSaldo(this.getSaldo() + valor);
        }
        
    }
}
