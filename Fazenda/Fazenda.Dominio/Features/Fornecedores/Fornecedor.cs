using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Fornecedores
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public void Validar(ICollection<Fornecedor> fornecedores)
        {
            if (string.IsNullOrEmpty(Nome) || Nome.Length > 30) throw new FornecedorNomeInvalidoExcecao();
            if (!string.IsNullOrEmpty(Contato) && Contato.Length > 30) throw new FornecedorContatoInvalidoExcecao();
            if (!string.IsNullOrEmpty(Telefone) && Telefone.Length > 15) throw new FornecedorTelefoneInvalidoExcecao();
            if (!string.IsNullOrEmpty(Endereco) && Endereco.Length > 70) throw new FornecedorEnderecoInvalidoExcecao();
            VerificarFornecedorRedundante(fornecedores);
        }

        private void VerificarFornecedorRedundante(ICollection<Fornecedor> fornecedores)
        {
            foreach (var item in fornecedores)
            {
                if (string.Equals(item.Nome, this.Nome, StringComparison.InvariantCultureIgnoreCase) && item.Id != this.Id) throw new FornecedorNomeRedundandeExcecao();
            }
        }

        public override string ToString()
        {
            return string.Format("{0}", Nome);
        }
    }
}
