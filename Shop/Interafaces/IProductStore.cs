using System;
using System.Collections.Generic;
using System.Text;
using Shop.Models;
namespace Shop.Interafaces
{
    interface IProductStore
    {
         uint Id { get; set; }
         string Name { get; set; }
         int Size { get; set; }
         DateTime CreationTime { get; set; }
         DateTime RemovalTime { get; set; }


        void ShowProducts(ProductStore productStore);
        void AddProduct(ProductStore productStore);
        void RemoveProduct(ProductStore productStore);
        
    }
}
