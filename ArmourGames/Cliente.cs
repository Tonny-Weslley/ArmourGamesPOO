using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmourGames
{
    public class Cliente : User, ICliente, IComparable<Cliente>
    {
        public Cliente()
        {
        }

        //construtor
        public Cliente(string nome, string login, string senha)
        {
            if (nome.Length != 0) { this.Nome = nome; }
            if (login.Length != 0) { this.Login = login; }
            if (senha.Length != 0) { this.Senha = senha; }
            this.Saldo = 0;

        }


        //Métodos
        public void AdicionarFundos(double valor)
        {
            this.Saldo = (this.Saldo + valor);
        }

        public int CompareTo(Cliente other)
        {
            Cliente x = this;
            Cliente y = (Cliente)other;
            if (x.Nome == y.Nome) return 0;
            if (x.Nome.CompareTo(y.Nome) == -1) return -1;
            if (x.Nome.CompareTo(y.Nome) == 1) return 1;
            return 0;
        }
    }
}
