using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billing_made_easy_api.ViewModels
{
    public class DeliveryDetailsVM
    {
        public int Id { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryMode { get; set; }
        public decimal? DeliveryCharge { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
