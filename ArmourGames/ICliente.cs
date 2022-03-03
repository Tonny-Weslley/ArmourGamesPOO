using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmourGames
{
    interface ICliente
    {
        void AdicionarJogo(Jogo jogo);
        void AdicionarFundos(double valor);
    }
}
