using Fazenda.Dominio.Features.Itens;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Infra.Features.Itens
{
    public class ItemConfiguracao : EntityTypeConfiguration<Item>
    {
        public ItemConfiguracao()
        {
            ToTable("Item");
            HasKey(i => i.Id);
            Property(i => i.Descricao).HasMaxLength(70).IsRequired();
            Property(i => i.Unidade).IsOptional();
        }
    }
}
