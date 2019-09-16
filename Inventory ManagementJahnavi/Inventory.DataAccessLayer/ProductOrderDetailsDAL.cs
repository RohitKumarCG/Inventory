using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using static Inventory.Exceptions.InventoryManagementExceptions;

namespace Inventory.DataAccessLayer
{
    public  class ProductOrderDetailsDAL
    {
        public static List<ProductOrderDetails> productorderList = new List<ProductOrderDetails>();

        public bool AddProductOrderDetailsDAL(ProductOrderDetails orderdetail, List<ProductOrderDetails> orderDetails)
        {
            bool ProductorderDetailAdded = false;
            try
            {
                orderDetails.Add(orderdetail);
                ProductorderDetailAdded = true;
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return ProductorderDetailAdded;

        }
        public bool DeleteProductOrderDetailsDAL(string productOrderID)
        {
            bool ProductOrderDeleted = false;
            try
            {
                ProductOrderDetails deleteProductOrder = null;
                foreach (ProductOrderDetails item in productorderList)
                {
                    if (item.ProductOrderID == productOrderID)
                    {
                        deleteProductOrder = item;
                    }
                }

                if (deleteProductOrder != null)
                {
                    productorderList.Remove(deleteProductOrder);
                    ProductOrderDeleted = true;
                }
            }
            catch (Exception ex)
            {
                throw new  InventoryException(ex.Message);
            }
            return ProductOrderDeleted;

        }
        public bool UpdateProductOrderDetailsDAL(ProductOrderDetails updateorder)
        {
            bool orderUpdated = false;
            try
            {
                for (int i = 0; i < productorderList.Count; i++)
                {
                    if (productorderList[i].ProductOrderID == updateorder.ProductOrderID)
                    {
                        productorderList[i] = updateorder;
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