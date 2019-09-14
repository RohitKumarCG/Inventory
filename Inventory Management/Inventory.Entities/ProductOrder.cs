using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities
{
    public class ProductOrder
    {
        private string _productOrderID;
        private string _productOrderDate;
        private string _distributorID;
        private double _productOrderPrice;

        public string ProductOrderID { get => _productOrderID; set => _productOrderID = value; }
        public string ProductOrderDate { get => _productOrderDate; set => _productOrderDate = value; }
        public string DistributorID { get => _distributorID; set => _distributorID = value; }
        public double ProductOrderPrice { get => _productOrderPrice; set => _productOrderPrice = value; }
    }
}
