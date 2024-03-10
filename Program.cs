using System;

// тут класс продукта
class Product
{
    public int Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    // тут конструктор для инициализации продукта
    public Product(int id, string name, decimal price, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}

// тут класс инвентаря
class Inventory
{
    private Product[] products;

    // тут конструктор для создания инвентаря с заданными продуктами
    public Inventory(Product[] products)
    {
        this.products = products;
    }

    // это метод для вычисления общей стоимости
    public decimal CalculateInventoryValue()
    {
        decimal totalValue = 0;
        foreach (var product in products)
        {
            totalValue += product.Price * product.Quantity;
        }
        return totalValue;
    }

    // это метод для получения максимальной цены
    public decimal GetMaxPrice()
    {
        decimal maxPrice = decimal.MinValue;
        foreach (var product in products)
        {
            if (product.Price > maxPrice)
            {
                maxPrice = product.Price;
            }
        }
        return maxPrice;
    }

    // это метод для получения минимальной цены
    public decimal GetMinPrice()
    {
        decimal minPrice = decimal.MaxValue;
        foreach (var product in products)
        {
            if (product.Price < minPrice)
            {
                minPrice = product.Price;
            }
        }
        return minPrice;
    }

    // это метод для получения средней цены продукта
    public decimal GetAveragePrice()
    {
        decimal sum = 0;
        foreach (var product in products)
        {
            sum += product.Price;
        }
        return sum / products.Length;
    }
}

// Класс для инвентаризации
class ExecutionManager
{
    private Inventory inventory;

    // конструктор 
    public ExecutionManager(Inventory inventory)
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
        // продукты
        Product[] products = {
            new Product(1, "Шоколад", 2.99m, 5),
            new Product(2, "Молоко", 1.49m, 2),
            new Product(3, "Хлеб", 0.99m, 1),
            new Product(4, "Сгущенка",3.40m, 4),
            new Product(5, "Колбаса", 4m,1)
        };

        // инвентарь с этими продуктами
        Inventory inventory = new Inventory(products);

        // менеджер выполнения
        ExecutionManager executionManager = new ExecutionManager(inventory);
        executionManager.ExecuteInventory();
    }
}
