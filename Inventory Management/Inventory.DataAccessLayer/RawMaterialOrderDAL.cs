using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Entities;

namespace Inventory.DataAccessLayer
{
  
  
    public class RawMaterialOrderDAL
    {
        public static List<RawMaterialOrder> rawmaterialorderList = new List<RawMaterialOrder>();

        public bool AddRMOrderDAL(RawMaterialOrder order , List<RawMaterialOrder> orderDetails)
        {
            bool RMorderAdded = false;
            try
            {
                orderDetails.Add(order);
                RMorderAdded = true;
            }
            catch (SystemException ex)
            {
                throw new Exception(ex.Message);
            }
            return RMorderAdded;

        }
        public bool DeleteRMOrderDAL(string RMOrderID)
        {
            bool RMOrderDeleted = false;
            try
            {
                RawMaterialOrder deleteRMOrder = null;
                foreach (RawMaterialOrder item in rawmaterialorderList)
                {
                    if (item.RMOrderID == RMOrderID)
                    {
                        deleteRMOrder = item;
                    }
                }

                if (deleteRMOrder != null)
                {
                    rawmaterialorderList.Remove(deleteRMOrder);
                    RMOrderDeleted = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return RMOrderDeleted;

        }
        public bool UpdateRMOrderDAL(RawMaterialOrder updateorder)
        {
            bool orderUpdated = false;
            try
            {
                for (int i = 0; i < rawmaterialorderList.Count; i++)
                {
                    if (rawmaterialorderList[i].RMOrderID == updateorder.RMOrderID)
                    {
                        updateorder.SupplierID = rawmaterialorderList[i].SupplierID;
                 
                        orderUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new Exception(ex.Message);
            }
            return orderUpdated;

        }
        public List<RawMaterialOrder> GetAllRMOrdersDAL()
        {
            return rawmaterialorderList;
        }
        public List<RawMaterialOrder> GetRMOrdersByDateDAL(string date)
        {
            List<RawMaterialOrder> searchRawMaterialOrder = new List<RawMaterialOrder>();
            try
            {
                foreach (RawMaterialOrder item in rawmaterialorderList)
                {
                    if (item.RMOrderDate == date)
                    {
                        searchRawMaterialOrder.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new Exception(ex.Message);
            }
            return searchRawMaterialOrder;
        }
        public RawMaterialOrder GetRMOrdersByOrderIDDAL(string OrderID)
        {
            List<RawMaterialOrder> searchRawMaterialOrder = new List<RawMaterialOrder>();
            RawMaterialOrder order = null;
            try
            {
                foreach (RawMaterialOrder item in rawmaterialorderList)
                {
                    if (item.RMOrderID== OrderID)
                    {
                        order = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
          
        }

    }
}
