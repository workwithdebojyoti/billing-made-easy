using AutoMapper;
using billing_made_easy_api.Models;
using billing_made_easy_api.Repositories.Interfaces;
using billing_made_easy_api.Services.Interfaces;
using billing_made_easy_api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billing_made_easy_api.Services.Implementations
{
    public class DeliveryService : IDeliveryService
    {
        private IMapper _mapper;
        private IDeliveryRepository _deliveryRepository;
        public DeliveryService(IMapper mapper, IDeliveryRepository deliveryRepository)
        {
            _mapper = mapper;
            _deliveryRepository = deliveryRepository;
        }
        public void AddDeliveryDetails(DeliveryDetailsVM deliveryDetails)
        {
            var deliveryDetail = _mapper.Map<DeliveryDetails>(deliveryDetails);
            _deliveryRepository.Insert(deliveryDetail);
        }


    }
}
