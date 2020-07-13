using billing_made_easy_api.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billing_made_easy_api.Services.Interfaces
{
    public interface IPaymentDetailsService
    {
        /// <summary>
        /// adds payment details to the database
        /// </summary>
        /// <param name="paymentDetailsVM"></param>
        /// <returns></returns>
        Task AddPaymentDetails(PaymentDetailsVM paymentDetailsVM);
        /// <summary>
        /// Fetches all payment details saved in the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PaymentDetailsVM>> FetchAllPaymentDetails();
        /// <summary>
        /// Fetches particular payment details saved in the database by id
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        Task<PaymentDetailsVM> FetchPaymentDetails(int paymentId);
        /// <summary>
        /// Updates payment details
        /// </summary>
        /// <param name="paymentDetailsVM"></param>
        Task UpdatePaymentDetails(PaymentDetailsVM paymentDetailsVM);
        /// <summary>
        /// Returns the recent payment id
        /// </summary>
        /// <returns></returns>
        int FetchRecentPaymentId();
    }
}
