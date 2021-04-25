using System;
using System.Collections.Generic;
using System.Threading;

namespace Sklad
{
    class main
    {
        static void Main(string[] args)
        {
            int maxProduct = 20;
            Store store = new Store(true, 0, maxProduct);
            Thread thproductUp = new Thread(new ThreadStart(store.productUp));
            Thread thproductDown = new Thread(new ThreadStart(store.productDown));
            Thread thproductMonitor = new Thread(new ThreadStart(store.productMonitor));
            thproductUp.Start();
            thproductDown.Start();
            thproductMonitor.Start();
        }
    }
}

  