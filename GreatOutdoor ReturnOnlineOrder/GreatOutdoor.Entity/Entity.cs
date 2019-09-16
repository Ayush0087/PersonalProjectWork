using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;
using GreatOutdoor.Exception;

namespace GreatOutdoor.Entity
{
    public interface IOnlineReturn
    {
        string PurposeOfReturn {get; set;}
        int NoOfReturn { get; set; }
        DateTime DateOfReturn { get; set; }
        int ReturnID { get; set; }
    }
    public class OnlineReturn : IOnlineReturn
    {
        //fields
        
        private string _purposeOfReturn;
        private DateTime _dateOfReturn;
        private int _noOfReturn;
        private int _returnID;




        public DateTime DateOfReturn { get => DateOfReturn; set => DateOfReturn = value; }
        public  int ReturnID { get => _returnID; set => _returnID = value; }
        public string PurposeOfReturn { get => _purposeOfReturn; set => _purposeOfReturn = value; }
        public int NoOfReturn { get => _noOfReturn; set => _noOfReturn = value; }
        
        //constructor
        public OnlineReturn()
        {
            _purposeOfReturn = string.Empty;
            _noOfReturn = 0;
            _returnID = 0;

        }



       
    }
}
