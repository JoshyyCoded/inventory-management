using System;
using Services;

namespace Views
{
    public class InventoryView
    {
        private InventoryService service;

        public InventoryView()
        {
            service = new InventoryService();
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("--INVENTORY MANAGEMENT--");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. Reset Inventory");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayInv();
                        break;
                    case "2":
                        UpdateStock();
                        break;
                    case "3":
                        service.ResetInv();
                        Console.WriteLine("Inventory has been reset.\n");
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option!\n");
                        break;
                }
            }
        }

        private void DisplayInv()
        {
            var products = service.GetInv();
            Console.WriteLine("\nCurrent Inventory:");
            for (int i = 0; i < products.GetLength(1); i++)
            {
                Console.WriteLine($"{i + 1}. {products[0, i]} - {products[1, i]} pcs");
            }
            Console.WriteLine();
        }

        private void UpdateStock()
        {
            var products = service.GetInv();
            Console.WriteLine("\nSelect product to update:");
            for (int i = 0; i < products.GetLength(1); i++)
            {
                Console.WriteLine($"{i + 1}. {products[0, i]} - {products[1, i]} pcs");
            }

            Console.Write("Enter product number: ");
            if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= products.GetLength(1))
            {
                Console.Write("Enter stock to add: ");
                if (int.TryParse(Console.ReadLine(), out int addedStock) && addedStock >= 0)
                {
                    service.UpdateStock(num - 1, addedStock);
                    Console.WriteLine("Stock updated successfully!\n");
                }
                else
                {
                    Console.WriteLine("Invalid stock quantity!\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid product selection!\n");
            }
        }
    }
}
