using Domain.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.ConfigurationsFluentAPI
{
    class JogosConfiguration : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder
               .HasOne(x => x.Jogador)
                .WithMany(x => x.Jogos);
        }
    }
}
