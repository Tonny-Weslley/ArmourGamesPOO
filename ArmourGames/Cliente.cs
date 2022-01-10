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
        public void AdicionarJogo(Jogo jogo)
        {
            this.getBiblioteca().Add(jogo);
            this.setSaldo(this.getSaldo() - jogo.getValor());
            Movi movi = new Movi(jogo.getValor(), 2, $"- Compra do jogo {jogo.getNome()}");
        }
        public void AdicionarFundos(double valor)
        {
            this.setSaldo(this.getSaldo() + valor);
        }
        

    }
}
