using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Data.Mappings
{
    public class PortfolioAtivoMap : IEntityTypeConfiguration<PortfolioAtivo>
    {
        public void Configure(EntityTypeBuilder<PortfolioAtivo> builder)
        {
            builder.ToTable("PORTFOLIOATIVO");

            builder.HasKey(x => new { x.Portfolio_Id, x.Ativo_Id });
            #region Relacionamentos
            builder.HasOne(x => x.portfolio)
                .WithMany(x => x.portfolioAtivos)
                .HasForeignKey(x => x.Portfolio_Id);

            builder.HasOne(x => x.ativo)
                .WithMany(x => x.portfolioAtivos)
                .HasForeignKey(x => x.Ativo_Id);
            #endregion

            #region Colunas
            builder.Property(p => p.Quantidade)
                 .HasColumnName("QUANTIDADE")
                 .HasColumnType("decimal(20,3)")
                 .IsRequired();
            builder.Property(p => p.Preco)
                .HasColumnName("PRECO")
                .HasColumnType("decimal(10,3)")
                .IsRequired();
            #endregion

        }
    }
}
