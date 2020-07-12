using billing_made_easy_api.Models;
using billing_made_easy_api.Repositories.Interfaces;
using billing_made_easy_api.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace billing_made_easy_api.Repositories.Implementations
{
    public class BillRepository : Repository<Bill> , IBillRepository
    {
        public easybillContext InnerContext => context as easybillContext;
        public BillRepository(easybillContext context) : base(context)
        {
            // no implementation required
        }

        public Task<List<BillDetailsVM>> FetchAllBill(string organisation, DateTime startDate, DateTime endDate)
        {
            //var bills = InnerContext.Bill.Where(bill => bill.BillerName == organisation
            //&& bill.BillDate >= startDate && bill.BillDate <= endDate).Select(s => s);

            var billDetailsList = from bill in InnerContext.Bill
                                  join
                                        partyDetails in InnerContext.PartyDetails on bill.RefPartyId equals partyDetails.Id
                                  join
                                        paymentDetails in InnerContext.PaymentDetails on bill.RefPaymentId equals paymentDetails.Id
                                  join
                                        deliveryDetails in InnerContext.DeliveryDetails on bill.RefDeliveryId equals deliveryDetails.Id
                                  where 
                                        bill.BillerName == organisation && bill.BillDate >= startDate && bill.BillDate <= endDate

                                  select new BillDetailsVM
                                  {
                                      BillId = bill.Id,
                                      BillNumber = bill.BillNumber,
                                      BillerName = bill.BillerName,
                                      BillType = bill.BillType == 0 ? "Cash" : "GST",
                                      BillDate = bill.BillDate,
                                      BillTotalAmount = bill.BillTotalAmount,
                                      BillTotalTax = bill.BillTotalTax,
                                      BillTotalSgst = bill.BillTotalSgst,
                                      BillTotalCgst = bill.BillTotalCgst,
                                      PaymentDetails = new PaymentDetailsVM
                                      {
                                          Id = paymentDetails.Id,
                                          PaymentStatus = paymentDetails.PaymentStatus,
                                          PaymentAmount = paymentDetails.PaymentAmount,
                                          PaymentDate = paymentDetails.PaymentDate,
                                          PaymentMode = paymentDetails.PaymentMode,
                                          PaymentReferenceNumber = paymentDetails.PaymentReferenceNumber,
                                          PaymentType = paymentDetails.PaymentType,
                                          CreatedAt = paymentDetails.CreatedAt,
                                          UpdatedAt = paymentDetails.UpdatedAt
                                      },
                                      PartyDetails = new PartyDetailsVM
                                      {
                                          Id = partyDetails.Id,
                                          PartyName = partyDetails.PartyName,
                                          MobileNumber = partyDetails.MobileNumber
                                      },
                                      DeliveryDetails = new DeliveryDetailsVM
                                      {
                                          Id = deliveryDetails.Id,
                                          DeliveryAddress = deliveryDetails.DeliveryAddress,
                                          DeliveryCharge = deliveryDetails.DeliveryCharge,
                                          DeliveryDate = deliveryDetails.DeliveryDate,
                                          DeliveryMode = deliveryDetails.DeliveryMode
                                      }

                                  };

            return billDetailsList.ToListAsync();
        }
    }
}
