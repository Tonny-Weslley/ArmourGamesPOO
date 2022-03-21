using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmourGames
{
    interface IDev
    {
        void sacarSaldo(double valor);
        Jogo getEspecificJogo(int i);
        void adicionarSaldo(double valor);
    }
}
