using System;

namespace Services
{
    public class InventoryService
    {
        private string[,] products;
        private string[,] initialStock;

        public InventoryService()
        {
            products = new string[2, 3]
            {
                { "Apples", "Milk", "Bread" },
                { "10", "5", "20" }
            };

            initialStock = new string[2, 3];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    initialStock[i, j] = products[i, j];
                }
            }
        }

        public string[,] GetInv()
        {
            return products;
        }

        public void UpdateStock(int productIndex, int addedQuantity)
        {
            int currentStock = int.Parse(products[1, productIndex]);
            int updatedStock = currentStock + addedQuantity;
            products[1, productIndex] = updatedStock.ToString();
        }

        public void ResetInv()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    products[i, j] = initialStock[i, j];
                }
            }
        }
    }
}
