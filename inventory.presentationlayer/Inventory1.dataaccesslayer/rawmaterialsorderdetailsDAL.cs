using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using static Inventory.Exceptions.InventoryManagementExceptions;


namespace Inventory.DataAccessLayer
{
    public class RawMaterialOrderDetailsDAL
    {
        public static  List<RawMaterialsOrderDetails> RawMaterialsorderList = new List<RawMaterialsOrderDetails>();

        public bool AddRawMaterialsOrderDetailsDAL(RawMaterialsOrderDetails orderdetail, List<RawMaterialsOrderDetails> orderDetails)
        {
            bool RawMaterialsorderDetailAdded = false;
            try
            {
                orderDetails.Add(orderdetail);
                RawMaterialsorderDetailAdded = true;
            }
            catch (Exception ex)
            {
                throw new Rawmaterialsorderdetailsexception(ex.Message);
            }
            return RawMaterialsorderDetailAdded;

        }
        public bool DeleteRawMaterialsOrderDetailsDAL(string RawMaterialsOrderID)
        {
            bool RawMaterialsOrderDeleted = false;
            try
            {
                RawMaterialsOrderDetails deleteRawMaterialsOrder = null;
                foreach (RawMaterialsOrderDetails item in RawMaterialsorderList)
                {
                    if (item.RawMaterialsOrderID == RawMaterialsOrderID)
                    {
                        deleteRawMaterialsOrder = item;
                    }
                }

                if (deleteRawMaterialsOrder != null)
                {
                    RawMaterialsorderList.Remove(deleteRawMaterialsOrder);
                    RawMaterialsOrderDeleted = true;
                }
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return RawMaterialsOrderDeleted;

        }
        public bool UpdateRawMaterialsOrderDetailsDAL(RawMaterialsOrderDetails updateorder)
        {
            bool orderUpdated = false;
            try
            {
                for (int i = 0; i < RawMaterialsorderList.Count; i++)
                {
                    if (RawMaterialsorderList[i].RawMaterialsOrderID == updateorder.RawMaterialsOrderID)
                    {
                        RawMaterialsorderList[i] = updateorder;
                    }
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
