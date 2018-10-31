using Fazenda.Dominio.Features.Animais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fazenda.Apresentacao.Features.Animais
{
    public partial class CadastroAnimalForm : Form
    {
        public CadastroAnimalForm()
        {
            InitializeComponent();
            _Animal = new Animal();
        }

        private Animal _Animal;
        public Animal novoAnimal
        {
            get
            {
                _Animal.Especie = txtEspecie.Text;
                return _Animal;
            }
            set
            {
                _Animal = value;
                txtEspecie.Text = _Animal.Especie;
            }
        }

        public void LimparCampos()
        {
            txtEspecie.ResetText();
        }
    }
}
