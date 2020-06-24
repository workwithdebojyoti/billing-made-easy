using billing_made_easy_api.Models;
using billing_made_easy_api.Repositories.Interfaces;
using System.Linq;

namespace billing_made_easy_api.Repositories.Implementations
{
    public class PaymentDetailsRepository: Repository<PaymentDetails>, IPaymentDetailsRepository
    {
        public easybillContext InnerContext => context as easybillContext;
        public PaymentDetailsRepository(easybillContext context) : base(context)
        {

        }

        public int FetchLastInsertedPaymentId()
        {
            var recentPaymentDetails = context.PaymentDetails.OrderByDescending(x => x.Id).FirstOrDefault();
            return recentPaymentDetails == null ? 0 : recentPaymentDetails.Id;
        }
    }
}
