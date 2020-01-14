using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Infra.Base
{
    public class DbContextFactory : IDbContextFactory<Contexto>
    {
        public Contexto Create()
        {
            return new Contexto();
        }
    }
}
