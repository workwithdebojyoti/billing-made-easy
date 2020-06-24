using System;
using System.Collections.Generic;

namespace billing_made_easy_api.Models
{
    public partial class PaymentTypeMaster
    {
        public PaymentTypeMaster()
        {
            PaymentDetails = new HashSet<PaymentDetails>();
        }

        public string PaymentType { get; set; }
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<PaymentDetails> PaymentDetails { get; set; }
    }
}
