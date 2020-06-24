using billing_made_easy_api.Models;
using billing_made_easy_api.Repositories.Interfaces;
using billing_made_easy_api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billing_made_easy_api.Services.Implementations
{
    public class MasterService : IMasterService
    {
        private IPaymentStatusMasterRepository _paymentStatusMasterRepository;
        private IPaymentTypeMasterRepository _paymentTypeMasterRepository;
        public MasterService(IPaymentStatusMasterRepository paymentStatusMasterRepository, IPaymentTypeMasterRepository paymentTypeMasterRepository)
        {
            _paymentStatusMasterRepository = paymentStatusMasterRepository;
            _paymentTypeMasterRepository = paymentTypeMasterRepository;
        }
        public async Task AddPaymentOption(PaymentTypeMaster paymentType)
        {
            await this._paymentTypeMasterRepository.Insert(paymentType);
        }

        public async Task<IEnumerable<PaymentTypeMaster>> FetchAllPaymentOptions()
        {
            return await this._paymentTypeMasterRepository.GetAll();
        }

        public async Task AddPaymentStatus(PaymentStatusMaster paymentStatus)
        {
            await this._paymentStatusMasterRepository.Insert(paymentStatus);
        }

        public async Task<IEnumerable<PaymentStatusMaster>> FetchAllPaymentStatus()
        {
            return await this._paymentStatusMasterRepository.GetAll();
        }
    }
}
