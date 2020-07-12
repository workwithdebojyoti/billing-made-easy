using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billing_made_easy_api.ViewModels
{
    public class BillDetailsVM
    {
        public int BillId { get; set; }
        public string BillNumber { get; set; }
        public string BillerName { get; set; }
        public string BillType { get; set; }
        public DateTime? BillDate { get; set; }
        public decimal? BillTotalAmount { get; set; }
        public decimal? BillTotalTax { get; set; }
        public decimal? BillTotalSgst { get; set; }
        public decimal? BillTotalCgst { get; set; }
        public PaymentDetailsVM PaymentDetails { get; set; }
        public PartyDetailsVM PartyDetails { get; set; }
        public DeliveryDetailsVM DeliveryDetails { get; set; }

    }
}
