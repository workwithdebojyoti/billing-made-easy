using billing_made_easy_api.Models;
using billing_made_easy_api.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billing_made_easy_api.Repositories.Interfaces
{
    public interface IBillRepository : IRepository<Bill>
    {
        Task<List<BillDetailsVM>> FetchAllBill(string organisation, DateTime startDate, DateTime endDate);
    }
}
