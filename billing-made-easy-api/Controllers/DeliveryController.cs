using System;

using billing_made_easy_api.Services.Interfaces;
using billing_made_easy_api.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace billing_made_easy_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsPolicy")]
    public class DeliveryController : ControllerBase
    {
        private IDeliveryService _deliveryService;
        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpPost]
        public IActionResult AddDeliveryDetails([FromBody] DeliveryDetailsVM deliveryDetails)
        {
            try
            {
                _deliveryService.AddDeliveryDetails(deliveryDetails);
                var deliveryId = _deliveryService.FetchLastInsertedDeliveryId();
                return Ok(deliveryId);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        
    }
}
