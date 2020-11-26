using Models.Models.Base;
using Models.Models.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.Products
{
    public class Product:BaseModel
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public virtual int CategoryId { get; set; }
        public Category Categories { get; set; }
        public virtual int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string BarCode { get; set; }
        public float SalePrice { get; set; }
        public float DealerPrice { get; set; }
        public float CostPrice { get; set; }
        public float DealerCashPrice { get; set; }
        public float DealerDuePrice { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public float OPQty { get; set; }
        public int Purchased { get; set; }
        public int Sold { get; set; }
        public int OnHand { get; set; }
        public bool isActive { get; set; }
        public bool isRow { get; set; }
    }
}
