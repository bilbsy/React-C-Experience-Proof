﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ChemistWarehouseTechTest.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid PizzeriaId { get; set; }

        [ForeignKey("PizzeriaId")]
        public Pizzeria Pizzeria { get; set; }

        public List<PizzaOrder> PizzaOrders { get; set; }
    }
}
