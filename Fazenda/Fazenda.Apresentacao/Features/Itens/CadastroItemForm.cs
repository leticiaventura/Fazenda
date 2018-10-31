using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fazenda.Dominio.Features.Itens;


namespace Fazenda.Apresentacao.Features.Produtos
{
    public partial class CadastroItemForm : Form
    {
        public CadastroItemForm()
        {
            InitializeComponent();
            _item = new Item();
        }

        private Item _item;
        public Item novoItem
        {
            get
            {
                _item.Descricao = txtDescricao.Text;
                _item.Unidade = txtUnidade.Text;
                return _item;
            }
            set
            {
                _item = value;
                txtDescricao.Text = _item.Descricao;
                txtUnidade.Text = _item.Unidade;
            }
        }

        public void LimparCampos()
        {
            txtDescricao.ResetText();
            txtUnidade.ResetText();
        }

    }
}
