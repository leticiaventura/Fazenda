using Fazenda.Aplicacao.Features.Animais;
using Fazenda.Aplicacao.Features.Despesas;
using Fazenda.Aplicacao.Features.Fornecedores;
using Fazenda.Aplicacao.Features.Itens;
using Fazenda.Apresentacao.Features.Animais;
using Fazenda.Apresentacao.Features.Despesas;
using Fazenda.Apresentacao.Features.Fornecedores;
using Fazenda.Apresentacao.Features.Produtos;
using Fazenda.Dominio.Features.Animais;
using Fazenda.Dominio.Features.Despesas;
using Fazenda.Dominio.Features.Fornecedores;
using Fazenda.Dominio.Features.Itens;
using Fazenda.Infra.Base;
using Fazenda.Infra.Features.Animais;
using Fazenda.Infra.Features.Despesas;
using Fazenda.Infra.Features.Fornecedores;
using Fazenda.Infra.Features.Itens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fazenda.Apresentacao
{
    public partial class Form1 : Form
    {
        private IFormulario _gerenciador;

        private IAnimalRepositorio _animalRepositorio;
        private IAnimalServico _animalServico;

        private IItemRepositorio _itemRepositorio;
        private IItemServico _itemServico;

        private IFornecedorRepositorio _fornecedorRepositorio;
        private IFornecedorServico _fornecedorServico;

        private IDespesaRepositorio _despesaRepositorio;
        private IDespesaServico _despesaServico;

        /// <summary>
        /// Elementos:
        /// 0 -> Data;
        /// 1 -> Fornecedor;
        /// 2 -> Item;
        /// 3 -> Tipo;
        /// 4 -> Animal;
        /// </summary>
        private string[] termosPesquisa = { "", "", "", "", ""};

        public Form1()
        {
            InitializeComponent();
            Contexto contexto = new Contexto();

            _animalRepositorio = new AnimalRepositorio(contexto);
            _animalServico = new AnimalServico(_animalRepositorio);

            _itemRepositorio = new ItemRepositorio(contexto);
            _itemServico = new ItemServico(_itemRepositorio);

            _fornecedorRepositorio = new FornecedorRepositorio(contexto);
            _fornecedorServico = new FornecedorServico(_fornecedorRepositorio);

            _despesaRepositorio = new DespesaRepositorio(contexto);
            _despesaServico = new DespesaServico(_despesaRepositorio);
        }

        private void CarregarCadastro(IFormulario gerenciador)
        {
            _gerenciador = gerenciador;
            lblContexto.Text = _gerenciador.ObtemTipoCadastro();
            UserControl listagem = _gerenciador.CarregarListagem();
            listagem.Dock = DockStyle.Fill;
            panel.Controls.Clear();
            panel.Controls.Add(listagem);
            toolStrip1.Enabled = true;
            LimparCampos();
            _gerenciador.AtualizarLista();
            if (_gerenciador is IFormularioDespesa)
                groupOperacoes.Visible = true;
            else groupOperacoes.Visible = false;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            _gerenciador.Adicionar();
            _gerenciador.AtualizarListaReloadBancoDados();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            _gerenciador.Editar();
            _gerenciador.AtualizarListaReloadBancoDados();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            _gerenciador.Excluir();
            _gerenciador.AtualizarLista();
        }


        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (_gerenciador is IFormularioDespesa)
                (_gerenciador as IFormularioDespesa).Exportar();
        }

        private void FecharFormsAbertos()
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex >= 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
        }

        #region Carregar Cadastros

        private void cadastrarItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenciadorFormularioItem item = new GerenciadorFormularioItem(_itemServico);
            CarregarCadastro(item);
            HabilitarBotoesItem();
            FecharFormsAbertos();
        }

        private void cadastrarFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenciadorFormularioFornecedor fornecedor = new GerenciadorFormularioFornecedor(_fornecedorServico);
            CarregarCadastro(fornecedor);
            HabilitarBotoesFornecedor();
            FecharFormsAbertos();
        }

        private void cadastrarAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenciadorFormularioAnimal animal = new GerenciadorFormularioAnimal(_animalServico);
            CarregarCadastro(animal);
            HabilitarBotoesAnimal();
            FecharFormsAbertos();
        }

        private void historicoDeDespesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenciadorFormularioDespesa despesa = new GerenciadorFormularioDespesa(_animalServico, _itemServico, _fornecedorServico, _despesaServico);
            CarregarCadastro(despesa);
            HabilitarBotoesDespesa();
            FecharFormsAbertos();
        }
        #endregion

        #region Habilitar Botões
        private void HabilitarBotoesDespesa()
        {
            //botões
            btnCadastrar.Enabled = true;
            btnCadastrar.Text = "Incluir";
            btnEditar.Enabled = true;
            btnRemover.Enabled = true;
            btnExportar.Enabled = true;
            btnExportar.Visible = true;
            btnPesquisar.Enabled = true;

            //textBox
            txtData.Enabled = true;
            txtAnimal.Enabled = true;
            txtFornecedor.Enabled = true;
            txtItem.Enabled = true;
            txtTipo.Enabled = true;
        }

        private void HabilitarBotoesFornecedor()
        {
            //botões
            btnCadastrar.Enabled = true;
            btnCadastrar.Text = "Cadastrar";
            btnEditar.Enabled = true;
            btnRemover.Enabled = true;
            btnExportar.Enabled = false;
            btnExportar.Visible = false;
            btnPesquisar.Enabled = true;

            //textBox
            txtData.Enabled = false;
            txtAnimal.Enabled = false;
            txtFornecedor.Enabled = true;
            txtItem.Enabled = false;
            txtTipo.Enabled = false;
        }


        private void HabilitarBotoesAnimal()
        {
            //botões
            btnCadastrar.Enabled = true;
            btnCadastrar.Text = "Cadastrar";
            btnEditar.Enabled = true;
            btnRemover.Enabled = true;
            btnExportar.Enabled = false;
            btnExportar.Visible = false;
            btnPesquisar.Enabled = true;

            //textBox
            txtData.Enabled = false;
            txtAnimal.Enabled = true;
            txtFornecedor.Enabled = false;
            txtItem.Enabled = false;
            txtTipo.Enabled = false;
        }

        private void HabilitarBotoesItem()
        {
            //botões
            btnCadastrar.Enabled = true;
            btnCadastrar.Text = "Cadastrar";
            btnEditar.Enabled = true;
            btnRemover.Enabled = true;
            btnExportar.Enabled = false;
            btnExportar.Visible = false;
            btnPesquisar.Enabled = true;

            //textBox
            txtData.Enabled = false;
            txtAnimal.Enabled = false;
            txtFornecedor.Enabled = false;
            txtItem.Enabled = true;
            txtTipo.Enabled = false;
        }

        #endregion

        private void LimparCampos()
        {
            txtAnimal.ResetText();
            txtData.ResetText();
            txtItem.ResetText();
            txtTipo.ResetText();
            txtFornecedor.ResetText();
            termosPesquisa = new string[5];
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            termosPesquisa[0] = txtData.Text;
            termosPesquisa[1] = txtFornecedor.Text;
            termosPesquisa[2] = txtItem.Text;
            termosPesquisa[3] = txtTipo.Text;
            termosPesquisa[4] = txtAnimal.Text;
            _gerenciador.AtualizarLista(termosPesquisa);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (_gerenciador is IFormularioDespesa)
            {
                lblSoma.Text = ((_gerenciador as IFormularioDespesa).CalcularSomaDespesas()).ToString("n2");
            }
               
        }
    }
}
