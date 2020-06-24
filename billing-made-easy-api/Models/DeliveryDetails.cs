using System;
using System.Collections.Generic;

namespace billing_made_easy_api.Models
{
    public partial class DeliveryDetails
    {
        public DeliveryDetails()
        {
            Bill = new HashSet<Bill>();
        }

        public int Id { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryMode { get; set; }
        public decimal? DeliveryCharge { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Bill> Bill { get; set; }
    }
}
