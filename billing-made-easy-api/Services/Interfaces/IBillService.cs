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
        /// <summary>
        /// Fetches all bills for a particular organisation for a particular month
        /// </summary>
        /// <param name="organisation"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        Task<List<BillDetailsVM>> FetchAllBill(string organisation, int month, int year);
        /// <summary>
        /// Fetches all bill details of a financial year
        /// </summary>
        /// <param name="organisation"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        Task<List<BillDetailsVM>> FetchAllBill(string organisation, int year);
    }
}
