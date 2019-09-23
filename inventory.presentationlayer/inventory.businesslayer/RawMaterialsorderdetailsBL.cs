using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Inventory.Entities;
using Inventory.DataAccessLayer;
using static Inventory.Exceptions.InventoryManagementExceptions;


namespace Inventory.BusinessLayer

{
    class RawMaterialsOrderDetailsBL
    {
        private static bool ValidateRawMaterialsOrderDetails(Entities.RawMaterialsOrderDetails RawMaterialsOrder)
        {
            StringBuilder sb = new StringBuilder();
            bool validRawMaterials = true;
            foreach (Entities.RawMaterialsOrderDetails item in RawMaterialsOrderDetailsDAL.RawMaterialsorderList)
            {
                if (item.RawMaterialsOrderID == RawMaterialsOrder.RawMaterialsOrderID)
                {
                    validRawMaterials = false;
                }
            }
            Regex regex = new Regex("^[P][O][0-9][0-9][0-9]$");
            bool b = regex.IsMatch(RawMaterialsOrder.RawMaterialsOrderID);
            if (b != true)
            {
                validRawMaterials = false;
                sb.Append(Environment.NewLine + "Invalid RawMaterialsOrderID");
            }

            Regex regex1 = new Regex("^[P][0-9][0-9][0-9]$");
            bool c = regex.IsMatch(RawMaterialsOrder.RawMaterialsID);
            if (c != true)
            {
                validRawMaterials = false;
                sb.Append(Environment.NewLine + "invalid RawMaterialsID");
            }

            if (RawMaterialsOrder.RawMaterialsUnitPrice < 0.00)
            {
                validRawMaterials = false;
                sb.Append(Environment.NewLine + "RawMaterials unit price should be greater than 0");

            }
            if (RawMaterialsOrder.RawMaterialsQuantity < 0.00)
            {
                validRawMaterials = false;
                sb.Append(Environment.NewLine + "RawMaterials quantity should be greater than 0");

            }
            if (RawMaterialsOrder.RawMaterialsTotalPrice < 0.00)
            {
                validRawMaterials = false;
                sb.Append(Environment.NewLine + "RawMaterials  total price should be greater than 0");

            }
            if (validRawMaterials == false)
                throw new InventoryException(sb.ToString());
            return validRawMaterials;
        }
        public static bool AddRawMaterialsOrderDetailsDL(Entities.RawMaterialsOrderDetails order, List<Entities.RawMaterialsOrderDetails> orderDetails)
        {
            bool RawMaterialsorderAdded = false;
            try
            {
                if (ValidateRawMaterialsOrderDetails(order))
                {
                    RawMaterialsOrderDetailsDAL RawMaterialsorderDAL = new RawMaterialsOrderDetailsDAL();
                    RawMaterialsorderAdded = RawMaterialsorderDAL.AddRawMaterialsOrderDetailsDAL(order, orderDetails);
                }
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return RawMaterialsorderAdded;

        }

        public static bool DeleteRawMaterialsOrderDetailsBL(string RawMaterialsOrderID)
        {
            bool RawMaterialsOrderDeleted = false;
            try
            {
                Regex regex = new Regex("^[P][O][0-9][0-9][0-9]$");
                bool b = regex.IsMatch(RawMaterialsOrderID);
                if (b == true)
                {
                    RawMaterialsOrderDetailsDAL RawMaterialsorderDAL = new RawMaterialsOrderDetailsDAL();
                    RawMaterialsOrderDeleted = RawMaterialsorderDAL.DeleteRawMaterialsOrderDetailsDAL(RawMaterialsOrderID);
                }
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return RawMaterialsOrderDeleted;

        }

        public static bool UpdateRawMaterialsOrderDetailsBL(Entities.RawMaterialsOrderDetails updateorder)
        {
            bool orderUpdated = false;
            try
            {
                if (ValidateRawMaterialsOrderDetails(updateorder))
                {
                    RawMaterialsOrderDetailsDAL RawMaterialsorderDAL = new RawMaterialsOrderDetailsDAL();
                    orderUpdated = RawMaterialsorderDAL.UpdateRawMaterialsOrderDetailsDAL(updateorder);
                }
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return orderUpdated;

        }
    }
}