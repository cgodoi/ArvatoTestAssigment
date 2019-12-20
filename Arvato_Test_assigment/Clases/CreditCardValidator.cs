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
    /// CreditCard Validator Fluent
    /// </summary>
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        /// <summary>
        /// CreditCard Validator Ctor
        /// </summary>
        public CreditCardValidator()
        {
            RuleFor(x => x.CardOwner).NotNull();
            RuleFor(x => x.CardOwner).NotEmpty();
            RuleFor(x => x.CardNumber).NotNull();
            RuleFor(x => x.CardNumber).NotEmpty();
            RuleFor(x => x.IssueDate).NotNull();
            RuleFor(x => x.IssueDate).NotEmpty();
            RuleFor(x => x.Cvc).NotNull();
            RuleFor(x => x.Cvc).NotEmpty();
            RuleFor(x => x).Must(ValidCvc).WithMessage("Not a valid cvc code (3 or 4 numbers and valid card number)");
            RuleFor(x => x.CardNumber).Must(ValidCardType).WithMessage("Not a valid card type (Mastercard, Visa, American Express)");
            RuleFor(x => x.IssueDate).Must(ValidIssueDateFormat).WithMessage("Not valid issue date format (MM/YYYY)");
            RuleFor(x => x.IssueDate).Must(ValidIssueDate).WithMessage("Not valid issue date, card already expired");

        }

        private bool ValidCardType(string pCardNumber)
        {
            return CreditCardHelper.GetCardType(pCardNumber) != CreditCardHelper.CardType.Other;
        }

        private bool ValidIssueDate(string pIssueDate)
        {
            return CreditCardHelper.CheckExpiredIssueDate(pIssueDate);
        }

        private bool ValidIssueDateFormat(string pIssueDate)
        {
            return CreditCardHelper.CheckFormatIssueDate(pIssueDate);
        }

        private bool ValidCvc(CreditCard pCreditCard)
        {
            return CreditCardHelper.CheckCvcInput(pCreditCard);
        }
    }

}
