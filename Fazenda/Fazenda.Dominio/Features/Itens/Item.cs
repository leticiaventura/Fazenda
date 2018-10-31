using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Itens
{
    public class Item
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }

        public void Validar(ICollection<Item> itens)
        {
            if (string.IsNullOrEmpty(Descricao) || Descricao.Length > 70) throw new ItemDescricaoInvalidaExcecao();
            VerificarFornecedorRedundante(itens);
        }

        private void VerificarFornecedorRedundante(ICollection<Item> itens)
        {
            foreach (var item in itens)
            {
                if (string.Equals(item.Descricao, this.Descricao, StringComparison.InvariantCultureIgnoreCase)
                    && string.Equals(item.Unidade, this.Unidade, StringComparison.InvariantCultureIgnoreCase) 
                    && item.Id != this.Id) throw new ItemDescricaoUnidadeReduntanteExcecao();
            }
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Unidade)) return string.Format("{0}", Descricao);
            return string.Format("{0} ({1})", Descricao, Unidade);
        }
    }
}
