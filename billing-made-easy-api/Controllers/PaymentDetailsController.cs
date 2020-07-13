﻿
using System;
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
    [EnableCors("MyCorsPolicy")]
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
        public async Task<IActionResult> UpdatePaymentDetails(PaymentDetailsVM paymentDetails)
        {
            try
            {
                await _paymentDetailsService.UpdatePaymentDetails(paymentDetails);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
