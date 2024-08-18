using AtivosTC5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Data.Mappings
{
    public class PortfolioMap : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.ToTable("PORTFOLIO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
             .ValueGeneratedOnAdd();

            #region Relacionamentos
            builder.HasMany(x => x.portfolioAtivos)
                .WithOne(x => x.portfolio)
                .HasForeignKey(x => x.Portfolio_Id);

            builder.HasOne(x => x.usuario)
                .WithMany(x => x.portfolios)
                .HasForeignKey(x => x.Usuario_Id);
            #endregion


            #region Colunas
            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(p => p.Descricao)
           .HasColumnName("DESCRICAO")
           .HasColumnType("varchar(200)");
            #endregion

        }
    }
}
