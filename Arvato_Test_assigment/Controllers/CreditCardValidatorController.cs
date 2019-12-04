using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arvato_Test_assigment.Clases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Arvato_Test_assigment
{
    /// <summary>
    /// CreditCardValidator Controller Class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardValidatorController : ControllerBase
    {

        private readonly ILogger<CreditCardValidatorController> _logger;

        /// <summary>
        /// CreditCardValidatorController constructor
        /// </summary>
        /// <param name="logger"></param>
        public CreditCardValidatorController(ILogger<CreditCardValidatorController> logger)
        {
            _logger = logger;
        }
        
        /// <summary>
        /// Post api/CreditCardValidator
        /// </summary>
        /// <param name="pCreditCard"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] CreditCard pCreditCard)
      {
            var mCreditCardApiResponse = new CreditCardApiResponse();
            try
            {
                //Get CardType
                _logger.LogInformation("Enter CreditCardValidatorController Post Method", pCreditCard);
                mCreditCardApiResponse.CreditCardType = pCreditCard.CardType;

            }
            catch (Exception e)
            {
                _logger.LogError(e, "CreditCardValidatorController", pCreditCard);
                return StatusCode(500);
            }



            return Ok(mCreditCardApiResponse);

        }

        

    }
}
