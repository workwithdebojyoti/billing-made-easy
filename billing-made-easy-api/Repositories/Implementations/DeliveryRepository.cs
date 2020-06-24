using billing_made_easy_api.Models;
using billing_made_easy_api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace billing_made_easy_api.Repositories.Implementations
{
    public class DeliveryRepository : Repository<DeliveryDetails> , IDeliveryRepository
    {
        public easybillContext InnerContext => context as easybillContext;
        public DeliveryRepository(easybillContext context) : base(context)
        {

        }

        public int FetchLastInsertedDeliveryId()
        {
            var deliveryDetails = InnerContext.DeliveryDetails.OrderByDescending(x => x.Id).FirstOrDefault();
            return deliveryDetails == null ? 0 : deliveryDetails.Id;
        }
    }
}
