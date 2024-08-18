using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.ValueObjects;
using AtivosTC5.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Data.Contexts
{
    public partial class SqlServerContext : DbContext
    {
        public SqlServerContext():base()
        {
        }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }

        /// <summary>
        /// Método para definir o caminho do banco de dados (ConnectionString)
        /// </summary>

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AtivosTC5");

        /// <summary>
        /// Método para adicionar as classes de mapeamento do projeto
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerContext).Assembly);
        }

        /// <summary>
        /// Provedor de métodos para o repositorio (CRUD)
        /// </summary>
        public virtual DbSet<Ativo> Ativo { get; set; }
        public virtual DbSet<AtivoTipo> AtivoTipo { get; set; }
        public virtual DbSet<Portfolio> Portifolio { get; set; }
        public virtual DbSet<PortfolioAtivo> PortfolioAtivos { get; set; }
        public virtual DbSet<Transacao> Transacao { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

    }
}
