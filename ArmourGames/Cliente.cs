using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmourGames
{
    class Cliente:User
    {
        public Cliente()
        {
        }

        //construtor
        public Cliente(string nome, string login, string senha)
        {
            if (nome.Length != 0) { this.setNome(nome); }
            if (login.Length != 0) { this.setLogin(login); }
            if (senha.Length != 0) { this.setSenha(senha); }
            this.setSaldo(0);

        }


        //Métodos
        public void AdicionarSaldo(double valor)
        {
            this.setSaldo(this.getSaldo() + valor);
        }
        public void AdicionarJogo(Jogo jogo)
        {
            this.getBiblioteca().Add(jogo);
        }
        public void AdicionarFundos(double valor)
        {
            this.setSaldo(this.getSaldo() + valor);
        }

    }
}
