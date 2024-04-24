using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_Resenas_CQS.Models;

namespace Proyecto_Resenas_CQS.Data
{
    public class Proyecto_Resenas_CQSContext : DbContext
    {
        public Proyecto_Resenas_CQSContext (DbContextOptions<Proyecto_Resenas_CQSContext> options)
            : base(options)
        {
        }

        public DbSet<Proyecto_Resenas_CQS.Models.Resena> Resena { get; set; } = default!;
    }
}
