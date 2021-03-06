﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public enum Namegroup
    {
        IronBeton = 0,
        AsphaltBeton = 1,
        KeramzBeton = 2
    }
    public class Product
    {
        [Key]
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Namegroup NameGroup { get; set; }
        public virtual ICollection<Purchase> purch { get; set; }

        public Product()
        {
            purch = new List<Purchase>();
        }
        public int Count { get; set; }
    }
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        public string Fio { get; set; }
        public int Price { get; set; }
        public int Counttovar { get; set; }
        public DateTime Date { get; set; }
        public int? IdProduct { get; set; }
        public virtual Product prod { get; set; }
    }
}
