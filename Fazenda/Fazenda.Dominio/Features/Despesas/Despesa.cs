using Fazenda.Dominio.Features.Animais;
using Fazenda.Dominio.Features.Fornecedores;
using Fazenda.Dominio.Features.Itens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Despesas
{
    public class Despesa
    {
        public int Id { get; set; }
        public double ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotal { get => Quantidade * ValorUnitario; private set { } }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual Item Item { get; set; }
        public DateTime Data { get; set; }
        public virtual Animal Animal { get; set; }
        public EnumTipoDespesa Tipo { get; set; }

        public void Validar()
        {
            if (ValorUnitario <= 0) throw new DespesaValorUnitarioInvalidoExcecao();
            if (Quantidade <= 0) throw new DespesaQuantidadeInvalidaExcecao();
            if (Item == null) throw new DespesaItemNuloExcecao();
            if (Fornecedor == null) throw new DespesaFornecedorNuloExcecao();
            if (EnumTipoDespesa.CRIACAO == Tipo && Animal == null) throw new DespesaTipoCriacaoSemAnimalExcecao();
            if (EnumTipoDespesa.ESTRUTURA == Tipo && Animal != null) throw new DespesaAnimalInvalidoExcecao();
            if (EnumTipoDespesa.PLANTACAO == Tipo && Animal != null) throw new DespesaAnimalInvalidoExcecao();
        }

        private double CalcularValorTotal() => Quantidade * ValorUnitario;

        public override string ToString()
        {
            string tipo = PegarTipo();
            return string.Format("Tipo: {0} - Fornecedor: {1} - Data: {2} - Item: {3} - Valor Total: R${4:N}", tipo, Fornecedor.Nome, Data.ToShortDateString(), Item.Descricao, ValorTotal);
        }

        public string PegarTipo()
        {
            switch (Tipo)
            {
                case EnumTipoDespesa.CRIACAO: return "Criação";
                case EnumTipoDespesa.PLANTACAO: return "Plantação";
                case EnumTipoDespesa.ESTRUTURA: return "Estrutura";
            }
            return "";
        }
    }
}
