using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShop20180314112512Service.DataObjects
{
    public class Customer : EntityData
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public double OpenInvoice { get; set; }
    }
}