using billing_made_easy_api.Models;
using billing_made_easy_api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billing_made_easy_api.Repositories.Implementations
{
    public class PaymentTypeMasterRepository : Repository<PaymentTypeMaster>, IPaymentTypeMasterRepository
    {
        public easybillContext InnerContext => context as easybillContext;
        public PaymentTypeMasterRepository(easybillContext context) : base(context)
        {

        }
    }
}
