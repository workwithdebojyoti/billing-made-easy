using System;
using System.Collections.Generic;

namespace billing_made_easy_api.Models
{
    public partial class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }
        public string OrderDetails { get; set; }
        public DateTime? OrderDate { get; set; }
        public string BuyerName { get; set; }
        public string PurchasedFrom { get; set; }
        public decimal? OrderSgst { get; set; }
        public decimal? OrderCgst { get; set; }
        public int? OrderGstpercentage { get; set; }
        public decimal? OrderGst { get; set; }
        public decimal? OrderTotal { get; set; }
        public int? RefPaymentId { get; set; }

        public virtual PaymentDetails RefPayment { get; set; }
    }
}
