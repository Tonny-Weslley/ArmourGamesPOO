using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmourGames
{
    class Cliente : User, ICliente, IComparable<Cliente>
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

        public int CompareTo(Cliente other)
        {
            Cliente x = this;
            Cliente y = (Cliente)other;
            if (x.getNome() == y.getNome()) return 0;
            if (x.getNome().CompareTo(y.getNome()) == -1) return -1;
            if (x.getNome().CompareTo(y.getNome()) == 1) return 1;
            return 0;
        }
    }
}
