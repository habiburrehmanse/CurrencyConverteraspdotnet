using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Models
{
    public class ModelDTO
    {

        public string VehicleNo { get; set; }
        public string Detail { get; set; }
        public string ContainerNo { get; set; }
        public string Location { get; set; }
        public decimal Weight { get; set; }
        public decimal Bails { get; set; }
        public decimal RateInPak { get; set; }
        public decimal Amount { get; set; }
        public decimal RateInAED { get; set; }
        public decimal CostInAED { get; set; }
        public decimal TransportInPak { get; set; }
        public decimal TransportRate { get; set; }
        public decimal TransportCostInAED { get; set; }
        public decimal DoCharges { get; set; }
        public decimal MoncipleCharges { get; set; }
        public decimal ClearnessCharges { get; set; }
        public decimal TAX { get; set; }
        public decimal TransportCharges { get; set; }
        public decimal PUC { get; set; }
        public decimal TotalCharges { get; set; }
        public decimal Rate { get; set; }
        public decimal Sale { get; set; }
        public decimal Profit { get; set; }
    }
}
