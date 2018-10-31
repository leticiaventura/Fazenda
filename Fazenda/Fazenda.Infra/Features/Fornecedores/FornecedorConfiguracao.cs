using Fazenda.Dominio.Features.Fornecedores;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Infra.Features.Fornecedores
{
    public class FornecedorConfiguracao : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfiguracao()
        {
            ToTable("Fornecedores");
            HasKey(f => f.Id);
            Property(f => f.Nome).HasMaxLength(30).IsRequired();
            Property(f => f.Telefone).HasMaxLength(15).IsOptional();
            Property(f => f.Contato).HasMaxLength(30).IsOptional();
            Property(f => f.Endereco).HasMaxLength(70).IsOptional();
        }
    }
}
