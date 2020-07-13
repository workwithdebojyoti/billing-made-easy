using System;
using System.Collections.Generic;

namespace billing_made_easy_api.Models
{
    public partial class PaymentDetails
    {
        public PaymentDetails()
        {
            Bill = new HashSet<Bill>();
        }

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

        public virtual PaymentTypeMaster PaymentModeNavigation { get; set; }
        public virtual PaymentStatusMaster PaymentStatusNavigation { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
    }
}
