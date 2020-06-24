using System;
using System.Threading.Tasks;
using billing_made_easy_api.Services.Interfaces;
using billing_made_easy_api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace billing_made_easy_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private IBillService _billService;
        public BillController(IBillService billService)
        {
            _billService = billService;
        }
        [HttpPost]
        public IActionResult InsertBill([FromBody] BillVM bill)
        {
            try
            {
                _billService.AddBill(bill);
                return Ok();
            }
            
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public IActionResult UpdateBill([FromBody] BillVM bill)
        {
            try
            {
                _billService.UpdateBill(bill);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("billId")]
        public async Task<IActionResult> FetchBill(int billId)
        {
            try
            {
                var bill =  await _billService.FetchBill(billId);
                return Ok(bill);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}