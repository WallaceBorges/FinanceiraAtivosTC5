using AtivosTC5.Domain.Entities;
using AtivosTC5.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Contexts
{
    public class SqlServerContext:DbContext
    {
        /// <summary>
        /// Método para definir o caminho do banco de dados (ConnectionString)
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SQL5063.site4now.net;Initial Catalog=db_a92354_apiprodutos;User Id=db_a92354_apiprodutos_admin;Password=coti123456");
        }

        /// <summary>
        /// Método para adicionar as classes de mapeamento do projeto
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtivoMap());
            modelBuilder.ApplyConfiguration(new AtivoTipoMap());
            modelBuilder.ApplyConfiguration(new PortifolioMap());
            modelBuilder.ApplyConfiguration(new TransacaoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }

        /// <summary>
        /// Provedor de métodos para o repositorio (CRUD)
        /// </summary>
        public DbSet<Ativo> Ativo { get; set; }
        public DbSet<AtivoTipo> AtivoTipo { get; set; }
        public DbSet<Portifolio> Portifolio { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
