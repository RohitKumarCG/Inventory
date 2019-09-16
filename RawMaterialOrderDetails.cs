using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities
{
    {
    public class RawMaterialsOrderDetails
    {
        private string _rawMaterialsOrderID;
        private string _rawMaterialsID;
        private double _rawMaterialsUnitPrice;
        private double _rawMaterialsQuantity;
        private double _rawMaterialsTotalPrice;

        
        public string RawMaterialsOrderID { get => _rawMaterialsOrderID; set => _rawMaterialsOrderID = value; }
        public string RawMaterialsID { get => _rawMaterialsID; set => _rawMaterialsID = value; }
        public double RawMaterialsUnitPrice { get => _rawMaterialsUnitPrice; set => _rawMaterialsUnitPrice = value; }
        public double RawMaterialsQuantity { get => _rawMaterialsQuantity; set => _rawMaterialsQuantity = value; }
        public double RawMaterialsTotalPrice { get => _rawMaterialsTotalPrice; set => _rawMaterialsTotalPrice = value; }
    }
}
