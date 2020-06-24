using System;
using System.Collections.Generic;

namespace billing_made_easy_api.Models
{
    public partial class PartyDetails
    {
        public PartyDetails()
        {
            Bill = new HashSet<Bill>();
        }

        public int Id { get; set; }
        public string PartyName { get; set; }
        public string GstNumber { get; set; }
        public string PanNumber { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string StateInformation { get; set; }
        public int? Zipcode { get; set; }
        public decimal? MobileNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Bill> Bill { get; set; }
    }
}
