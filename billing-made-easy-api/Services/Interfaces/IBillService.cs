using billing_made_easy_api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billing_made_easy_api.Services.Interfaces
{
    public interface IBillService
    {
        /// <summary>
        /// Inserts bill details to database
        /// </summary>
        /// <param name="billVM"></param>
        void AddBill(BillVM billVM);
        /// <summary>
        /// Fetches bill info by bill id
        /// </summary>
        /// <param name="billId"></param>
        /// <returns></returns>
        Task<BillVM> FetchBill(int billId);
        /// <summary>
        /// Updates a bill
        /// </summary>
        /// <param name="billVM"></param>
        void UpdateBill(BillVM billVM);
    }
}
