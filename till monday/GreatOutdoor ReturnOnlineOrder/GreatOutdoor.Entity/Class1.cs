using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GreatOutdoor.Entity
{
    public class OnlineReturn
    {
        //fields
        private  int _returnID;
        private string _PurposeofReturn;
        private string _noOfReturn;
        private DateTime _dateOfReturn;


       

        public DateTime DateOfReturn { get => DateOfReturn; set => DateOfReturn = value; }
        public  int ReturnID { get => _returnID; set => _returnID = value; }
        public string PurposeofReturn { get => _PurposeofReturn; set => _PurposeofReturn = value; }
        public string NoOfReturn { get => _noOfReturn; set => _noOfReturn = value; }
        
        //constructor
        public OnlineReturn()
        {
            _PurposeofReturn = string.Empty;
            _noOfReturn = string.Empty;
            _returnID = 0;
        }



       
    }
}
