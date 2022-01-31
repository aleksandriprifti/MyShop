using System;
using System.Collections.Generic;

namespace MyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ProductBasket> myBasket = new List<ProductBasket>(2);

            List<ShopProducts> products = new List<ShopProducts>();
            products.Add(new ShopProducts() { ProductCode = 101, ProductName = "Qepe", ProductPrice = 100, ProductQuantity = 12 });
            products.Add(new ShopProducts() { ProductCode = 102, ProductName = "Domate", ProductPrice = 200, ProductQuantity = 20 });
            products.Add(new ShopProducts() { ProductCode = 103, ProductName = "Patate", ProductPrice = 200, ProductQuantity = 40 });
            products.Add(new ShopProducts() { ProductCode = 104, ProductName = "Portokall", ProductPrice = 200, ProductQuantity = 50 });
            products.Add(new ShopProducts() { ProductCode = 105, ProductName = "Mandarina", ProductPrice = 200, ProductQuantity = 60 });
            products.Add(new ShopProducts() { ProductCode = 106, ProductName = "Presh", ProductPrice = 200, ProductQuantity = 70 });

            DisplayProducts(products);

            CreateInvoice(products, myBasket);
        }
        /*
         CreateInvoice, realizohen blerjet ne dyqan ne baze te kodit te produktit. Sistem kerkon nga perdoruesi vendosjen e nje kodi te percaktuar ne ProductList dhe 
        ne vijim vendos sasine qe deshirno te bleje. Automatikish List<ProductBasket> myBasket, popullohet me produktet e blera. 

        Line 58, iniciohet metoda DisplayTotalInvoice te ciles i kalojme 2 parametra:
        parameter 1: totalInvoice (vlera totale e fatures)
        parameter 2: List<ProductBasket> myBasket (lista e produkteve te blera)
         */
        private static void CreateInvoice(List<ShopProducts> products, List<ProductBasket> myBasket)
        {
            int totalInvoice = 0;
           

            Console.WriteLine("\nSelect Product Code ore Enter 1 to exit the program:");
            int code = Int32.Parse(Console.ReadLine());
            

            foreach (ShopProducts product in products)
            {
                if (product.ProductCode == code)
                {
                    Console.WriteLine($"Product Name {product.ProductName}");
                    
                    Console.WriteLine("\nSelect Product Quantity:");
                    
                    int kg = Int32.Parse(Console.ReadLine());
                    Console.WriteLine($"Product Quantity: {kg}");
                    myBasket.Add(new ProductBasket() {ProductName = product.ProductName, ProductPrice = product.ProductPrice, ProductQuantity = kg, TotalValue = kg * product.ProductPrice});
                    Console.WriteLine("\nSelect another product Code ore Enter 1 to exit the program:");
                    totalInvoice += product.ProductPrice * kg;

                   
                    code = Int32.Parse(Console.ReadLine());
                }
                
            }
            DisplayTotalInvoice(totalInvoice, myBasket);
            
        }

        /*
          DisplayTotalInvoice, shfaqan faturen totale te blerjeve ne dyqan. Permban te gjitha produktet e blera si dhe shumen totale te fature. 
         */
        private static void DisplayTotalInvoice(int totalInvoice, List<ProductBasket> myBasket)
        {
            int invoiceWidht = 67;
            int dateWidth = 22;
           
            Console.WriteLine(new string('-', invoiceWidht));

            Console.WriteLine($"{new String('-', dateWidth)} {DateTime.Now} {new String('-', dateWidth)}");
            
            Console.WriteLine("Product Name   Product Price   Product Quantity               Value");
            foreach (ProductBasket basket in myBasket)
            {
                Console.WriteLine(String.Format("{0,9} {1,15} {2,18}  {3, 20}", basket.ProductName, basket.ProductPrice, basket.ProductQuantity, basket.TotalValue));
            }

            Console.WriteLine(new string('-', invoiceWidht));
            Console.WriteLine($"The total value of invoice is: {totalInvoice}");
        }
        /*
        metoda DisplayProducts(), shfaqe produktet e dyqanit ose me mire inventarin aktual te dyqanit. Eshte perdorur
        nje List class collection, e tipit ShopProducts ne te cilen listohen te gjitha produktet e dyqanit. 
        Kjo metode ben vetem paraqitjen grafike te produkteve. 
         */
        public static void DisplayProducts(List<ShopProducts> products)
        {
            int tableWidth = 80;

            Console.WriteLine("Product List - MyShop");
            Console.WriteLine(new string('-', tableWidth));


            
          
            Console.WriteLine("Product Code      Product name     Product Price - All     Product Quantity - kg");
            foreach (ShopProducts product in products)
            {
                Console.WriteLine( String.Format("{0,9}|{1,15}|{2,22}| {3, 28}", product.ProductCode, product.ProductName, product.ProductPrice, product.ProductQuantity));
            }
        }
    }
     
    
}