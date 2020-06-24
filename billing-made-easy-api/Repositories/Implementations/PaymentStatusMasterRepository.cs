using billing_made_easy_api.Models;
using billing_made_easy_api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billing_made_easy_api.Repositories.Implementations
{
    public class PaymentStatusMasterRepository : Repository<PaymentStatusMaster>, IPaymentStatusMasterRepository
    {
        public PaymentStatusMasterRepository(easybillContext context) : base(context)
        {
        }

        public easybillContext InnerContext => context as easybillContext;
    }
}
