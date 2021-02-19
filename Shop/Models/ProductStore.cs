using System;
using System.Collections.Generic;
using System.Text;
using Shop.Interafaces;
using System.Threading;

namespace Shop.Models
{
    public class ProductStore : IProductStore
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime RemovalTime { get; set; }
        public List<Product> Products = new List<Product>();
        public ProductStore() { }
        public ProductStore(string name, int size,uint id)
        {
            Id = id;
            Name = name;
            Size = size;
            CreationTime = DateTime.Now;
        }

        public void AddProduct(ProductStore productStore)
        {
            int counterId = 0;
            Console.WriteLine("Укажите имя товара:");
            string name = Console.ReadLine();
            int prodSize;
            do
            {
                Console.WriteLine("Укажите размер товара:");
                int size = int.Parse(Console.ReadLine());
                if (productStore.Size > size)
                {
                    productStore.Size -= size;
                    prodSize = size;
                    break;
                }
                else
                {
                    Console.WriteLine($"Недостаточно место для этого товара!\n" +
                        $"Текущий размер ветрины равен {productStore.Size}");
                    Thread.Sleep(3000);
                    Console.Clear();
                }
            } while (true);

            Console.WriteLine("Укажите цену товара:");
            decimal price = decimal.Parse(Console.ReadLine());

            Product product = new Product(counterId,name, prodSize, price);
            Products.Add(product);

            Console.WriteLine($"Товар: {product.Name}, успешо добавлен на прилавок {productStore.Name}");
            Thread.Sleep(3000);
        }

        public void RemoveProduct(ProductStore productStore)
        {
            ShowProducts(productStore);
            Console.WriteLine("\nВыберите Id товара для удаления");
            int number = int.Parse(Console.ReadLine());

            Product product = new Product();
            for (int i = 0; i < Products.Count; i++)
            {
                if (number == Products[i].Id)
                {
                    product = Products[i];
                }
            }
            Products.Remove(product);
            Console.WriteLine($"Продукс: {product.Name} успешно удален из витрины {productStore.Name}");
            productStore.Size += product.OccupiedSize;
            Thread.Sleep(3000);
        }

        public void ShowProducts(ProductStore productStore)
        {
            int counter = 1;
            Console.WriteLine($"Список ассортимента витрины [{productStore.Name}]\n" +
                $"{new string('-',30)}");
            foreach (Product prod in Products)
            {
                Console.WriteLine($"{counter}.[ID {prod.Id}|NAME - {prod.Name}|Size - {prod.OccupiedSize}| Price - {prod.Price:C}]");
                counter++;
            }
        }
    }
}
