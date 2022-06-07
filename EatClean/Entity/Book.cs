using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EatClean.Entity
{
    public class Book
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Status { get; set; }
        public string Thumbnail { get; set; }
        public string AuthorName { get; set; }
    }
}