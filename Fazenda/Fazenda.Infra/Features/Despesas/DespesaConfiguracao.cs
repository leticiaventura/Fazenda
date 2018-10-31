using Fazenda.Dominio.Features.Despesas;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Infra.Features.Despesas
{
    public class DespesaConfiguracao : EntityTypeConfiguration<Despesa>
    {
        public DespesaConfiguracao()
        {
            ToTable("Despesas");
            HasKey(d => d.Id);
            Property(d => d.Quantidade).IsRequired();
            Property(d => d.ValorUnitario).IsRequired();
            Property(d => d.Data).IsRequired();
            Property(d => d.ValorTotal).IsRequired();
            HasRequired(d => d.Item).WithMany().Map(m => m.MapKey("Item_Id"));
            HasRequired(d => d.Fornecedor).WithMany().Map(m => m.MapKey("Fornecedor_Id"));
            HasOptional(d => d.Animal).WithMany().Map(m => m.MapKey("Animal_Id"));
        }
    }
}
