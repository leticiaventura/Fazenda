using Fazenda.Dominio.Features.Animais;
using Fazenda.Dominio.Features.Despesas;
using Fazenda.Dominio.Features.Fornecedores;
using Fazenda.Dominio.Features.Itens;
using Fazenda.Infra.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fazenda.Apresentacao.Features.Despesas
{
    public class GerenciadorFormularioDespesa : IFormularioDespesa
    {
        private Despesa _despesa;
        private ControleDespesa _controleDespesa;
        private CadastroDespesaForm _dialogo;
        IDespesaServico _despesaServico;
        ICollection<Despesa> _despesas;

        public GerenciadorFormularioDespesa(IAnimalServico animalServico, IItemServico itemServico, IFornecedorServico fornecedorServico, IDespesaServico despesaServico)
        {
            _dialogo = new CadastroDespesaForm(animalServico, itemServico, fornecedorServico, despesaServico);
            _despesaServico = despesaServico;
        }

        public void Adicionar()
        {
            try
            {
                DialogResult resultado = _dialogo.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _despesa = _dialogo.novaDespesa;
                    _despesaServico.Adicionar(_despesa);
                    MessageBox.Show("Despesa registrada com sucesso!");
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
                _despesas = _despesaServico.PegarTodos().OrderBy(p => p.Data).Reverse().ToList();
                _controleDespesa.CarregarListaDespesa(_despesas);
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
                _despesas = _despesaServico.PegarTodosReloadBancoDados().OrderBy(p => p.Data).Reverse().ToList();
                _controleDespesa.CarregarListaDespesa(_despesas);
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
                _despesas = _despesaServico.PegarTodos();
                if (!string.IsNullOrEmpty(termoParaPesquisar[0]))
                    _despesas = _despesas.Where(d => d.Data.ToShortDateString().Contains(termoParaPesquisar[0])).ToList();
                if (!string.IsNullOrEmpty(termoParaPesquisar[1]))
                    _despesas = _despesas.Where(d => d.Fornecedor.Nome.ToUpper().Contains(termoParaPesquisar[1].ToUpper())).ToList();
                if (!string.IsNullOrEmpty(termoParaPesquisar[2]))
                    _despesas = _despesas.Where(d => d.Item.Descricao.ToUpper().Contains(termoParaPesquisar[2].ToUpper())).ToList();
                if (!string.IsNullOrEmpty(termoParaPesquisar[3]))
                    _despesas = _despesas.Where(d => d.PegarTipo().ToUpper().Contains(termoParaPesquisar[3].ToUpper())).ToList();
                if (!string.IsNullOrEmpty(termoParaPesquisar[4]))
                    _despesas = _despesas.Where(d => d.Tipo == EnumTipoDespesa.CRIACAO && d.Animal.Especie.ToUpper().Contains(termoParaPesquisar[4].ToUpper())).ToList();
                _despesas = _despesas.OrderBy(d => d.Data).Reverse().ToList();
                _controleDespesa.CarregarListaDespesa(_despesas);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public UserControl CarregarListagem()
        {
            if (_controleDespesa == null)
                _controleDespesa = new ControleDespesa();

            return _controleDespesa;
        }

        public void Editar()
        {
            if (_controleDespesa.ObterDespesaSelecionada() == null)
                MessageBox.Show("Precisa selecionar um despesa.");

            else
            {
                try
                {
                    _dialogo.novaDespesa = _controleDespesa.ObterDespesaSelecionada();

                    DialogResult resultado = _dialogo.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        _despesa = _dialogo.novaDespesa;
                        _despesaServico.Atualizar(_despesa);
                        MessageBox.Show("Despesa atualizada com sucesso!");
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

            if (_controleDespesa.ObterDespesaSelecionada() == null)
                MessageBox.Show("Precisa selecionar um despesa.");

            else
            {
                try
                {

                    _despesa = _controleDespesa.ObterDespesaSelecionada();
                    DialogResult resultado = MessageBox.Show("Confirmar exclusão da despesa: \n" + _despesa.ToString(), "Excluir Despesa", MessageBoxButtons.YesNo);
                    if (resultado == DialogResult.Yes)
                    {
                        _despesaServico.Remover(_despesa);
                        MessageBox.Show("Despesa deletada com sucesso!");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Erro");
                }
            }

        }

        public void Exportar()
        {
            if (_despesas != null && _despesas.Count() > 0)
            {
                SaveFileDialog dialogo = new SaveFileDialog();
                dialogo.FileName = string.Format("Relatório {0}-{1}-{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
                dialogo.Filter = "Excel (*.xls)|*.xls| Todos (*.*)|*.*";
                dialogo.FilterIndex = 1;
                dialogo.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    ExportadorXLS.ExportarListaDeDespesas(_despesas, dialogo.FileName);
                    MessageBox.Show("Exportado com sucesso.");
                }
            }
            else
            {
                MessageBox.Show("A lista está vazia.");
            }
        }

        public string ObtemTipoCadastro()
        {
            return "DESPESAS";
        }

        public double CalcularSomaDespesas()
        {
            double soma = 0;
            foreach (var item in _despesas)
            {
                soma += item.ValorTotal;
            }
            return soma;
        }
    }
}
