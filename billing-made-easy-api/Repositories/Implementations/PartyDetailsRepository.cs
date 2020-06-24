using billing_made_easy_api.Models;
using billing_made_easy_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace billing_made_easy_api.Repositories.Implementations
{
    public class PartyDetailsRepository: Repository<PartyDetails>, IPartyDetailsRepository
    {
        public easybillContext InnerContext => context as easybillContext;
        public PartyDetailsRepository(easybillContext context) : base(context)
        {

        }

        public async Task<PartyDetails> FetchPartyDetailsByMobile(decimal mobileNumber)
        {
            return await this.InnerContext.PartyDetails.FirstOrDefaultAsync(x => x.MobileNumber == mobileNumber);
        }
    }
}
