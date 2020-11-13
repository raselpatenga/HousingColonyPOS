using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingColonyPOS.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual Group Group { get; set; }
        public int GroupId { get; set; }
    }
}
