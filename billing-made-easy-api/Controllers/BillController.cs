using System;
using System.Threading.Tasks;
using billing_made_easy_api.Services.Interfaces;
using billing_made_easy_api.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace billing_made_easy_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsPolicy")]
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
                return Ok(true);
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
        [HttpGet("organisation/{organisation}/month/{month}/year/{year}")]
        public async Task<IActionResult> FetchAllBills(string organisation, int month, int year = 1992)
        {
            try
            {
                if (year == 1992) 
                    year = DateTime.Now.Year;
                var bills = await _billService.FetchAllBill(organisation, month, year);
                return Ok(bills);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("organisation/{organisation}/financialyear/{year}")]
        public async Task<IActionResult> FetchAllBills(string organisation, int year = 1992)
        {
            try
            {
                if (year == 1992)
                    year = DateTime.Now.Year;
                var bills = await _billService.FetchAllBill(organisation, year);
                return Ok(bills);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}