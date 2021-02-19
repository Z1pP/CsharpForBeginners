using System;
using System.Collections.Generic;
using System.Text;
using Shop.Models;
using Shop.Interafaces;
using System.Threading;

namespace Shop
{
    public class StartProgram
    {
        public Thread Thread;
        public ConsoleKeyInfo keyInfo;
        public List<ProductStore> productStores;
        public uint IdForShowWindow = 3;
        public void Start()
        {
            //Дефолтное добавление витрин в магазин

            productStores = new List<ProductStore>
            {
                new ProductStore("Игрушки для взрослых", 20,0),
                new ProductStore("Латексные изделия", 50,1),
                new ProductStore("Костюмы для ролевых игр",35,2)
            };

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Выберите необходимую операцию\n" +
                    "\t[1] ----> Создать новую витрину с названием и объемом\n" +
                    "\t[2] ----> Отредактировать витрину\n" +
                    "\t[3] ----> Удалить витрину\n" +
                    "\t[4] ----> Добавить товар в существующую витрину\n" +
                    "\t[ESCAPE] ----> Выход\n");

                keyInfo = Console.ReadKey(true);
                Console.Clear();
                switch (keyInfo.KeyChar)
                {
                    case '1': //Создать новую ветрину 
                        ProductStore productStore = CreateProductStore();
                        productStores.Add(productStore);
                        IdForShowWindow++;
                        break;
                    case '2':
                        EditProductStore(productStores);
                        break;
                    case '3':
                        RemoveProductStore(productStores);
                        break;
                    case '4':
                        ActionWithProductStore(productStores);
                        break;
                    case (char)ConsoleKey.Escape:
                        flag = false;
                        break;
                }
                Console.Clear();
            }
        }

        //Создание витрины
        public ProductStore CreateProductStore()
        {
            Console.Write("Введите имя витрины --> ");
            string name = Console.ReadLine();
            Console.Write("Введите размер витрины --> ");
            int size = int.Parse(Console.ReadLine());
            return new ProductStore(name, size, IdForShowWindow);
        }

        //Вывод списка витрин в консоль
        public void ShowProductStores(List<ProductStore> productStores)
        {
            int counter = 1;
            Console.WriteLine("Список доступных витрин: ");
            foreach (ProductStore showWindow in productStores)
            {
                Console.WriteLine($"{counter}.[ID {showWindow.Id}|NAME - {showWindow.Name}|Size - {showWindow.Size}| CreateTime - {showWindow.CreationTime}]");
                counter++;
            }
        }

        //Редактирование витрины
        public void EditProductStore(List<ProductStore> productStores)
        {
            ShowProductStores(productStores);
            Console.WriteLine("\nВыберите Id витрины для редактирования");
            int number = int.Parse(Console.ReadLine());

            ProductStore store = new ProductStore();

            for (int i = 0; i < productStores.Count; i++)
            {
                if (number == productStores[i].Id)
                {
                    store = productStores[i];
                    break;
                }
            }

            do
            {
                Console.WriteLine("Укажите новый размер для данной витрины");
                number = int.Parse(Console.ReadLine());

                if (store.Products != null || store.Size < number)
                {
                    store.Size = number;
                    Console.WriteLine($"На витрине - {store.Name}, установлен новый размер {store.Size}");
                    break;
                }
                else
                {
                    Console.WriteLine($"Ошибка..\n" +
                        $"Указанный размер {number} меньше нынешнего размера {store.Size} на {store.Size - number}");
                }
            } while (true);
            Thread.Sleep(3000);
        }

        //Удаление витрины
        public void RemoveProductStore(List<ProductStore> productStores)
        {
            ShowProductStores(productStores);
            Console.WriteLine("\nВыберите Id витрины для удаления");
            int number = int.Parse(Console.ReadLine());

            ProductStore store = new ProductStore();
            for (int i = 0; i < productStores.Count; i++)
            {
                if (number == productStores[i].Id)
                {
                    store = productStores[i];
                }
            }

            if (store != null)
            {
                productStores.Remove(store);
                Console.WriteLine($"Витрина - {store.Name}, успешно удалена!");
            }
            else
            {
                Console.WriteLine($"Ошибка..\n" +
                        $"Витрина [{store.Name}] не очищена и имеет в себе товары");

            }
            Thread.Sleep(3000);
        }

        //Действия с витриной
        public void ActionWithProductStore(List<ProductStore> productStores)
        {
            ShowProductStores(productStores);
            Console.WriteLine("\nВыберите Id витрины для для добавления товаров");
            int number = int.Parse(Console.ReadLine());

            ProductStore store = new ProductStore();
            for (int i = 0; i < productStores.Count; i++)
            {
                if (number == productStores[i].Id)
                {
                    store = productStores[i];
                }
            }
            Console.Clear();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine($"[ID {store.Id}|NAME - {store.Name}|Size - {store.Size}| CreateTime - {store.CreationTime}]");

                Console.WriteLine("Выберите необходимую операцию\n" +
                    "\t[1] ----> Добавить товар на прилавок\n" +
                    "\t[2] ----> Удалить товар с прилавка\n" +
                    "\t[3] ----> Посмотреть содержимое прилавка\n" +
                    "\t[4] ----> Вернуться на главную\n");

                keyInfo = Console.ReadKey(true);
                Console.Clear();
                switch (keyInfo.KeyChar)
                {
                    case '1': //
                        store.AddProduct(store);
                        break;
                    case '2':
                        store.RemoveProduct(store);
                        break;
                    case '3':
                        store.ShowProducts(store);
                        break;
                    case '4':
                        flag = false;
                        break;
                }
                Console.Clear();
            }
        }
    }
}
