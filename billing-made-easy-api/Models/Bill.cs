using System;
using System.Collections.Generic;

namespace billing_made_easy_api.Models
{
    public partial class Bill
    {
        public int Id { get; set; }
        public string BillNumber { get; set; }
        public string BillerName { get; set; }
        public int? BillType { get; set; }
        public DateTime? BillDate { get; set; }
        public decimal? BillTotalAmount { get; set; }
        public decimal? BillTotalTax { get; set; }
        public decimal? BillTotalSgst { get; set; }
        public decimal? BillTotalCgst { get; set; }
        public int? RefPartyId { get; set; }
        public int? RefPaymentId { get; set; }
        public int? RefDeliveryId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual DeliveryDetails RefDelivery { get; set; }
        public virtual PartyDetails RefParty { get; set; }
        public virtual PaymentDetails RefPayment { get; set; }
    }
}
