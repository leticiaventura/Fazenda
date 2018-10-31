using Fazenda.Dominio.Features.Animais;
using Fazenda.Dominio.Features.Despesas;
using Fazenda.Dominio.Features.Fornecedores;
using Fazenda.Dominio.Features.Itens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fazenda.Apresentacao.Features.Despesas
{
    public partial class CadastroDespesaForm : Form
    {
        private IAnimalServico _animalServico;
        private IItemServico _itemServico;
        private IFornecedorServico _fornecedorServico;
        private IDespesaServico _despesaServico;

        public CadastroDespesaForm(IAnimalServico animalServico, IItemServico itemServico, IFornecedorServico fornecedorServico, IDespesaServico despesaServico)
        {
            InitializeComponent();

            _despesa = new Despesa();

            _animalServico = animalServico;
            _itemServico = itemServico;
            _fornecedorServico = fornecedorServico;
            _despesaServico = despesaServico;

            numQuantidade.ResetText();
            numValorUnitario.ResetText();
            CarregarCmbAnimal();
            CarregarCmbFornecedor();
            CarregarCmbItens();
        }

        private Despesa _despesa;
        public Despesa novaDespesa
        {
            get
            {
                _despesa.Tipo = PegarTipoDespesa();

                if (_despesa.Tipo == EnumTipoDespesa.CRIACAO)
                    _despesa.Animal = (Animal)cmbAnimal.SelectedItem;
                else _despesa.Animal = null;

                _despesa.Data = datePicker.Value;
                _despesa.Fornecedor = (Fornecedor)cmbFornecedor.SelectedItem;
                _despesa.Item = (Item)cmbItens.SelectedItem;
                _despesa.Quantidade = Convert.ToDouble(numQuantidade.Value);
                _despesa.ValorUnitario = Convert.ToDouble(numValorUnitario.Text);
                return _despesa;
            }
            set
            {
                _despesa = value;
                SetarRadioButton();
                if (_despesa.Tipo == EnumTipoDespesa.CRIACAO)
                    cmbAnimal.SelectedItem = _despesa.Animal;
                datePicker.Value = _despesa.Data;
                cmbFornecedor.SelectedItem = _despesa.Fornecedor;
                cmbItens.SelectedItem = _despesa.Item;
                numQuantidade.Value = Convert.ToDecimal(_despesa.Quantidade);
                numValorUnitario.Text = Convert.ToString(_despesa.ValorUnitario);
            }
        }

        internal void LimparCampos()
        {
            numQuantidade.ResetText();
            numValorUnitario.ResetText();
            CarregarCmbAnimal();
            cmbAnimal.ResetText();
            CarregarCmbFornecedor();
            cmbFornecedor.ResetText();
            CarregarCmbItens();
            cmbItens.ResetText();
            datePicker.Value = DateTime.Now;
            numQuantidade.Value = 0;
            radioCriacao.Checked = true;
        }

        private void SetarRadioButton()
        {
            switch (_despesa.Tipo)
            {
                case EnumTipoDespesa.CRIACAO:
                    radioCriacao.Checked = true;
                    break;
                case EnumTipoDespesa.PLANTACAO:
                    radioPlantacao.Checked = true;
                    break;
                case EnumTipoDespesa.ESTRUTURA:
                    radioEstrutura.Checked = true;
                    break;
            }
        }
        private EnumTipoDespesa PegarTipoDespesa()
        {
            if (radioCriacao.Checked == true)
            {
                return EnumTipoDespesa.CRIACAO;
            }
            else if (radioEstrutura.Checked == true)
            {
                return EnumTipoDespesa.ESTRUTURA;
            }
            else
            {
                return EnumTipoDespesa.PLANTACAO;
            }
        }


        private void radioCriacao_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCriacao.Checked == true)
            {
                cmbAnimal.Visible = true;
                lblAnimal.Visible = true;
            }
            else
            {
                cmbAnimal.Visible = false;
                lblAnimal.Visible = false;
            }
        }

        #region Carregar ComboBoxes

        private void CarregarCmbAnimal()
        {
            var animais = _animalServico.PegarTodos().OrderBy(a => a.Especie);
            cmbAnimal.Items.Clear();
            foreach (var item in animais)
            {
                cmbAnimal.Items.Add(item);
            }
        }

        private void CarregarCmbAnimalComFiltro()
        {
            var animais = _animalServico.PegarTodos().Where(a => a.Especie.ToUpper().Contains(cmbAnimal.Text.ToUpper())).OrderBy(a => a.Especie);
            cmbAnimal.Items.Clear();
            foreach (var item in animais)
            {
                cmbAnimal.Items.Add(item);
            }
        }

        private void CarregarCmbItens()
        {
            var itens = _itemServico.PegarTodos().OrderBy(i => i.Descricao);
            cmbItens.Items.Clear();
            foreach (var item in itens)
            {
                cmbItens.Items.Add(item);
            }
        }

        private void CarregarCmbItensComFiltro()
        {
            var itens = _itemServico.PegarTodos().Where(i => i.Descricao.ToUpper().Contains(cmbItens.Text.ToUpper())).OrderBy(i => i.Descricao);
            cmbItens.Items.Clear();
            foreach (var item in itens)
            {
                cmbItens.Items.Add(item);
            }
        }

        private void CarregarCmbFornecedor()
        {
            var fornecedores = _fornecedorServico.PegarTodos().OrderBy(f => f.Nome);
            cmbFornecedor.Items.Clear();
            foreach (var item in fornecedores)
            {
                cmbFornecedor.Items.Add(item);
            }
        }

        private void CarregarCmbFornecedorComFiltro()
        {
            var fornecedores = _fornecedorServico.PegarTodos().Where(f => f.Nome.ToUpper().Contains(cmbFornecedor.Text.ToUpper())).OrderBy(f => f.Nome);
            cmbFornecedor.Items.Clear();
            foreach (var item in fornecedores)
            {
                cmbFornecedor.Items.Add(item);
            }
        }
        #endregion

        #region Imprimir valor total


        private void numQuantidade_ValueChanged(object sender, EventArgs e)
        {
            ImprimirValorTotal();
        }
        private void numValorUnitario_ValueChanged(object sender, EventArgs e)
        {
            ImprimirValorTotal();
        }

        private void ImprimirValorTotal()
        {
            txtValorTotal.Text = (numValorUnitario.Value * numQuantidade.Value).ToString("n2");
        }
        #endregion

        #region Filtros dos comboboxes
        private void cmbItens_DropDown(object sender, EventArgs e)
        {
            if (cmbItens.SelectedItem == null)
                CarregarCmbItensComFiltro();
            else
                CarregarCmbItens();
        }

        private void cmbAnimal_DropDown(object sender, EventArgs e)
        {
            if (cmbAnimal.SelectedItem == null)
                CarregarCmbAnimalComFiltro();
            else
                CarregarCmbAnimal();
        }

        private void cmbFornecedor_DropDown(object sender, EventArgs e)
        {
            if (cmbFornecedor.SelectedItem == null)
                CarregarCmbFornecedorComFiltro();
            else
                CarregarCmbFornecedor();
        }
        #endregion

    }
}
