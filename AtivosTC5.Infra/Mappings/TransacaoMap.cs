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
    public class TransacaoMap : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("TRANSACAO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
             .ValueGeneratedOnAdd();

            #region Relacionamentos
            builder.HasOne(x => x.ativo)
                .WithMany(x => x.transacoes)
                .HasForeignKey(x => x.Ativo_Id);

            builder.HasOne(x => x.portfolio)
                .WithMany(x => x.transacoes)
                .HasForeignKey(x => x.Portifolio_Id);
            #endregion


            #region Colunas
            builder.Ignore(p => p.Nome);
                
            builder.Property(p => p.TipoTransacao)
                .HasColumnName("TIPOTRANSACAO")
                .HasColumnType("varchar(20)")
                .IsRequired();
            builder.Property(p => p.Quantidade)
                .HasColumnName("QUANTIDADE")
                .HasColumnType("decimal(20,3)")
                .IsRequired();
            builder.Property(p => p.Preco)
                .HasColumnName("PRECO")
                .HasColumnType("decimal(10,3)")
                .IsRequired();
            builder.Property(p => p.DataTransacao)
                .HasColumnName("DATATRANSACAO")
                .HasColumnType("datetime")
                .IsRequired();
            #endregion
        }
    }
}
