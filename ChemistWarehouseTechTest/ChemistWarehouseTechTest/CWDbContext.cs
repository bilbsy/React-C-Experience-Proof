﻿using ChemistWarehouseTechTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ChemistWarehouseTechTest
{
    public class CWDbContext : DbContext
    {
        public CWDbContext(DbContextOptions<CWDbContext> options) : base(options) { }

        public DbSet<Pizzeria> Pizzerias { get; set; }

        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<PizzaOrder> PizzaOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizzeria>().HasKey(_ => _.Id);

            modelBuilder.Entity<Pizza>().HasKey(_ => _.Id);
            modelBuilder.Entity<Pizza>().Property(_ => _.Toppings)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

            var prestonPizzeria = new Pizzeria()
            {
                Id = Guid.NewGuid(),
                Name = "Preston Pizzeria",
                Location = "Preston",
            };

            var southbankPizzeria = new Pizzeria()
            {
                Id = Guid.NewGuid(),
                Name = "Southbank Pizzeria",
                Location = "Southbank"
            };

            modelBuilder.Entity<Pizzeria>().HasData(
                prestonPizzeria,
                southbankPizzeria            
            );

            modelBuilder.Entity<Pizza>().HasData(
                    new Pizza()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Capricciosa",
                        Toppings = new List<string>() { "Cheese", "Ham", "Mushrooms", "Olives" },
                        Price = 20,
                        PizzeriaId = prestonPizzeria.Id
                    },
                    new Pizza()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Mexicana",
                        Toppings = new List<string>() { "Cheese", "Salami", "Capiscum", "Chilli" },
                        Price = 18,
                        PizzeriaId = prestonPizzeria.Id
                    },
                    new Pizza()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Margherita",
                        Toppings = new List<string>() { "Cheese", "Spinach", "Ricotta", "Cherry Tomatoes" },
                        Price = 22,
                        PizzeriaId = prestonPizzeria.Id
                    },
                    new Pizza()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Capricciosa",
                        Toppings = new List<string>() { "Cheese", "Ham", "Mushrooms", "Olives" },
                        Price = 20,
                        PizzeriaId = southbankPizzeria.Id
                    },
                    new Pizza()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Vegetarian",
                        Toppings = new List<string>() { "Cheese", "Mushrooms", "Capiscum", "Onion", "Olives" },
                        Price = 17,
                        PizzeriaId = southbankPizzeria.Id
                    }
                );
        }
    }
}
