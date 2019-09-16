using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using static Inventory.Exceptions.InventoryManagementExceptions;

namespace Inventory.DataAccessLayer
{
   public class ProductOrderDAL
    {
        public static List<ProductOrder> productorderList = new List<ProductOrder>();// list of product order.

        public bool AddProductOrderDAL(ProductOrder order, List<ProductOrder> orderDetails)//method for adding product order
        {
            bool ProductorderAdded = false;
            try
            {
                orderDetails.Add(order);
                ProductorderAdded = true;
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return ProductorderAdded;

        }
        public bool DeleteProductOrderDAL(string productOrderID)//method for deleting product order
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
                throw new  InventoryException(ex.Message);
            }
            return ProductOrderDeleted;

        }
        public bool UpdateProductOrderDAL(ProductOrder updateorder)// method for updating product order
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
            catch (Exception ex)
            {
                throw new  InventoryException(ex.Message);
            }
            return orderUpdated;

        }
        public List<ProductOrder> GetAllproductOrdersDAL() //method to get the list of all product orders
        {
            return productorderList;
        }
        public List<ProductOrder> GetProductOrdersByDateDAL(string date)// method to get product order by date
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
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchProductOrder;
        }
        public ProductOrder GetProductOrdersByOrderIDDAL(string OrderID)// method  to get product orders by ID
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
            catch (Exception ex)
            {
                throw  new InventoryException(ex.Message);
            }
            return order;

        }
    }
}
