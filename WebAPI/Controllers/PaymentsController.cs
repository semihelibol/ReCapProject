using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("checkifcreditcard")]
        public IActionResult CheckIfCreditCard(CreditCard creditCard)
        {
            var result = _paymentService.CheckIfCreditCard(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("paybycreditcard")]
        public IActionResult PayByCreditCard(PayByCreditCardDto payByCreditCardDto)
        {
            var result = _paymentService.PayByCreditCard(payByCreditCardDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
