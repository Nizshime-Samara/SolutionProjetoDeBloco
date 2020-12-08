using Domain.Model.Models;
using Infraestructure.Data.ConfigurationsFluentAPI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
//nota necessário adicionar o SqlToolsDesign, Tools, Server (tanto no projeto executável quanto no Data, onde está o Context) //
//nota 2 setar o comando  add-migration  nome do migration  -project nome do projeto onde se encontra o contexto dá uma garantida também que o migration seja criado no projeto da classe de contexto//
//nota 3 caso haja na solution mais de um dbContext  quando rodar o migration, informar o -context nome do db context a ser migrado //
//nota 4 neste context este Bd recebe o nome de JogoContext-643e6a35- ... , importante destacar para não esquecer , nome dado por default//
namespace Infraestructure.Data.Context
{
    public class JogoContext : DbContext
    {
        public JogoContext(DbContextOptions<JogoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //indicar a fluentAPI  //
        {
            modelBuilder.ApplyConfiguration(new JogadorConfiguration());
            modelBuilder.ApplyConfiguration(new JogosConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Jogador> Jogadores { get; set; }

        public DbSet<Jogo> Jogos { get; set; }

    }
}
