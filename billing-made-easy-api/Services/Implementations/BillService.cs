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
    public class BillService : IBillService
    {
        private IBillRepository _billRepository;
        private IMapper _mapper;
        public BillService(IBillRepository billRepository, IMapper mapper)
        {
            _mapper = mapper;
            _billRepository = billRepository;
        }
        public void AddBill(BillVM billVM)
        {
            var bill = _mapper.Map<Bill>(billVM);
            _billRepository.Insert(bill);
        }

        public async Task<BillVM> FetchBill(int billId)
        {
            var bill = await _billRepository.GetById(billId);
            return _mapper.Map<BillVM>(bill);
        }

        public void UpdateBill(BillVM billVM)
        {
            var bill = _mapper.Map<Bill>(billVM);
            _billRepository.Update(bill);
        }
    }
}
