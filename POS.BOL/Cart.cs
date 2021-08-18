using POS.BOL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BOL
{
    public class Cart : ICart
    {
        /// <summary>
        /// Product Code
        /// </summary>
        public char ProductCode { get; set; }
    }
}
