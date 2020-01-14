using Fazenda.Infra.Base;
using Fazenda.Infra.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Infra.Initializer
{
    public class DbInitializer : MigrateDatabaseToLatestVersion<Contexto, Configuration>
    {
    }
}
