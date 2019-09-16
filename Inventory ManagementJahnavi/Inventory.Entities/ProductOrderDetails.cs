using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities
{
    public  class ProductOrderDetails
    {
        private string _productOrderID;
        private string _productID;
        private double _productUnitPrice;
        private double _productQuantity;
        private double _productTotalPrice;

        public string ProductOrderID { get => _productOrderID; set => _productOrderID = value; }
        public string ProductID { get => _productID; set => _productID = value; }
        public double ProductUnitPrice { get => _productUnitPrice; set => _productUnitPrice = value; }
        public double ProductQuantity { get => _productQuantity; set => _productQuantity = value; }
        public double ProductTotalPrice { get => _productTotalPrice; set => _productTotalPrice = value; }
    }
}
