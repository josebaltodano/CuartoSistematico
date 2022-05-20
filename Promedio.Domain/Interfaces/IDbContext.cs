using Microsoft.EntityFrameworkCore;
using Promedio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Promedio.Domain.Interfaces
{
     public interface IDbContext
    {
        public DbSet<Estudiante> estudiantes { get; set; }
        public int SaveChanges();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
