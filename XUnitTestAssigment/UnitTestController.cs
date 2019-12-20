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
    public class UnitTestController
    {
        [Fact]
        public void ValidMasterCardTest()
        {

            // Arrange
            var mLogger = Mock.Of<ILogger<CreditCardValidatorController>>();

            var mController = new CreditCardValidatorController(mLogger);

            var mCreditCard = new CreditCard
            {
                CardOwner = "Claudio Godoi",
                CardNumber = "5555555555554444",
                IssueDate = "11/2020",
                Cvc = "123"
            };

            var mValidator = new CreditCardValidator();

            var mValResult = mValidator.Validate(mCreditCard);

            Assert.True(mValResult.IsValid);

            IActionResult mActionResult =   mController.Post(mCreditCard);

            // Assert
            Assert.NotNull(mActionResult);
            OkObjectResult mResult = mActionResult as OkObjectResult;
            Assert.NotNull(mResult);

            var mResponse = mResult.Value as CreditCardApiResponse;

            Assert.Equal(CreditCardHelper.CardType.MasterCard.ToString(), mResponse.CreditCardType);

        }


        [Fact]
        public void ValidVisaCardTest()
        {

            // Arrange
            var mLogger = Mock.Of<ILogger<CreditCardValidatorController>>();

            var mController = new CreditCardValidatorController(mLogger);

            var mCreditCard = new CreditCard
            {
                CardOwner = "Claudio Godoi",
                CardNumber = "4111111111111111",
                IssueDate = "11/2020",
                Cvc = "123"
            };

            var mValidator = new CreditCardValidator();

            var mValResult = mValidator.Validate(mCreditCard);

            Assert.True(mValResult.IsValid);

            IActionResult mActionResult = mController.Post(mCreditCard);

            // Assert
            Assert.NotNull(mActionResult);
            OkObjectResult mResult = mActionResult as OkObjectResult;
            Assert.NotNull(mResult);

            var mResponse = mResult.Value as CreditCardApiResponse;

            Assert.Equal(CreditCardHelper.CardType.Visa.ToString(), mResponse.CreditCardType);

        }

        [Fact]
        public void ValidAmericanExpressTest()
        {

            // Arrange
            var mLogger = Mock.Of<ILogger<CreditCardValidatorController>>();

            var mController = new CreditCardValidatorController(mLogger);

            var mCreditCard = new CreditCard
            {
                CardOwner = "Claudio Godoi",
                CardNumber = "378282246310005",
                IssueDate = "11/2020",
                Cvc = "1234"
            };



            IActionResult mActionResult = mController.Post(mCreditCard);

            // Assert
            Assert.NotNull(mActionResult);
            OkObjectResult mResult = mActionResult as OkObjectResult;
            Assert.NotNull(mResult);

            var mResponse = mResult.Value as CreditCardApiResponse;

            Assert.Equal(CreditCardHelper.CardType.AmericanExpress.ToString(), mResponse.CreditCardType);

        }



        [Fact]
        public void NoValidAmericanExpressTest()
        {
            var mValidator = new CreditCardValidator();

            var mCreditCard = new CreditCard
            {
                CardOwner = "Claudio Godoi",
                CardNumber = "378282246310005",
                IssueDate = "11/2020",
                Cvc = "123"
            };

            var mValResult = mValidator.Validate(mCreditCard);

            Assert.False(mValResult.IsValid);

        }

        [Fact]
        public void NoValidVisaTest()
        {
            var mValidator = new CreditCardValidator();

            var mCreditCard = new CreditCard
            {
                CardOwner = "Claudio Godoi",
                CardNumber = "4111111111111111",
                IssueDate = "11/2020",
                Cvc = "1236"
            };

            var mValResult = mValidator.Validate(mCreditCard);

            Assert.False(mValResult.IsValid);

        }


        [Fact]
        public void NoValidMasterCardTest()
        {
            var mValidator = new CreditCardValidator();

            var mCreditCard = new CreditCard
            {
                CardOwner = "Claudio Godoi",
                CardNumber = "5555555555554444",
                IssueDate = "11/2020",
                Cvc = "1235"
            };

            var mValResult = mValidator.Validate(mCreditCard);

            Assert.False(mValResult.IsValid);

        }

    }
}
