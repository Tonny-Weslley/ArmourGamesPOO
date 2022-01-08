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
        ArrayList comp; // indice 0 = Operador, indice 1 = alvo.

        //getters
        public double getValor()
        {
            return this.valor;
        }
        public ArrayList getcomp()
        {
            return this.comp;
        }
        //Setters
        private void setValor(double valor)
        {
            this.valor = valor;
        }
        private void setComp(ArrayList comp)
        {
            this.comp = comp;
        }

        //métodos

    }
}
