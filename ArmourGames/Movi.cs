using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmourGames
{
    //a moivimentação é uma transação financeira entre o Cliente e a loja e entre a loja e o dev.
    class Movi
    {
        double valor;
        int tipo;
        string descricao;
        //métodos

        //construtor
        public Movi(double valor, int tipo, string desc)
        {
            this.valor = valor;
            this.tipo = tipo;
            this.descricao = desc; 
        }

        public double getValor()
        {
            return this.valor;
        }
        public string getDescricao()
        {
            return this.descricao;
        }


    }
}
