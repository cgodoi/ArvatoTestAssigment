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
    /// CreditCardHelper
    /// </summary>
    public static class CreditCardHelper
    {
        /// <summary>
        /// CardType Enum
        /// </summary>
        public enum CardType
        {
            MasterCard,
            Visa, 
            AmericanExpress, 
            Other
        };

        /// <summary>
        /// get card type from card number
        /// </summary>
        /// <param name="pCardNumber"></param>
        /// <returns></returns>
        public static CardType GetCardType(string pCardNumber)
        {
            //RegExp From https://www.regular-expressions.info/creditcard.html

            try
            {
                if (Regex.Match(pCardNumber, @"^4[0-9]{12}(?:[0-9]{3})?$").Success)
                {
                    return CardType.Visa;
                }

                if (Regex.Match(pCardNumber, @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$").Success)
                {
                    return CardType.MasterCard;
                }

                if (Regex.Match(pCardNumber, @"^3[47][0-9]{13}$").Success)
                {
                    return CardType.AmericanExpress;
                }

            }
            catch (Exception)
            {

                
            }
          
            return CardType.Other;
        }

        /// <summary>
        /// Check Expired issue date
        /// </summary>
        /// <param name="pIssueDate"></param>
        /// <returns></returns>
        public static bool CheckExpiredIssueDate( string pIssueDate)
        {
            try
            {
                var mCurrentDate = DateTime.Now;
                var mChekDate = DateTime.ParseExact(pIssueDate, "MM/yyyy", CultureInfo.InvariantCulture);

                return (mCurrentDate <= mChekDate);            

            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// Check Format Issue Date
        /// </summary>
        /// <param name="pIssueDate"></param>
        /// <returns></returns>
        public static bool CheckFormatIssueDate(string pIssueDate)
        {
            try
            {
                var mChekDate = DateTime.ParseExact(pIssueDate, "MM/yyyy", CultureInfo.InvariantCulture);

                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// Check Cvc Input 
        /// </summary>
        /// <param name="pCreditCard"></param>
        /// <returns></returns>
        public static bool CheckCvcInput(CreditCard pCreditCard)
        {
            try
            {
                var mIsNumeric = int.TryParse(pCreditCard.Cvc, out int n);
                var mLenght = pCreditCard.Cvc.Trim().Length;

                if (mIsNumeric)
                {
                    if (pCreditCard.CardType == CardType.MasterCard.ToString() || pCreditCard.CardType == CardType.Visa.ToString())
                    {
                        return mLenght == 3;
                    }
                    else if (pCreditCard.CardType == CardType.AmericanExpress.ToString())
                    {
                        return mLenght == 4;
                    }
                    else
                    {
                        return false;
                    }

                    
                }
                else
                {
                    return false;
                }


            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
