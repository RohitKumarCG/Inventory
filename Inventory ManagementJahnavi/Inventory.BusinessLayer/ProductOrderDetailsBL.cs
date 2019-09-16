using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.DataAccessLayer;
using System.Text.RegularExpressions;
using static Inventory.Exceptions.InventoryManagementExceptions;

namespace Inventory.BusinessLayer

{
    class ProductOrderDetailsBL
    {
        private static bool ValidateProductOrderDetails(Entities.ProductOrderDetails productOrder)
        {
            StringBuilder sb = new StringBuilder();
            bool validProduct = true;
            foreach (Entities.ProductOrderDetails item in ProductOrderDetailsDAL.productorderList)
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

            Regex regex1 = new Regex("^[P][0-9][0-9][0-9]$");
            bool c = regex.IsMatch(productOrder.ProductID);
            if (c != true)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "invalid ProductID");
            }

            if (productOrder.ProductUnitPrice < 0.00)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "product unit price should be greater than 0");

            }
            if (productOrder.ProductQuantity < 0.00)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "product quantity should be greater than 0");

            }
            if (productOrder.ProductTotalPrice < 0.00)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "product  total price should be greater than 0");

            }
            if (validProduct == false)
                throw new InventoryException(sb.ToString());
            return validProduct;
        }
        public static bool AddProductOrderDetailsDL(Entities.ProductOrderDetails order, List<Entities.ProductOrderDetails> orderDetails)
        {
            bool ProductorderAdded = false;
            try
            {
                if (ValidateProductOrderDetails(order))
                {
                    ProductOrderDetailsDAL productorderDAL = new ProductOrderDetailsDAL();
                    ProductorderAdded = productorderDAL.AddProductOrderDetailsDAL(order, orderDetails);
                }
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return ProductorderAdded;

        }

        public static bool DeleteProductOrderDetailsBL(string productOrderID)
        {
            bool productOrderDeleted = false;
            try
            {
                Regex regex = new Regex("^[P][O][0-9][0-9][0-9]$");
                bool b = regex.IsMatch(productOrderID);
                if (b == true)
                {
                    ProductOrderDetailsDAL productorderDAL = new ProductOrderDetailsDAL();
                    productOrderDeleted = productorderDAL.DeleteProductOrderDetailsDAL(productOrderID);
                }
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return productOrderDeleted;

        }

        public static bool UpdateProductOrderDetailsBL(Entities.ProductOrderDetails updateorder)
        {
            bool orderUpdated = false;
            try
            {
                if (ValidateProductOrderDetails(updateorder))
                {
                    ProductOrderDetailsDAL productorderDAL = new ProductOrderDetailsDAL();
                    orderUpdated = productorderDAL.UpdateProductOrderDetailsDAL(updateorder);
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