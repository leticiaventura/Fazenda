using Fazenda.Dominio.Features.Fornecedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fazenda.Apresentacao.Features.Fornecedores
{
    public class GerenciadorFormularioFornecedor : IFormulario
    {
        private Fornecedor _fornecedor;
        private ControleFornecedor _controleFornecedor;
        private CadastrarFornecedorForm _dialogo;
        IFornecedorServico _fornecedorServico;
        ICollection<Fornecedor> _fornecedores;

        public GerenciadorFormularioFornecedor(IFornecedorServico fornecedorServico)
        {
            _dialogo = new CadastrarFornecedorForm();
            _fornecedorServico = fornecedorServico;
        }

        public void Adicionar()
        {
            try
            {
                DialogResult resultado = _dialogo.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _fornecedor = _dialogo.novoFornecedor;
                    _fornecedorServico.Adicionar(_fornecedor);
                    MessageBox.Show("Fornecedor registrado com sucesso!");
                }
                _dialogo.LimparCampos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Adicionar();
            }
        }

        public void AtualizarLista()
        {
            try
            {
                _fornecedores = _fornecedorServico.PegarTodos().OrderBy(p => p.Nome).ToList();
                _controleFornecedor.CarregarLista(_fornecedores);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void AtualizarListaReloadBancoDados()
        {
            try
            {
                _fornecedores = _fornecedorServico.PegarTodosReloadBancoDados().OrderBy(p => p.Nome).ToList();
                _controleFornecedor.CarregarLista(_fornecedores);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void AtualizarLista(string[] termoParaPesquisar)
        {
            try
            {
                _fornecedores = _fornecedorServico.PegarTodos();
                if (!string.IsNullOrEmpty(termoParaPesquisar[1]))
                    _fornecedores = _fornecedores.Where(f => f.Nome.ToUpper().Contains(termoParaPesquisar[1].ToUpper()))
                    .ToList();
                _fornecedores = _fornecedores.OrderBy(p => p.Nome).ToList();
                _controleFornecedor.CarregarLista(_fornecedores);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public UserControl CarregarListagem()
        {
            if (_controleFornecedor == null)
                _controleFornecedor = new ControleFornecedor();

            return _controleFornecedor;
        }

        public void Editar()
        {
            if (_controleFornecedor.ObterFornecedorSelecionado() == null)
                MessageBox.Show("Precisa selecionar um fornecedor.");

            else
            {
                try
                {
                    _dialogo.novoFornecedor = _controleFornecedor.ObterFornecedorSelecionado();

                    DialogResult resultado = _dialogo.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        _fornecedor = new Fornecedor();
                        _fornecedor = _dialogo.novoFornecedor;
                        _fornecedorServico.Atualizar(_fornecedor);
                        MessageBox.Show("Fornecedor atualizado com sucesso!");
                    }
                    _dialogo.LimparCampos();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Erro");
                    Editar();
                }
            }
        }

        public void Excluir()
        {
            if (_controleFornecedor.ObterFornecedorSelecionado() == null)
                MessageBox.Show("Precisa selecionar um fornecedor.");
            else
            {
                try
                {
                    _fornecedor = _controleFornecedor.ObterFornecedorSelecionado();
                    DialogResult resultado = MessageBox.Show("Confirmar exclusão do fornecedor: \n" + _fornecedor.ToString(), "Excluir Fornecedor", MessageBoxButtons.YesNo);
                    if (resultado == DialogResult.Yes)
                    {
                        _fornecedorServico.Remover(_fornecedor);
                        MessageBox.Show("Fornecedor deletado com sucesso!");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Erro");
                }
            }
        }

        public string ObtemTipoCadastro()
        {
            return "FORNECEDORES";
        }
    }
}
