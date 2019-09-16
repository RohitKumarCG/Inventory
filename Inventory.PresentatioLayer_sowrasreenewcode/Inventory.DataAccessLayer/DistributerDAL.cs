using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Inventory.Entities;
using Inventory.Exceptions;

namespace Inventory.DataAccessLayer
{
    public class DistributerDAL
    {
        public static List<Distributer> distributerList = new List<Distributer>();

        public bool AddDistributerDAL(Distributer newDistributer)//method to addDistributer()
        {
            bool distributerAdded = false;
            try
            {
                distributerList.Add(newDistributer);
                distributerAdded = true;
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return distributerAdded;

        }

        public List<Distributer> GetAllDistributersDAL()//method to get all distributers
        {
            return distributerList;
        }

        public Distributer SearchDistributerDAL(string searchDistributerID)//method to search distributer
        {
            Distributer searchDistributer = null;
            try
            {
                foreach (Distributer item in distributerList)
                {
                    if (item.DistributerID == searchDistributerID)
                    {
                        searchDistributer = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchDistributer;
        }

        public List<Distributer> GetDistributersByNameDAL(string distributerName)//method to get distributer by name
        {
            List<Distributer> searchDistributer = new List<Distributer>();
            try
            {
                foreach (Distributer item in distributerList)
                {
                    if (item.DistributerName == distributerName)
                    {
                        searchDistributer.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchDistributer;
        }

        public bool UpdateDistributerDAL(Distributer updateDistributer)//method to update distributer
        {
            bool distributerUpdated = false;
            try
            {
                for (int i = 0; i < distributerList.Count; i++)
                {
                    if (distributerList[i].DistributerID == updateDistributer.DistributerID)
                    {
                        updateDistributer.DistributerName = distributerList[i].DistributerName;
                        updateDistributer.DistributerMob= distributerList[i].DistributerMob;
                        distributerUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return   distributerUpdated;

        }

        public bool DeleteDistributerDAL(string deleteDistributerID)// method to deleteDistributer
        {
            bool distributerDeleted = false;
            try
            {
                Distributer deleteDistributer = null;
                foreach (Distributer item in distributerList)
                {
                    if (item.DistributerID == deleteDistributerID)
                    {
                        deleteDistributer  = item;
                    }
                }

                if (deleteDistributer!= null)
                {
                    distributerList.Remove(deleteDistributer);
                    distributerDeleted = true;
                }
            }
            catch (DbException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return    distributerDeleted;

        }

    }
}