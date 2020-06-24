using AutoMapper;
using billing_made_easy_api.Models;
using billing_made_easy_api.ViewModels;


namespace billing_made_easy_api.Mapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PartyDetails, PartyDetailsVM>().ReverseMap();
            CreateMap<PaymentDetails, PaymentDetailsVM>().ReverseMap();
            CreateMap<Bill, BillVM>().ReverseMap();
            CreateMap<DeliveryDetails, DeliveryDetailsVM>().ReverseMap();
        }
    }
}
