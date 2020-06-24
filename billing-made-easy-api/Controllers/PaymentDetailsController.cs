
using System.Collections.Generic;
using System.Threading.Tasks;
using billing_made_easy_api.Services.Interfaces;
using billing_made_easy_api.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace billing_made_easy_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class PaymentDetailsController : ControllerBase
    {
        private IPaymentDetailsService _paymentDetailsService;
        public PaymentDetailsController(IPaymentDetailsService paymentDetailsService)
        {
            _paymentDetailsService = paymentDetailsService;
        }
        [HttpPost]
        public async Task<IActionResult> AddPaymentDetails(PaymentDetailsVM paymentDetails)
        {
            await _paymentDetailsService.AddPaymentDetails(paymentDetails);
            var lastInsertedPaymentId = _paymentDetailsService.FetchRecentPaymentId();
            return Ok(lastInsertedPaymentId);
        }
        [HttpGet]
        public async Task<IEnumerable<PaymentDetailsVM>> FetchAllPaymentDetails()
        {
            return await _paymentDetailsService.FetchAllPaymentDetails();
        }
        [HttpGet("paymentId")]
        public async Task<PaymentDetailsVM> FetchPaymentDetailsById(int paymentId)
        {
            return await _paymentDetailsService.FetchPaymentDetails(paymentId);
        }

        [HttpPut]
        public void UpdatePaymentDetails(PaymentDetailsVM paymentDetails)
        {
            _paymentDetailsService.UpdatePaymentDetails(paymentDetails);
        }
    }
}
