using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fazenda.Dominio.Features.Animais;

namespace Fazenda.Apresentacao.Features.Animais
{
    public partial class ControleAnimal : UserControl
    {
        public ControleAnimal()
        {
            InitializeComponent();
        }

        public void CarregarLista(ICollection<Animal> animais)
        {
            dataGridView1.DataSource = animais;
            dataGridView1.Columns["Id"].Visible = false;

            dataGridView1.Columns["Especie"].HeaderText = "Espécie";
        }

        public Animal ObterAnimalSelecionado() =>  (dataGridView1.CurrentRow != null) ? (Animal)dataGridView1.CurrentRow.DataBoundItem : null;
    }
}
