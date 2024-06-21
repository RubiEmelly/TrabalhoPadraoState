using Microsoft.EntityFrameworkCore;
using TarefasStatus.Model;
using System.Collections.Generic;
using System.Reflection.Emit;
using TarefasStatus.Model;

namespace TarefasStatus.Data
{
    public class StatusDBContext : DbContext
    {
        public StatusDBContext(DbContextOptions<StatusDBContext> options) : base(options) { }
        public DbSet<TarefasModel> TarefasModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TarefasModel>().Property(t => t.Status);

            base.OnModelCreating(modelBuilder);
        }
    }

    //classe para a conexão com o banco de dados.
}