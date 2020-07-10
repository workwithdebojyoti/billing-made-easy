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
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PartyController : ControllerBase
    {
        IPartyService _partyService;
        public PartyController(IPartyService partyService)
        {
            _partyService = partyService;
        }
        [HttpPost]
        public IActionResult AddParty([FromBody] PartyDetailsVM partyDetailsVM)
        {
            _partyService.AddParty(partyDetailsVM);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateParty([FromBody] PartyDetailsVM partyDetailsVM)
        {
            _partyService.UpdateParty(partyDetailsVM);
            return Ok();
        }

        [HttpGet()]
        public async Task<IEnumerable<PartyDetailsVM>> FetchPartyDetails()
        {
            return await _partyService.FetchAllPartyDetails();
        }
        [HttpGet("partyId")]
        public async Task<PartyDetailsVM> FetchPartyDetailsById(int partyId)
        {
            return await _partyService.FetchPartyDetails(partyId);
        }

        [HttpGet("mobileNumber")]
        public async Task<PartyDetailsVM> FetchPartyDetailsByMobile(string mobileNumber)
        {
            return await _partyService.FetchPartyDetailsByMobile(Convert.ToDecimal(mobileNumber));
        }
    }
}
