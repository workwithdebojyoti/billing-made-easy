using billing_made_easy_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billing_made_easy_api.Repositories.Interfaces
{
    public interface IDeliveryRepository : IRepository<DeliveryDetails>
    {
        int FetchLastInsertedDeliveryId();
    }
}
