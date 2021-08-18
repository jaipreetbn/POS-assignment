using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BOL.Interface
{
    public interface IPrice
    {
        /// <summary>
        /// Price of unit
        /// </summary>
        decimal PerUnit { get; set; }

        /// <summary>
        /// Bulk quantity threshold at which the special price applies
        /// </summary>
        int Volume { get; set; }

        /// <summary>
        /// Special price for bulk threshold
        /// </summary>
        decimal VolumePrice { get; set; }
    }
}
