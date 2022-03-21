using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmourGames
{
    //a moivimentação é uma transação financeira entre o Cliente e a loja e entre a loja e o dev.
    public class Movi
    {
        public double Valor { get; set; }
        public int Tipo { get; set; }
        public string Descricao { get; set; }
        //métodos

        //construtor
        public Movi(double valor, int tipo, string desc)
        {
            this.Valor = valor;
            this.Tipo = tipo;
            this.Descricao = desc; 
        }
        public Movi()
        {

        }
        public double getValor()
        {
            return this.Valor;
        }
        public string getDescricao()
        {
            return this.Descricao;
        }
        public override string ToString()
        {
            string ty = "";
            switch (this.Tipo)
            {
                case 0:
                    ty = "Saque de saldo";
                    break;
                case 1:
                    ty = "Adição de fundos";
                    break;
                case 2:
                    ty = "Operação de Loja";
                    break;
                case 3:
                    ty = "Venda de jogo";
                    break;
                case 4:
                    ty = "Compra de jogo";
                    break;
            }

            return ty + " no valor de " + this.getValor(); ;
        }

    }
}
