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
    public class PaymentDetailsService : IPaymentDetailsService
    {
        private IPaymentDetailsRepository _paymentDetailsRepository;
        private readonly IMapper _mapper;
        public PaymentDetailsService(IPaymentDetailsRepository paymentDetailsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _paymentDetailsRepository = paymentDetailsRepository;
        }
        public async Task AddPaymentDetails(PaymentDetailsVM paymentDetailsVM)
        {
            var paymentDetails = _mapper.Map<PaymentDetailsVM, PaymentDetails>(paymentDetailsVM);
            await _paymentDetailsRepository.Insert(paymentDetails);
        }

        public async Task<IEnumerable<PaymentDetailsVM>> FetchAllPaymentDetails()
        {
            var paymentDetails = await _paymentDetailsRepository.GetAll();
            return _mapper.Map<IEnumerable<PaymentDetailsVM>>(paymentDetails);
        }

        public async Task<PaymentDetailsVM> FetchPaymentDetails(int paymentId)
        {
            var paymentDetail = await _paymentDetailsRepository.GetById(paymentId);
            return _mapper.Map<PaymentDetailsVM>(paymentDetail);
        }

        public void UpdatePaymentDetails(PaymentDetailsVM paymentDetailsVM)
        {
            var paymentDetails = _mapper.Map<PaymentDetailsVM, PaymentDetails>(paymentDetailsVM);
            _paymentDetailsRepository.Update(paymentDetails);
        }
    }
}
