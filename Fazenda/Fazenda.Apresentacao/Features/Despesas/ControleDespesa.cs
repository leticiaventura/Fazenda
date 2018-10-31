using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fazenda.Dominio.Features.Despesas;

namespace Fazenda.Apresentacao.Features.Despesas
{
    public partial class ControleDespesa : UserControl
    {
        public ControleDespesa()
        {
            InitializeComponent();
        }

        public void CarregarListaDespesa(ICollection<Despesa> despesas)
        {
            dataGridView1.DataSource = despesas;
            dataGridView1.Columns["Id"].Visible = false;
            
            dataGridView1.Columns["Data"].DisplayIndex = 1;
            dataGridView1.Columns["Fornecedor"].DisplayIndex = 2;
            dataGridView1.Columns["Item"].DisplayIndex = 3;
            dataGridView1.Columns["ValorUnitario"].DisplayIndex = 4;
            dataGridView1.Columns["ValorUnitario"].HeaderText = "Valor Unitário";
            dataGridView1.Columns["Quantidade"].DisplayIndex = 5;
            dataGridView1.Columns["ValorTotal"].DisplayIndex = 6;
            dataGridView1.Columns["ValorTotal"].HeaderText = "Valor Total";
            dataGridView1.Columns["Animal"].DisplayIndex = 7;
        }

        public Despesa ObterDespesaSelecionada() => (dataGridView1.CurrentRow != null) ? (Despesa)dataGridView1.CurrentRow.DataBoundItem : null;
    }
}
