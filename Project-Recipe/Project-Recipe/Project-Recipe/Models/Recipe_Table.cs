using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Project_Recipe.Models
{
    public class Recipe_Table
{
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string CreatedBy { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
    }


}