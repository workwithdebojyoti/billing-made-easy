using billing_made_easy_api.Models;
using billing_made_easy_api.Repositories.Interfaces;


namespace billing_made_easy_api.Repositories.Implementations
{
    public class PaymentDetailsRepository: Repository<PaymentDetails>, IPaymentDetailsRepository
    {
        public easybillContext InnerContext => context as easybillContext;
        public PaymentDetailsRepository(easybillContext context) : base(context)
        {

        }
    }
}
