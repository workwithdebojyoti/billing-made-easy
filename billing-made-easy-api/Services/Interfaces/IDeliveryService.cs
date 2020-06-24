using billing_made_easy_api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billing_made_easy_api.Services.Interfaces
{
    public interface IDeliveryService
    {
        /// <summary>
        /// Adds delivery details to the database
        /// </summary>
        /// <param name="deliveryDetails"></param>

        void AddDeliveryDetails(DeliveryDetailsVM deliveryDetails);
    }
}
