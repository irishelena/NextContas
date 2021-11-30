using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextConta.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            InicializaBD.Initialize(this);
        }

        public DbSet<Nova_conta> Nova_Contas { get; set; }
        public DbSet<Novo_Grupo> Novo_Grupos { get; set; }

        

    }
}
