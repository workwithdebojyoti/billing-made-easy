using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using billing_made_easy_api.Models;
using billing_made_easy_api.Repositories.Interfaces;
using billing_made_easy_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace billing_made_easy_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {        
        private IMasterService _masterService;
        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;
        }
        [HttpPost("payment/status")]
        public IActionResult AddPaymentStatus([FromBody] PaymentStatusMaster paymentStatus)
        {
            _masterService.AddPaymentStatus(paymentStatus);
            return Ok();
        }
        [HttpGet("payment/status")]
        public async Task<IEnumerable<PaymentStatusMaster>> FetchAllPaymentStatus()
        {
            return await _masterService.FetchAllPaymentStatus();
        }

        [HttpPost("payment/option")]
        public IActionResult AddPaymentType([FromBody] PaymentTypeMaster paymentType)
        {
            _masterService.AddPaymentOption(paymentType);
            return Ok();
        }
        [HttpGet("payment/option")]
        public async Task<IEnumerable<PaymentTypeMaster>> FetchAllPaymentTypes()
        {
            return await _masterService.FetchAllPaymentOptions();
        }
    }
}
