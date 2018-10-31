using Fazenda.Dominio.Features.Fornecedores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fazenda.Apresentacao.Features.Fornecedores
{
    public partial class CadastrarFornecedorForm : Form
    {
        public CadastrarFornecedorForm()
        {
            InitializeComponent();
            _fornecedor = new Fornecedor();
        }

        private Fornecedor _fornecedor;
        public Fornecedor novoFornecedor
        {
            get
            {
                _fornecedor.Contato = txtContato.Text;
                _fornecedor.Endereco = txtEndereco.Text;
                _fornecedor.Nome = txtNome.Text;
                _fornecedor.Telefone = txtTelefone.Text;
                return _fornecedor;
            }
            set
            {
                _fornecedor = value;
                txtNome.Text = _fornecedor.Nome;
                txtTelefone.Text = _fornecedor.Telefone;
                txtContato.Text = _fornecedor.Contato;
                txtEndereco.Text = _fornecedor.Endereco;
            }
        }

        public void LimparCampos()
        {
            txtNome.ResetText();
            txtTelefone.ResetText();
            txtContato.ResetText();
            txtEndereco.ResetText();
        }
    }
}
