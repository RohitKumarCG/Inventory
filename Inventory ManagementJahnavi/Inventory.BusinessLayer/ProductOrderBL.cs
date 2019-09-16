using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using InventoryManagement.Entities;
using Inventory.DataAccessLayer;
using Inventory.Exceptions;
using static Inventory.Exceptions.InventoryManagementExceptions;

namespace Inventory.BusinessLayer
{
    class ProductOrderBL
    {
        private static bool ValidateProductOrder(Entities.ProductOrder productOrder) //method to validate product order
        {
            StringBuilder sb = new StringBuilder();
            bool validProduct = true;
            foreach (Entities.ProductOrder item in ProductOrderDAL.productorderList)
            {
                if (item.ProductOrderID == productOrder.ProductOrderID)
                {
                    validProduct = false;
                }
            }
            Regex regex = new Regex("^[P][O][0-9][0-9][0-9]$");
            bool b = regex.IsMatch(productOrder.ProductOrderID);
            if (b != true)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "Invalid ProductOrderID");
            }
            DateTime mfd = Convert.ToDateTime(productOrder.ProductOrderDate);
            DateTime now = DateTime.Now;
            int res = DateTime.Compare(mfd, now);


            if (res > 0)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "invalid ManufactureDate");

            }
            Regex regex1 = new Regex("^[S][0-9][0-9][0-9]$");
            bool c = regex.IsMatch(productOrder.DistributorID);
            if (c != true)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "invalid DistributorID");
            }

            if (productOrder.ProductOrderPrice < 0.00)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "price should be greater than 0");

            }
            if (validProduct == false)
                throw new Exception(sb.ToString());
            return validProduct;
        }

        public static bool AddProductOrderDL(Entities.ProductOrder order, List<Entities.ProductOrder> orderDetails) //method to do validations for add product order method
        {
            bool ProductorderAdded = false;
            try
            {
                if (ValidateProductOrder(order))
                {
                    ProductOrderDAL productorderDAL = new ProductOrderDAL();
                    ProductorderAdded = productorderDAL.AddProductOrderDAL(order, orderDetails);
                }
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return ProductorderAdded;

        }

        public static bool DeleteProductOrderBL(string productOrderID) //method to do validations for deleting product order
        {
            bool productOrderDeleted = false;
            try
            {
                Regex regex = new Regex("^[P][O][0-9][0-9][0-9]$");
                bool b = regex.IsMatch(productOrderID);
                if (b == true)
                {
                    ProductOrderDAL productorderDAL = new ProductOrderDAL();
                    productOrderDeleted = productorderDAL.DeleteProductOrderDAL(productOrderID);
                }
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return productOrderDeleted;

        }

        public static bool UpdateProductOrderBL(Entities.ProductOrder updateorder) //method to do validations for update product order
        {
            bool orderUpdated = false;
            try
            {
                if (ValidateProductOrder(updateorder))
                {
                    ProductOrderDAL productorderDAL = new ProductOrderDAL();
                    orderUpdated = productorderDAL.UpdateProductOrderDAL(updateorder);
                }
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return orderUpdated;

        }

        public static List<Entities.ProductOrder> GetAllRMOrdersBL()
        {
            List<Entities.ProductOrder> productorderlist = null;
            try
            {
                ProductOrderDAL productorderDAL = new ProductOrderDAL();
                productorderlist = productorderDAL.GetAllproductOrdersDAL();

            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return productorderlist;
        }

    }

}
