using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fazenda.Dominio.Features.Itens;

namespace Fazenda.Apresentacao.Features.Produtos
{
    public partial class ControleItem : UserControl
    {
        public ControleItem()
        {
            InitializeComponent();
        }

        public void CarregarLista(ICollection<Item> itens)
        {
            dataGridView1.DataSource = itens;
            dataGridView1.Columns["Id"].Visible = false;

            dataGridView1.Columns["Descricao"].DisplayIndex = 1;
            dataGridView1.Columns["Descricao"].HeaderText = "Descrição";
            dataGridView1.Columns["Unidade"].DisplayIndex = 2;
        }

        public Item ObterItemSelecionado() => (dataGridView1.CurrentRow != null) ? (Item)dataGridView1.CurrentRow.DataBoundItem : null;
    }
}
