using Arvato_Test_assigment;
using Arvato_Test_assigment.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace XUnitTestAssigment
{
    public class UnitTestValidator
    {

        [Fact]
        public void NoCardInfoTest()
        {
            var mValidator = new CreditCardValidator();
            var mCreditCard = new CreditCard();

            var mValResult = mValidator.Validate(mCreditCard);
            Assert.False(mValResult.IsValid);
            Assert.Contains(mValResult.Errors, x => x.PropertyName == "CardOwner");
            Assert.Contains(mValResult.Errors, x => x.PropertyName == "IssueDate");
            Assert.Contains(mValResult.Errors, x => x.PropertyName == "Cvc");
            Assert.Contains(mValResult.Errors, x => x.PropertyName == "CardNumber");

        }
    }
}
