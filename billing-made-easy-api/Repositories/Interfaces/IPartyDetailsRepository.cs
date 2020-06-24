using billing_made_easy_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billing_made_easy_api.Repositories.Interfaces
{
    public interface IPartyDetailsRepository : IRepository<PartyDetails>
    {
        Task<PartyDetails> FetchPartyDetailsByMobile(decimal mobileNumber);
    }
}
