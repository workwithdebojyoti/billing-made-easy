using billing_made_easy_api.Models;
using billing_made_easy_api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billing_made_easy_api.Services.Interfaces
{
    public interface IPartyService
    {
        /// <summary>
        /// Adds party 
        /// </summary>
        /// <param name="party"></param>
        void AddParty(PartyDetailsVM party);
        /// <summary>
        /// Update party details
        /// </summary>
        /// <param name="party"></param>
        void UpdateParty(PartyDetailsVM party);
        /// <summary>
        /// Fetch party details by party id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PartyDetailsVM> FetchPartyDetails(int id);
        /// <summary>
        /// Fetch all party details
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PartyDetailsVM>> FetchAllPartyDetails();
        /// <summary>
        /// Fetch party details by mobile number 
        /// </summary>
        /// <param name="mobileNumber"></param>
        /// <returns></returns>
        Task<PartyDetailsVM> FetchPartyDetailsByMobile(decimal mobileNumber);
    }
}
