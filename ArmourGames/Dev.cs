using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmourGames
{
    public class Dev: User, IDev
    {
        //construtor
        public Dev(string nome, string login, string senha)
        {
           if(nome.Length != 0) { this.Nome = nome;}
           if(login.Length != 0) { this.Login = login;}
           if (senha.Length != 0) { this.Senha = senha;}
            this.Saldo = 0;

        }
        public Dev()
        {

        }
        //métodos
        public void sacarSaldo(double valor)
        {
            this.Saldo = (this.Saldo - valor);
        }
        public void adicionarSaldo(double valor)
        {
            this.Saldo = (this.Saldo + valor);
        }
        
        
    }
}
