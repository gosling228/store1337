using System;
using System.Collections.Generic;
using System.Threading;

namespace Sklad
{
    public class Store
    {
        private int productCount;
        private int product = 0;
        private int maxProduct;
        readonly Boolean enabled = true;
        private readonly object Lock = new object();
        readonly Random rng = new Random();
        List<string> products = new List<string>();

        public Store(bool enabled, int product, int maxProduct)
        {
            this.enabled = enabled;
            this.product = product;
            this.maxProduct = maxProduct;
        }

        public void productUp()
        {
            while (enabled)
            {
                if(product <= maxProduct)
                {
                    lock (Lock)
                    {
                        for (int i = 0; i < rng.Next(1, 5); i++)
                        {
                            productCount = rng.Next(1, 6);
                            product += productCount;
                            string productName = "product" + productCount;
                            products.Add(productName);
                            Console.WriteLine("Bring in" + " " + productCount + " " + productName);
                        }
                    }
                    Thread.Sleep(1000);
                }
            }
        }
        public void productDown()
        {
            while (enabled)
            {
                lock (Lock)
                {
                    for(int i=0; i<rng.Next(1, 5); i++)
                    {
                        productCount = rng.Next(1, 6);
                        string productName = "product" + productCount;
                        if (products.Contains(productName) == true)
                        {
                            product -= productCount;
                            products.Remove(productName);
                            Console.WriteLine("Pick up " + " " + productCount + " " + productName);
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }
        public void productMonitor()
        {
            while (enabled)
            {
                lock (Lock)
                {
                    Console.WriteLine("There is " + product + " products in the store");
                }
                Thread.Sleep(2000);
            }
        }
    }
}
