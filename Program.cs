namespace HW_11_Generic_Ivan_Nepo;
using System;
using System.Collections.Generic;

class Product<T>
{
    public int Id { get; }
    public string Name { get; }
    public T Price { get; }
    public int Quantity { get; }

    public Product(int id, string name, T price, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}

class Inventory<T>
{
    private List<Product<T>> products;

    public Inventory(List<Product<T>> products)
    {
        this.products = products;
    }

    public decimal CalculateInventoryValue()
    {
        decimal totalValue = 0;
        foreach (var product in products)
        {
            totalValue += Convert.ToDecimal(product.Price) * product.Quantity;
        }
        return totalValue;
    }

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

class ExecutionManager<T>
{
    private Inventory<T> inventory;

    public ExecutionManager(Inventory<T> inventory)
    {
        this.inventory = inventory;
    }

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
        List<Product<decimal>> products = new List<Product<decimal>> {
            new Product<decimal>(1, "Шоколад", 2.99m, 10),
            new Product<decimal>(2, "Молоко", 1.49m, 20),
            new Product<decimal>(3, "Хлеб", 0.99m, 15)
        };

        Inventory<decimal> inventory = new Inventory<decimal>(products);

        ExecutionManager<decimal> executionManager = new ExecutionManager<decimal>(inventory);
        executionManager.ExecuteInventory();
    }
}
