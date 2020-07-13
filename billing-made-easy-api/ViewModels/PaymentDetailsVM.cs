using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billing_made_easy_api.ViewModels
{
    public class PaymentDetailsVM
    {
        public int Id { get; set; }
        public decimal? PaymentAmount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? PaymentMode { get; set; }
        public string PaymentReferenceNumber { get; set; }
        public string PaymentType { get; set; }
        public int? PaymentStatus { get; set; }
        public decimal? BillAmount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
