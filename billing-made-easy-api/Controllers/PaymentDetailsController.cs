using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using billing_made_easy_api.Models;
using billing_made_easy_api.Services.Interfaces;
using billing_made_easy_api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace billing_made_easy_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        private IPaymentDetailsService _paymentDetailsService;
        public PaymentDetailsController(IPaymentDetailsService paymentDetailsService)
        {
            _paymentDetailsService = paymentDetailsService;
        }
        [HttpPost]
        public async Task AddPaymentDetails(PaymentDetailsVM paymentDetails)
        {
            await _paymentDetailsService.AddPaymentDetails(paymentDetails);
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
