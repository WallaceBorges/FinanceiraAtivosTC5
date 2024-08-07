using AtivosTC5.Domain.Entities;
using AtivosTC5.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Data.Contexts
{
    public class SqlServerContext:DbContext
    {
        /// <summary>
        /// Método para definir o caminho do banco de dados (ConnectionString)
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AtivosTC5;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        /// <summary>
        /// Método para adicionar as classes de mapeamento do projeto
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerContext).Assembly);
            //modelBuilder.ApplyConfiguration(new AtivoMap());
            //modelBuilder.ApplyConfiguration(new AtivoTipoMap());
            //modelBuilder.ApplyConfiguration(new PortifolioMap());
            //modelBuilder.ApplyConfiguration(new TransacaoMap());
            //modelBuilder.ApplyConfiguration(new UsuarioMap());
        }

        /// <summary>
        /// Provedor de métodos para o repositorio (CRUD)
        /// </summary>
        public DbSet<Ativo> Ativo { get; set; }
        public DbSet<AtivoTipo> AtivoTipo { get; set; }
        public DbSet<Portfolio> Portifolio { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
