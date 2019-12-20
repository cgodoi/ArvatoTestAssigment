using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Arvato_Test_assigment.Clases
{
    /// <summary>
    /// Credit Card class
    /// </summary>
    public class CreditCard
    {
        /// <summary>
        /// Card owner
        /// </summary>
        public string  CardOwner { get; set; }

        /// <summary>
        /// Card number 
        /// </summary>
        public string  CardNumber { get; set; }

        /// <summary>
        /// Issue Date MM/YYYY
        /// </summary>
        public string IssueDate { get; set; }

        /// <summary>
        /// Cvc 3/4 digits
        /// </summary>
        public string Cvc { get; set; }

        /// <summary>
        /// Card Type Name
        /// </summary>
        public string CardType
        {
            get
            {
                return CreditCardHelper.GetCardType(this.CardNumber).ToString();
            }
        }
    }

}
