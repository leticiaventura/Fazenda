using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fazenda.Apresentacao
{
    public interface IFormulario
    {
        void Adicionar();
        void Editar();
        void Excluir();
        UserControl CarregarListagem();
        string ObtemTipoCadastro();
        void AtualizarLista();
        void AtualizarListaReloadBancoDados();
        void AtualizarLista(string[] termosParaPesquisar);
    }
}
