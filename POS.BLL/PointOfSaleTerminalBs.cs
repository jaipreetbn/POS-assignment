using POS.BOL;
using POS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.BLL
{
    public class PointOfSaleTerminalBs
    {
        private List<Cart> _bag;
        private ProductBs objProductBs;
        public PointOfSaleTerminalBs()
        {
            _bag = new List<Cart>();
            objProductBs = new ProductBs();
        }

        /// <summary>
        /// Sets internal pricing strategy that will be used for calculating totals.
        /// </summary>
        public void SetPricing(Product item)
        {
            objProductBs.AddProduct(item);
        }

        /// <summary>
        /// Stores product code in local state.
        /// </summary>
        public void ScanProduct(char productCode)
        {
            _bag.Add(new Cart { ProductCode = productCode });
        }

        /// <summary>
        /// Calculates total price for all previously scanned products.
        /// </summary>
        /// <returns>Total price</returns>
        public decimal CalculateTotal()
        {
            var bag = _bag.GroupBy(g => g.ProductCode);
            decimal total = 0;

            foreach (var item in bag)
            {
                var productPrice = objProductBs.Get(item.Key);
                var productQty = item.Count();
                if (productPrice != null)
                {
                    if (productPrice.Volume > 0)
                    {
                        var noOfVolume = Math.Round((decimal)(productQty / productPrice.Volume));
                        var noOfUnit = (productQty % productPrice.Volume);
                        total = total + (noOfVolume * productPrice.VolumePrice) + (productPrice.PerUnit * noOfUnit);
                    }
                    else
                    {
                        total = total + (productPrice.PerUnit * productQty);
                    }
                }
            }

            return total;
        }


        public IEnumerable<Product> GetProductList()
        {
            return objProductBs.GetAll();
        }

        public List<Cart> GetCart()
        {
            return _bag;
        }

        public bool ClearCart()
        {
            _bag.Clear();
            return true;
        }

    }
}
