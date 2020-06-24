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
    public class PartyService : IPartyService
    {
        private IPartyDetailsRepository _partyDetailsRepository;
        private readonly IMapper _mapper;
        public PartyService(IPartyDetailsRepository partyDetailsRepository, IMapper mapper)
        {
            _partyDetailsRepository = partyDetailsRepository;
            _mapper = mapper;
        }
        public void AddParty(PartyDetailsVM partyVM)
        {
            var partyDetail = _mapper.Map<PartyDetails>(partyVM);
            _partyDetailsRepository.Insert(partyDetail);
        }

        public void UpdateParty(PartyDetailsVM partyVM)
        {
            var partyDetail = _mapper.Map<PartyDetails>(partyVM);
            _partyDetailsRepository.Update(partyDetail);
        }

        public async Task<IEnumerable<PartyDetailsVM>> FetchAllPartyDetails()
        {
            var partyDetail = await _partyDetailsRepository.GetAll();
            return _mapper.Map<IEnumerable<PartyDetailsVM>>(partyDetail);
        }

        public async Task<PartyDetailsVM> FetchPartyDetails(int id)
        {
            var partyDetail = await _partyDetailsRepository.GetById(id);
            return _mapper.Map<PartyDetailsVM>(partyDetail);
        }

        public async Task<PartyDetailsVM> FetchPartyDetailsByMobile(decimal mobileNumber)
        {
            var partyDetail = await _partyDetailsRepository.FetchPartyDetailsByMobile(mobileNumber);
            return _mapper.Map<PartyDetailsVM>(partyDetail);
        }
    }
}
