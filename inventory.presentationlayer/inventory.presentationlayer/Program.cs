using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.DataAccessLayer;
using static Inventory.Exceptions.InventoryManagementExceptions;
using Inventory.BusinessLayer;

namespace Inventory.PresentationLayer1
{
    class Program
    {
        static void Main(string[] args)
        {
            RawMaterialOrderDAL RawMaterialsorderDAL = new RawMaterialsOrderDAL();
            RawMaterialsOrder RawMaterialsorder = new RawMaterialsOrder();
            ProductOrderBL RawMaterialsorderBL = new RawMaterialsOrderBL();

            int m = 1;
            List<int> orders = new List<int>();
            List<int> quantity = new List<int>();
            Console.WriteLine("Welcome to DD............");
            while (m == 1)
            {
                Console.WriteLine("enter 1 for fruit basket \n 2 for carbonated water\n 3 for sugar \n 4 for acid \n 5 for sweeteners \n 6 for flavours \n 7 for normal water  ");
                int n = int.Parse(Console.ReadLine());

                orders.Add(n);
                Console.WriteLine("Enter the quantity ");
                int k = int.Parse(Console.ReadLine());
                quantity.Add(k);
                Console.WriteLine("Do you want to add more products? Enter 1 for Yes 0 for no");
                m = int.Parse(Console.ReadLine());
            }
            double price =RawMaterialsorderDAL.generateTotalPrice(orders, quantity);
            Console.WriteLine("Total price of the order" + price);
            Console.WriteLine("do you want to place the order? \n Enter 1 for yes 0 for no ");
            m = int.Parse(Console.ReadLine());
            if (m == 1)
            {
                RawMaterialsorder.ProductOrderPrice = price;
                RawMaterialsorder.DistributorID = "D001";
                RawMaterialsorderBL.AddProductOrderBL(RawMaterialsorder);

            }

            List<RawMaterialsOrder> list = RawMaterialsorderBL.GetAllProductOrdersBL();
            foreach (RawMaterialsOrder item in list)
            {
                Console.WriteLine("raw material id" + item.ProductOrderID);
                Console.WriteLine("order price" + item.ProductOrderPrice);
                Console.WriteLine(" Distributor ID" + item.DistributorID);
                Console.WriteLine("Order Date" + item.ProductOrderDate);
            }
            Console.ReadKey();




        }
    }
}