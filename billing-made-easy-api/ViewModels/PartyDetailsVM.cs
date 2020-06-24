using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billing_made_easy_api.ViewModels
{
    public class PartyDetailsVM
    {
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
    }
}
