using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InventoryManagement.Entities //model class of RawMaterialOrder
{
    public class RawMaterialOrder

    {
        private string _rMOrderID;
        private string _rMOrderDate;
        private string _supplierID;
        private double _rMOrderPrice;

        public string RMOrderID { get => _rMOrderID; set => _rMOrderID = value; }
        public string RMOrderDate { get => _rMOrderDate; set => _rMOrderDate = value; }
        public string SupplierID { get => _supplierID; set => _supplierID = value; }
        public double RMOrderPrice { get => _rMOrderPrice; set => _rMOrderPrice = value; }
        public RawMaterialOrder()
        {
            RMOrderID = string.Empty;
            RMOrderDate = string.Empty;
            SupplierID = string.Empty;
        }

    }

}
