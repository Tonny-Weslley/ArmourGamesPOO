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
        void adicionarJogo(Jogo jogo);
        Jogo getEspecificJogo(int i);
        void adicionarSaldo(double valor);
    }
}
