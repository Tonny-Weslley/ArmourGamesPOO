using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmourGames
{
    interface IUser
    {
        void AlterarNome(string nome);
        void AlterarLogin(string login);
        void AlterarSenha(string senha);
        void AdicionarMovimentacao(Movi movimentacao);

    }
}
