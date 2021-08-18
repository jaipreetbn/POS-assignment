using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BOL.Interface
{
    public interface IProduct : IPrice
    {
        /// <summary>
        /// Product Code
        /// </summary>
        public char ProductCode { get; set; }

    }
}
