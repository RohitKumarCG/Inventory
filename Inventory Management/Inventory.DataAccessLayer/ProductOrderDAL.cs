using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;

namespace Inventory.DataAccessLayer
{
   public class ProductOrderDAL
    {
        public static List<ProductOrder> productorderList = new List<ProductOrder>();

        public bool AddProductOrderDAL(ProductOrder order, List<ProductOrder> orderDetails)
        {
            bool ProductorderAdded = false;
            try
            {
                orderDetails.Add(order);
                ProductorderAdded = true;
            }
            catch (SystemException ex)
            {
                throw new Exception(ex.Message);
            }
            return ProductorderAdded;

        }
        public bool DeleteProductOrderDAL(string productOrderID)
        {
            bool ProductOrderDeleted = false;
            try
            {
                ProductOrder deleteProductOrder = null;
                foreach (ProductOrder item in productorderList)
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
                throw new Exception(ex.Message);
            }
            return ProductOrderDeleted;

        }
        public bool UpdateProductOrderDAL(ProductOrder updateorder)
        {
            bool orderUpdated = false;
            try
            {
                for (int i = 0; i <productorderList.Count; i++)
                {
                    if (productorderList[i].ProductOrderID == updateorder.ProductOrderID)
                    {
                        productorderList[i] = updateorder;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new Exception(ex.Message);
            }
            return orderUpdated;

        }
        public List<ProductOrder> GetAllproductOrdersDAL()
        {
            return productorderList;
        }
        public List<ProductOrder> GetRMOrdersByDateDAL(string date)
        {
            List<ProductOrder> searchProductOrder = new List<ProductOrder>();
            try
            {
                foreach (ProductOrder item in productorderList)
                {
                    if (item.ProductOrderDate== date)
                    {
                        searchProductOrder.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new Exception(ex.Message);
            }
            return searchProductOrder;
        }
        public ProductOrder GetRMOrdersByOrderIDDAL(string OrderID)
        {
            List<ProductOrder> searchRawMaterialOrder = new List<ProductOrder>();
            ProductOrder order = null;
            try
            {
                foreach (ProductOrder item in productorderList)
                {
                    if (item.ProductOrderID == OrderID)
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
