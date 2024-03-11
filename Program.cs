namespace HW_11_generic;
using System;
using System.Collections.Generic;

// Обобщенный класс продукта
class Product<T>
{
    public int Id { get; }
    public string Name { get; }
    public T Price { get; }
    public int Quantity { get; }

    // Конструктор для инициализации продукта
    public Product(int id, string name, T price, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}

// Обобщенный класс инвентаря
class Inventory<T>
{
    private List<Product<T>> products;

    // Конструктор для создания инвентаря с заданными продуктами
    public Inventory(List<Product<T>> products)
    {
        this.products = products;
    }

    // Метод для вычисления общей стоимости инвентаря
    public decimal CalculateInventoryValue()
    {
        decimal totalValue = 0;
        foreach (var product in products)
        {
            totalValue += Convert.ToDecimal(product.Price) * product.Quantity;
        }
        return totalValue;
    }

    // Метод для получения максимальной цены продукта
    public T GetMaxPrice()
    {
        T maxPrice = default(T);
        foreach (var product in products)
        {
            if (Convert.ToDecimal(product.Price) > Convert.ToDecimal(maxPrice))
            {
                maxPrice = product.Price;
            }
        }
        return maxPrice;
    }

    // Метод для получения минимальной цены продукта
    public T GetMinPrice()
    {
        T minPrice = default(T);
        foreach (var product in products)
        {
            if (Convert.ToDecimal(product.Price) < Convert.ToDecimal(minPrice))
            {
                minPrice = product.Price;
            }
        }
        return minPrice;
    }

    // Метод для получения средней цены продукта
    public decimal GetAveragePrice()
    {
        decimal sum = 0;
        foreach (var product in products)
        {
            sum += Convert.ToDecimal(product.Price);
        }
        return sum / products.Count;
    }
}

// Класс для выполнения инвентаризации
class ExecutionManager<T>
{
    private Inventory<T> inventory;

    // Конструктор для инициализации инвентаря
    public ExecutionManager(Inventory<T> inventory)
    {
        this.inventory = inventory;
    }

    // Метод для проведения инвентаризации и вывода результата
    public void ExecuteInventory()
    {
        Console.WriteLine($"Общая стоимость инвентаря: {inventory.CalculateInventoryValue():C}");
        Console.WriteLine($"Максимальная цена продукта: {inventory.GetMaxPrice():C}");
        Console.WriteLine($"Минимальная цена продукта: {inventory.GetMinPrice():C}");
        Console.WriteLine($"Средняя цена продукта: {inventory.GetAveragePrice():C}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем несколько продуктов
        List<Product<decimal>> products = new List<Product<decimal>> {
            new Product<decimal>(1, "Шоколад", 2.99m, 10),
            new Product<decimal>(2, "Молоко", 1.49m, 20),
            new Product<decimal>(3, "Хлеб", 0.99m, 15)
        };

        // Создаем инвентарь с этими продуктами
        Inventory<decimal> inventory = new Inventory<decimal>(products);

        // Создаем менеджер выполнения и проводим инвентаризацию
        ExecutionManager<decimal> executionManager = new ExecutionManager<decimal>(inventory);
        executionManager.ExecuteInventory();
    }
}
