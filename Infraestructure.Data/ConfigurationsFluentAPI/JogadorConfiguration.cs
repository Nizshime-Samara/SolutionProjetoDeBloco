using Domain.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.ConfigurationsFluentAPI
{
    class JogadorConfiguration : IEntityTypeConfiguration<Jogador>
    {
        public void Configure(EntityTypeBuilder<Jogador> builder)
        {
            builder
               .HasMany(x => x.Jogos)
               .WithOne(x => x.Jogador);

            builder
                .Property(x => x.Nome)
                .HasMaxLength(50);
        }
    }
}
