using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmourGames
{
    class Cliente:User
    {

        //Métodos
        public void AdicionarSaldo(double valor)
        {
            this.setSaldo(this.getSaldo() + valor);
        }

    }
}
