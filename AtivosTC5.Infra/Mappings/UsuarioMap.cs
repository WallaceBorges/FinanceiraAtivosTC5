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
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
             .ValueGeneratedOnAdd();

            builder.Ignore(x => x.AccessToken);
                
            #region Colunas
            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasColumnType("varchar(300)")
                .IsRequired();
            builder.Property(p => p.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(200)")
                .IsRequired();
            #endregion
        }
    }
}
