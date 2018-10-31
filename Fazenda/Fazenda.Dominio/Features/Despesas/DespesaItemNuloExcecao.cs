using Fazenda.Dominio.Excecoes;
using System;
using System.Runtime.Serialization;

namespace Fazenda.Dominio.Features.Despesas
{
    internal class DespesaItemNuloExcecao : ExcecaoNegocio
    {
        public DespesaItemNuloExcecao() : base("A despesa deve ter um Item")
        {
        }
    }
}