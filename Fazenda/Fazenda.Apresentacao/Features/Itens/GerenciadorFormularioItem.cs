using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fazenda.Dominio.Features.Itens;


namespace Fazenda.Apresentacao.Features.Produtos
{
    public class GerenciadorFormularioItem : IFormulario
    {
        private Item _item;
        private ControleItem _controleItem;
        private CadastroItemForm _dialogo;
        IItemServico _itemServico;
        ICollection<Item> _itens;

        public GerenciadorFormularioItem(IItemServico itemServico)
        {
            _dialogo = new CadastroItemForm();
            _itemServico = itemServico;
        }

        public void Adicionar()
        {
            try
            {
                DialogResult resultado = _dialogo.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _item = _dialogo.novoItem;
                    _itemServico.Adicionar(_item);
                    MessageBox.Show("Item registrado com sucesso!");
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
                _itens = _itemServico.PegarTodos().OrderBy(p => p.Descricao).ToList();
                _controleItem.CarregarLista(_itens);
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
                _itens = _itemServico.PegarTodosReloadBancoDados().OrderBy(p => p.Descricao).ToList();
                _controleItem.CarregarLista(_itens);
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
                _itens = _itemServico.PegarTodos();
                if (!string.IsNullOrEmpty(termoParaPesquisar[2]))
                    _itens = _itens.Where(i => i.Descricao.ToUpper().Contains(termoParaPesquisar[2].ToUpper())).ToList();
                _itens = _itens.OrderBy(i => i.Descricao).ToList();
                _controleItem.CarregarLista(_itens);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public UserControl CarregarListagem()
        {
            if (_controleItem == null)
                _controleItem = new ControleItem();

            return _controleItem;
        }

        public void Editar()
        {
            if (_controleItem.ObterItemSelecionado() == null)
                MessageBox.Show("Precisa selecionar um item.");

            else
            {
                try
                {
                    _dialogo.novoItem = _controleItem.ObterItemSelecionado();

                    DialogResult resultado = _dialogo.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        _item = new Item();
                        _item = _dialogo.novoItem;
                        _itemServico.Atualizar(_item);
                        MessageBox.Show("Item atualizado com sucesso!");
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
            if (_controleItem.ObterItemSelecionado() == null)
                MessageBox.Show("Precisa selecionar um item.");

            else
            {
                try
                {
                    _item = _controleItem.ObterItemSelecionado();
                    DialogResult resultado = MessageBox.Show("Confirmar exclusão do item: \n" + _item.ToString(), "Excluir Item", MessageBoxButtons.YesNo);
                    if (resultado == DialogResult.Yes)
                    {
                        _itemServico.Remover(_item);
                        MessageBox.Show("Item deletado com sucesso!");
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
            return "ITENS";
        }
    }
}
