using AtivosTC5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Mappings
{
    public class PortifolioMap : IEntityTypeConfiguration<Portifolio>
    {
        public void Configure(EntityTypeBuilder<Portifolio> builder)
        {
            throw new NotImplementedException();
        }
    }
}
