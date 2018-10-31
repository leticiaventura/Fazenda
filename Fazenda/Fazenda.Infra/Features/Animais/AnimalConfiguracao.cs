using Fazenda.Dominio.Features.Animais;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Infra.Features.Animais
{
    public class AnimalConfiguracao : EntityTypeConfiguration<Animal>
    {
        public AnimalConfiguracao()
        {
            ToTable("Animais");
            HasKey(a => a.Id);
            Property(a => a.Especie).HasMaxLength(20).IsRequired();
        }

    }
}
