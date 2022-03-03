using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmourGames
{
    interface IJogo
    {
        void AlterarNome(string nome);
        void AlterarDesc(string desc);
        void AlterarCategoria(Categoria cat);
        void AlterarPreco(double valor);
        void Compra();
    }
}
