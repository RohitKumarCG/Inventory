using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities
{

    public class Distributer
    {
        private string _distributerID;

        public string DistributerID
        {
            get { return _distributerID; }
            set { _distributerID = value; }
        }
        private string _distributerName;

        public string DistributerName
        {
            get { return _distributerName; }
            set { _distributerName = value; }
        }
        private string _distributerMob;

        public string DistributerMob
        {
            get { return _distributerMob; }
            set { _distributerMob = value; }
        }
        private int _addressID;

        public int AddressID
        { 
            get { return _addressID; }
            set { _addressID = value; }
        }
        private string _distributerEmail;

        public string DistributerEmail
        {
            get { return _distributerEmail; }
            set { _distributerEmail = value; }
        }


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