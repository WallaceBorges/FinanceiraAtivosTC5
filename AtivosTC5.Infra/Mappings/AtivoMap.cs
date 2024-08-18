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
    public class AtivoMap : IEntityTypeConfiguration<Ativo>
    {
        public void Configure(EntityTypeBuilder<Ativo> builder)
        {
            builder.ToTable("ATIVO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
             .ValueGeneratedOnAdd();

            builder.Property(u => u.Nome)
                .HasMaxLength(150)
                .IsRequired();

            #region Relacionamentos
            builder.HasOne(a => a.ativoTipo)
                .WithMany(t => t.ativos)
                .HasForeignKey(a => a.AtivoTipo_Id);
            #endregion

            #region Colunas
            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(p => p.Sigla)
                .HasColumnName("SIGLA")
                .HasColumnType("varchar(10)")
                .IsRequired();


            #endregion
            builder.HasData(
                             new Ativo {Id = 1, Nome = "Real", Sigla = "BRL", AtivoTipo_Id = 3 },
                             new Ativo {Id = 2,Nome = "Dólar Americano", Sigla = "USD", AtivoTipo_Id = 3 },
                             new Ativo {Id = 3,Nome = "Dólar Canadense", Sigla = "CAD", AtivoTipo_Id = 3 },
                             new Ativo {Id = 4,Nome = "Libra Esterlina", Sigla = "GBP", AtivoTipo_Id = 3 },
                             new Ativo {Id = 5,Nome = "Euro", Sigla = "EUR", AtivoTipo_Id = 3 },
                             new Ativo {Id = 6,Nome = "Iene Japonês", Sigla = "JPY", AtivoTipo_Id = 3 },
                             new Ativo {Id = 7,Nome = "Franco Suíço", Sigla = "CHF", AtivoTipo_Id = 3 },
                             new Ativo {Id = 8,Nome = "Bitcoin", Sigla = "BTC", AtivoTipo_Id = 2 },
                             new Ativo {Id = 9,Nome = "Ethereum", Sigla = "ETH", AtivoTipo_Id = 2 },
                             new Ativo {Id = 10,Nome = "Litecoin", Sigla = "LTC", AtivoTipo_Id = 2 },
                             new Ativo {Id = 11,Nome = "Ripple", Sigla = "XRP", AtivoTipo_Id = 2 },
                             new Ativo {Id = 12,Nome = "Cardano", Sigla = "ADA", AtivoTipo_Id = 2 },
                             new Ativo {Id = 13,Nome = "Binance Coin", Sigla = "BNB", AtivoTipo_Id = 2 },
                             new Ativo {Id = 14,Nome = "DogeCoin", Sigla = "DOGE", AtivoTipo_Id = 2 },
                             new Ativo {Id = 15,Nome = "Shiba Inu", Sigla = "SHIB", AtivoTipo_Id = 2 },
                             new Ativo {Id = 16,Nome = "ALLIANÇA SAÚDE E PARTICIPAÇÕES S.A.", Sigla = "AALR3", AtivoTipo_Id = 1 },
                             new Ativo {Id = 17,Nome = "AMBEV S.A.", Sigla = "ABEV3", AtivoTipo_Id = 1 },
                             new Ativo {Id = 18,Nome = "CAMIL ALIMENTOS S.A.", Sigla = "CAML3", AtivoTipo_Id = 1 },
                             new Ativo {Id = 19,Nome = "ITAUSA S.A.", Sigla = "ITSA3", AtivoTipo_Id = 1 },
                             new Ativo {Id = 20,Nome = "PETROLEO BRASILEIRO S.A. PETROBRAS", Sigla = "PETW3", AtivoTipo_Id = 1 },
                             new Ativo {Id = 21,Nome = "PETROLEO BRASILEIRO S.A. PETROBRAS", Sigla = "PETW4", AtivoTipo_Id = 1 },
                             new Ativo {Id = 22,Nome = "NTN-B - 02/2030 - BRSTNCNTB4J9", Sigla = "NTN-B", AtivoTipo_Id = 4 },
                             new Ativo {Id = 23,Nome = "NBCE - 05/2003 - BRBCBRNBC592", Sigla = "NBCE", AtivoTipo_Id = 4 },
                             new Ativo { Id = 24, Nome = "LFT-B - 09/2004 - BRSTNCLF1KR7", Sigla = "LFT-b", AtivoTipo_Id = 4 }
        );



        }
    }
}
