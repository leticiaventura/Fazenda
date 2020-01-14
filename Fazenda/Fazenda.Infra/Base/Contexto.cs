using Fazenda.Dominio.Features.Animais;
using Fazenda.Dominio.Features.Despesas;
using Fazenda.Dominio.Features.Itens;
using Fazenda.Dominio.Features.Fornecedores;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fazenda.Infra.Features.Animais;
using Fazenda.Infra.Features.Despesas;
using Fazenda.Infra.Features.Fornecedores;
using Fazenda.Infra.Features.Itens;
using Fazenda.Infra.Initializer;

namespace Fazenda.Infra.Base
{
    public class Contexto : DbContext
    {
        public Contexto() : base("DBFazenda")
        {
            Database.SetInitializer(new DbInitializer());
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Animal> Animais { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modeloCriador)
        {
            modeloCriador.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modeloCriador.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modeloCriador.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modeloCriador.Configurations.Add(new AnimalConfiguracao());
            modeloCriador.Configurations.Add(new DespesaConfiguracao());
            modeloCriador.Configurations.Add(new FornecedorConfiguracao());
            modeloCriador.Configurations.Add(new ItemConfiguracao());
        }
    }
}
