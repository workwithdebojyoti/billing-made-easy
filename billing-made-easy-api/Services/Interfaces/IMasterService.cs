using billing_made_easy_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billing_made_easy_api.Services.Interfaces
{
    public interface IMasterService
    {
        /// <summary>
        /// adds new payment option in the master database
        /// </summary>
        /// <returns></returns>
        Task AddPaymentOption(PaymentTypeMaster paymentType);
        /// <summary>
        /// returns all payment options saved in the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PaymentTypeMaster>> FetchAllPaymentOptions();

        /// <summary>
        /// adds new payment status to the master database
        /// </summary>
        /// <param name="paymentStatus"></param>
        /// <returns></returns>
        Task AddPaymentStatus(PaymentStatusMaster paymentStatus);
        /// <summary>
        /// Fetches all payment options added in the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PaymentStatusMaster>> FetchAllPaymentStatus();
    }
}
