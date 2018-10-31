using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fazenda.Dominio.Features.Fornecedores;

namespace Fazenda.Apresentacao.Features.Fornecedores
{
    public partial class ControleFornecedor : UserControl
    {
        public ControleFornecedor()
        {
            InitializeComponent();
        }

        public void CarregarLista(ICollection<Fornecedor> fornecedores)
        {
            dataGridView1.DataSource = fornecedores;
            dataGridView1.Columns["Id"].Visible = false;

            dataGridView1.Columns["Nome"].DisplayIndex = 1;
            dataGridView1.Columns["Telefone"].DisplayIndex = 2;
            dataGridView1.Columns["Contato"].DisplayIndex = 3;
            dataGridView1.Columns["Endereco"].DisplayIndex = 4;
            dataGridView1.Columns["Endereco"].HeaderText = "Endereço";

        }

        public Fornecedor ObterFornecedorSelecionado() => (dataGridView1.CurrentRow != null) ? (Fornecedor)dataGridView1.CurrentRow.DataBoundItem : null;
    }
}
