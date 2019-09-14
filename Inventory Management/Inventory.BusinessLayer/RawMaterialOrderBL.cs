using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Entities;
using System.Text.RegularExpressions;
using Inventory.DataAccessLayer;

namespace Inventory.BusinessLayer
{
    public class RawMaterialOrderBL
    {
        private static bool ValidateRawMaterialOrder(RawMaterialOrder rawMaterialOrder)
        {
            StringBuilder sb = new StringBuilder();
            bool validRawMaterial = true;
            foreach (RawMaterialOrder item in RawMaterialOrderDAL.rawmaterialorderList)
            {
                if (item.RMOrderID == rawMaterialOrder.RMOrderID)
                {
                    validRawMaterial = false;
                }
            }

            Regex regex = new Regex("^[R][O][0-9][0-9][0-9]$");
            bool b = regex.IsMatch(rawMaterialOrder.RMOrderID);
            if (b != true)
            {
               validRawMaterial = false;
                sb.Append(Environment.NewLine + "Invalid RawMaterialID");
            }
            DateTime mfd = Convert.ToDateTime(rawMaterialOrder.RMOrderDate);
            DateTime now = DateTime.Now;
            int res = DateTime.Compare(mfd, now);
        

            if( res>0)
            {
                validRawMaterial = false;
                sb.Append(Environment.NewLine + "invalid ManufactureDate");

            }
            Regex regex1 = new Regex("^[S][0-9][0-9][0-9]$");
            bool c = regex.IsMatch(rawMaterialOrder.RMOrderID);
            if (c!=true)
            {
                validRawMaterial = false;
                sb.Append(Environment.NewLine + "invalid SupplierID");
            }

            if (rawMaterialOrder.RMOrderPrice < 0.00)
            {
                validRawMaterial = false;
                sb.Append(Environment.NewLine + "price should be greater than 0");

            }
            if (validRawMaterial == false)
                throw new Exception(sb.ToString());
            return validRawMaterial;
        }
   
        public static bool AddRMOrderDL(RawMaterialOrder order, List<RawMaterialOrder> orderDetails)
        {
            bool RMorderAdded = false;
            try
            {
                if (ValidateRawMaterialOrder(order))
                {
                    RawMaterialOrderDAL rawMaterialorderDAL = new RawMaterialOrderDAL();
                    RMorderAdded = rawMaterialorderDAL.AddRMOrderDAL(order,orderDetails);
                }
            }
            catch (SystemException ex)
            {
                throw new Exception(ex.Message);
            }
            return RMorderAdded;

        }
    
        public static bool DeleteRMOrderBL(string RMOrderID)
        {
            bool RMOrderDeleted = false;
            try
            {
                Regex regex = new Regex("^[R][O][0-9][0-9][0-9]$");
                bool b = regex.IsMatch(RMOrderID);
                if (b == true)
                {
                    RawMaterialOrderDAL rawMaterialorderDAL = new RawMaterialOrderDAL();
                    RMOrderDeleted = rawMaterialorderDAL.DeleteRMOrderDAL(RMOrderID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return RMOrderDeleted;

        }
     
        public static bool UpdateRMOrderBL(RawMaterialOrder updateorder)
        {
            bool orderUpdated = false;
            try
            {
                if (ValidateRawMaterialOrder(updateorder))
                {
                    RawMaterialOrderDAL rawMaterialorderDAL = new RawMaterialOrderDAL();
                    orderUpdated= rawMaterialorderDAL.UpdateRMOrderDAL(updateorder);
                }
            }
            catch (SystemException ex)
            {
                throw new Exception(ex.Message);
            }
            return orderUpdated;

        }
     
        public static List<RawMaterialOrder> GetAllRMOrdersBL()
        {
            List<RawMaterialOrder> RMorderlist= null;
            try
            {
                RawMaterialOrderDAL rawMaterialorderDAL = new RawMaterialOrderDAL();
                RMorderlist = rawMaterialorderDAL.GetAllRMOrdersDAL();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RMorderlist;
        }
    
    }
}
