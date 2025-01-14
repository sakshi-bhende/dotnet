using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ProductConsoleApp
{
    public class Product
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            string filePath = "products.json";

            while (true)
            {
                Console.WriteLine("1. Add Product\n2. Save to File\n3. Read from File\n4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct(products);
                        break;
                    case "2":
                        SaveToFile(products, filePath);
                        break;
                    case "3":
                        ReadFromFile(filePath);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddProduct(List<Product> products)
        {
            Console.Write("Enter Product Code: ");
            string productCode = Console.ReadLine();

            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                products.Add(new Product { ProductCode = productCode, Name = name, Price = price });
                Console.WriteLine("Product added successfully.\n");
            }
            else
            {
                Console.WriteLine("Invalid price. Product not added.\n");
            }
        }

        static void SaveToFile(List<Product> products, string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
                Console.WriteLine("Products saved to file successfully.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}\n");
            }
        }

        static void ReadFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    List<Product> products = JsonSerializer.Deserialize<List<Product>>(json);

                    Console.WriteLine("\nProducts from file:");
                    foreach (var product in products)
                    {
                        Console.WriteLine($"Code: {product.ProductCode}, Name: {product.Name}, Price: {product.Price:C}");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("File does not exist.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}\n");
            }
        }
    }
}
