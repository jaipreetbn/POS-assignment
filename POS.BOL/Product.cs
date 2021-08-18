using POS.BOL.Interface;
using System;

namespace POS.BOL
{
    public class Product : IProduct
    {
        public Product()
        {

        }

        /// <summary>
        /// Product Code
        /// </summary>
        public char ProductCode { get; set; }

        /// <summary>
        /// Price of one Unit
        /// </summary>
        public decimal PerUnit { get; set; }

        /// <summary>
        /// Bulk quantity threshold at which the special price applies.
        /// </summary>
        public int Volume { get; set; }

        /// <summary>
        /// Special price for bulk threshold.
        /// </summary>
        public decimal VolumePrice { get; set; }
    }
}
