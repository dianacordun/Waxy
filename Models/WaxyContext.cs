using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waxy.Models.Entities;

namespace Waxy.Entities
{
    public class WaxyContext : DbContext
    {
        public WaxyContext(DbContextOptions<WaxyContext> options) : base(options) { }

        public DbSet<Candle> Candles { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<CandleIngredient> CandleIngredients{ get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Creator> Creators { get;  set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to Many Container-Candle
            modelBuilder.Entity<Container>()
                .HasMany(a => a.Candles)
                .WithOne(b => b.Container);

            //One to One Container-Label
            modelBuilder.Entity<Container>()
                .HasOne(c => c.Label)
                .WithOne(l => l.Container);

            //Many to Many Candle-Ingredients
            modelBuilder.Entity<CandleIngredient>().HasKey(ci => new { ci.CandleId, ci.IngredientId });

            modelBuilder.Entity<CandleIngredient>()
                .HasOne(ci => ci.Candle)
                .WithMany(c => c.CandleIngredients)
                .HasForeignKey(ci => ci.CandleId);

            modelBuilder.Entity<CandleIngredient>()
                .HasOne(ci => ci.Ingredient)
                .WithMany(i => i.CandleIngredients)
                .HasForeignKey(ci => ci.IngredientId);

            //One to Many Label-Creator
            modelBuilder.Entity<Creator>()
               .HasMany(c => c.Labels)
               .WithOne(l => l.Creator);


            base.OnModelCreating(modelBuilder);

            
        }
    }
}
