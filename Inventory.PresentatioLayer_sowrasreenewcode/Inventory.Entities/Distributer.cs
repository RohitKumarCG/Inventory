using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities
{

    public class Distributer
    {   
        //fields
        private string _distributerID;
        private string _distributerName;
        private string _distributerMob;
        private int _addressID;
        private string _distributerEmail;


        //Properties
        public string DistributerID
        {
            get { return _distributerID; }
            set { _distributerID = value; }
        }
       

        public string DistributerName
        {
            get { return _distributerName; }
            set { _distributerName = value; }
        }
        

        public string DistributerMob
        {
            get { return _distributerMob; }
            set { _distributerMob = value; }
        }
       

        public int AddressID
        { 
            get { return _addressID; }
            set { _addressID = value; }
        }
       

        public string DistributerEmail
        {
            get { return _distributerEmail; }
            set { _distributerEmail = value; }
        }

        //constructor
        public Distributer()
        {
            _distributerID = string.Empty;
            _distributerName = string.Empty;
            _distributerMob = string.Empty;
            _addressID = 0;
            _distributerEmail = string.Empty;
        }
    }
}