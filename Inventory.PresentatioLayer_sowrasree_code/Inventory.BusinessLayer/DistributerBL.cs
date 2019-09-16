



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.Exceptions;
using Inventory.DataAccessLayer;
using System.Text.RegularExpressions;

namespace Inventory.BusinessLayer

{
    public class DistributerBL
    {
        private static bool ValidateDistributer(Distributer distributer)
        {
            StringBuilder sb = new StringBuilder();
            bool validDistributer = true;
            Regex regex = new Regex("^[D][0-9][0-9][0-9]$");
            bool b = regex.IsMatch(distributer.DistributerID);
            if (b!=true)
            {
                validDistributer = false;
                sb.Append(Environment.NewLine + "Invalid distributer ID");

            }
            Regex regx = new Regex("^[a-zA-Z]*$");
            bool c = regex.IsMatch(distributer.DistributerName);
            {
                validDistributer = false;
                sb.Append(Environment.NewLine + "Distributer Name Required");

            }
            Regex rgex = new Regex("^[a-zA-Z]*$");
            bool d = regex.IsMatch(distributer.DistributerMob);
            {
                validDistributer = false;
                sb.Append(Environment.NewLine + "Required 10 Digit Contact Number");
            }
            if (validDistributer == false)
                throw new InventoryException(sb.ToString());
            return validDistributer;
        }

        public static bool AddDistributerBL(Distributer newDistributer)
        {
            bool distributerAdded = false;
            try
            {
                if (ValidateDistributer(newDistributer))
                {
                    DistributerDAL distributerDAL = new DistributerDAL();
                    distributerAdded = distributerDAL.AddDistributerDAL(newDistributer);
                }
            }
            catch (InventoryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return distributerAdded;
        }

        public static List<Distributer> GetAllDistributersBL()
        {
            List<Distributer> distributerList = null;
            try
            {
                DistributerDAL distributerDAL = new DistributerDAL();
                distributerList = distributerDAL.GetAllDistributersDAL();
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return distributerList;
        }

        public static Distributer SearchDistributerBL(string searchDistributerID)
        {
            Distributer searchDistributer = null;
            try
            {
                DistributerDAL distributerDAL = new DistributerDAL();
                searchDistributer = distributerDAL.SearchDistributerDAL(searchDistributerID);
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchDistributer;

        }

        public static bool UpdateDistributerBL(Distributer updateGuest)
        {
            bool distributerUpdated = false;
            try
            {
                if (ValidateDistributer(updateGuest))
                {
                    DistributerDAL guestDAL = new DistributerDAL();
                    distributerUpdated = guestDAL.UpdateDistributerDAL(updateGuest);
                }
            }
            catch (InventoryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return distributerUpdated;
        }

        public static bool DeleteDistributerBL(string deleteDistributerID)
        {
            bool distributerDeleted = false;
            try
            {
                Regex regex = new Regex("^[D][0-9][0-9][0-9]$");
                bool b = regex.IsMatch(deleteDistributerID);
                if (b != true)
                
                {
                    DistributerDAL distributerDAL = new DistributerDAL();
                    distributerDeleted = distributerDAL.DeleteDistributerDAL(deleteDistributerID);
                }
                else
                {
                    throw new InventoryException("Invalid Distributer ID");
                }
            }
            catch (InventoryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return distributerDeleted;
        }

    }
}
