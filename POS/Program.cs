using POS.BLL;
using POS.BOL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS
{
    class Program
    {
        private static PointOfSaleTerminalBs terminal;
        static void Main(string[] args)
        {
            try
            {
                terminal = new PointOfSaleTerminalBs();
                #region set_pricing_of_products
                terminal.SetPricing(new Product { ProductCode = 'A', PerUnit = 1.25m, Volume = 3, VolumePrice = 3 });
                terminal.SetPricing(new Product { ProductCode = 'B', PerUnit = 4.25m, Volume = 0, VolumePrice = 0 });
                terminal.SetPricing(new Product { ProductCode = 'C', PerUnit = 1m, Volume = 6, VolumePrice = 5 });
                terminal.SetPricing(new Product { ProductCode = 'D', PerUnit = 0.75m, Volume = 0, VolumePrice = 0 });
                #endregion

                Console.WriteLine("Welcome to Point of Sale Terminal");

                var end = false;
                while (!end)
                {
                    Console.WriteLine("Press 1 for scan the products" + Environment.NewLine + "Press 2 for recent scanned products with bill" + Environment.NewLine + "Press 3 for exit");
                    var input = Console.ReadLine();

                    var commands = new List<string> { "1", "2", "3" };
                    if (!commands.Contains(input))
                    {
                        input = "0";
                    }

                    switch (Convert.ToInt32(input))
                    {
                        case 1: ScanProduct(); break;
                        case 2: CalculateTotal(); break;
                        case 3: end = true; break;
                        default: Console.WriteLine(Environment.NewLine + "Invalid Command!" + Environment.NewLine); break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ScanProduct()
        {
            terminal.ClearCart();
            Console.WriteLine("Enter the Product's Code");
            char productCode;
            var productCodeList = terminal.GetProductList().Select(x => x.ProductCode).ToList();
            do
            {
                productCode = char.ToUpper(Console.ReadKey().KeyChar);
                if (productCodeList.Contains(productCode))
                    terminal.ScanProduct(productCode);
            }
            while (Convert.ToInt32(productCode) != 13);

            CalculateTotal();
        }

        private static void CalculateTotal()
        {
            Console.WriteLine(Environment.NewLine + "Scanned Product : " + string.Join("", terminal.GetCart().Select(x => x.ProductCode).ToArray()) + Environment.NewLine + "Total : $" + terminal.CalculateTotal() + Environment.NewLine);
        }
    }
}
